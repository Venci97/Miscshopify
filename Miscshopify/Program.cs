using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Miscshopify.Api;
using Miscshopify.Api.Configurations;
using Miscshopify.Common.Constants;
using Miscshopify.Core.Contracts;
using Miscshopify.Core.Services;
using Miscshopify.Infrastructure.Data;
using Miscshopify.Infrastructure.Data.Models;
using Miscshopify.Infrastructure.Data.Repositories;
using Miscshopify.ModelBinders;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Database
var connectionString = builder.Configuration.GetConnectionString("MiscshopifyContextConnection")
    ?? throw new InvalidOperationException("Connection string 'MiscshopifyContextConnection' not found.");

builder.Services.AddDbContext<MiscshopifyContext>(options =>
    options.UseSqlServer(connectionString)
    .ConfigureWarnings(warnings =>
               warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning)))
    ;

// Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MiscshopifyContext>();

builder.Services.AddIdentityCore<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>>()
    .AddEntityFrameworkStores<MiscshopifyContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

// Anti-Forgery
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN";
    options.SuppressXFrameOptionsHeader = false;
});

// --- Services ---
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductService, Miscshopify.Core.Services.ProductService>();

// Stripe configuration
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
builder.Services.AddSingleton<StripeService>(sp =>
{
    var stripeSettings = sp.GetRequiredService<IOptions<StripeSettings>>().Value;
    return new StripeService(stripeSettings);
});

// MVC & ModelBinders
builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
        options.ModelBinderProviders.Insert(1, new DateTimeModelBinderProvider(GlobalConstants.DataFormating.NormalDateFormat));
        options.ModelBinderProviders.Insert(2, new DoubleModelBinderProvider());
    });

// Scoped services
builder.Services.AddScoped<IAppDbRepository, AppDbRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, Miscshopify.Core.Services.ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<ISettingsService, SettingsService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var webHostEnvironment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

    var usersDir = Path.Combine(webHostEnvironment.WebRootPath, "images", "users");
    if (!System.IO.Directory.Exists(usersDir))
    {
        System.IO.Directory.CreateDirectory(usersDir);
        Console.WriteLine($"Created directory: {usersDir}");
    }

    var defaultAvatar = Path.Combine(webHostEnvironment.WebRootPath, "images", "default-avatar.png");
    if (!System.IO.File.Exists(defaultAvatar))
    {
        Console.WriteLine("WARNING: default-avatar.png not found in wwwroot/images/");
    }
}

// Stripe Initialization
var stripeSettings = app.Services.GetRequiredService<IOptions<StripeSettings>>().Value;
if (string.IsNullOrWhiteSpace(stripeSettings.SecretKey))
{
    var envPublishable = Environment.GetEnvironmentVariable("STRIPE__PUBLISHABLEKEY");
    var envSecret = Environment.GetEnvironmentVariable("STRIPE__SECRETKEY");

    if (!string.IsNullOrWhiteSpace(envSecret))
    {
        stripeSettings.PublishableKey = envPublishable;
        stripeSettings.SecretKey = envSecret;
    }
}

if (!string.IsNullOrWhiteSpace(stripeSettings.SecretKey))
{
    StripeConfiguration.ApiKey = stripeSettings.SecretKey;
}
else
{
    throw new InvalidOperationException("Stripe SecretKey is not configured. Set it in User Secrets (development) or Environment Variables (production).");
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Add cache busting for static files in development
if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles(new StaticFileOptions
    {
        OnPrepareResponse = ctx =>
        {
            ctx.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store");
            ctx.Context.Response.Headers.Append("Expires", "-1");
        }
    });
}
else
{
    app.UseStaticFiles();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "Area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();