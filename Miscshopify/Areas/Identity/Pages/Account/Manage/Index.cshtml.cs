// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Miscshopify.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Miscshopify.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public string CurrentImagePath { get; set; }
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "First Name")]
            [Required(ErrorMessage = "First Name is required")]
            [StringLength(20, ErrorMessage = "First Name must be between {2} and {1} characters long.", MinimumLength = 2)]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            [Required(ErrorMessage = "Last Name is required")]
            [StringLength(20, ErrorMessage = "Last Name must be between {2} and {1} characters long.", MinimumLength = 2)]
            public string LastName { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            [Required(ErrorMessage = "Phone number is required")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Address")]
            [Required(ErrorMessage = "Address is required")]
            [StringLength(100, ErrorMessage = "Address must be between {2} and {1} characters long.", MinimumLength = 5)]
            public string Address { get; set; }

            [Display(Name = "City")]
            [Required(ErrorMessage = "City is required")]
            [StringLength(50, ErrorMessage = "City must be between {2} and {1} characters long.", MinimumLength = 2)]
            public string City { get; set; }

            [Display(Name = "Post Code")]
            [Required(ErrorMessage = "Post Code is required")]
            [StringLength(20, ErrorMessage = "Post Code must be between {2} and {1} characters long.", MinimumLength = 3)]
            public string PostCode { get; set; }

            [Display(Name = "Profile Image")]
            public IFormFile NewImage { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            // Add cache busting to force browser to reload image
            CurrentImagePath = !string.IsNullOrEmpty(user.ImagePath)
                ? $"{user.ImagePath}?v={DateTime.Now.Ticks}"
                : "/images/default-avatar.png";

            Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = phoneNumber,
                Address = user.Address,
                City = user.City,
                PostCode = user.PostCode
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // Don't load current data at the beginning - it overwrites the Input
            if (!ModelState.IsValid)
            {
                await LoadAsync(user); // Load only if model is invalid
                return Page();
            }

            // Update names and phone number
            bool hasChanges = false;

            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName?.Trim() ?? string.Empty;
                hasChanges = true;
            }

            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName?.Trim() ?? string.Empty;
                hasChanges = true;
            }

            // Update address information
            if (Input.Address != user.Address)
            {
                user.Address = Input.Address?.Trim() ?? string.Empty;
                hasChanges = true;
            }

            if (Input.City != user.City)
            {
                user.City = Input.City?.Trim() ?? string.Empty;
                hasChanges = true;
            }

            if (Input.PostCode != user.PostCode)
            {
                user.PostCode = Input.PostCode?.Trim() ?? string.Empty;
                hasChanges = true;
            }

            // Update phone number
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Error: Could not set phone number.";
                    await LoadAsync(user);
                    return Page();
                }
                hasChanges = true;
            }

            // Handle image upload
            if (Input.NewImage != null && Input.NewImage.Length > 0)
            {
                try
                {
                    // Basic validation
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileExtension = Path.GetExtension(Input.NewImage.FileName).ToLowerInvariant();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("Input.NewImage", "Please upload a valid image (JPG, PNG, GIF).");
                        await LoadAsync(user);
                        return Page();
                    }

                    // File size check (5MB max)
                    if (Input.NewImage.Length > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("Input.NewImage", "Image must be less than 5MB.");
                        await LoadAsync(user);
                        return Page();
                    }

                    // Ensure upload directory exists
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "users");
                    if (!System.IO.Directory.Exists(uploadsFolder))
                    {
                        System.IO.Directory.CreateDirectory(uploadsFolder);
                    }

                    // Generate unique filename
                    var uniqueFileName = $"{user.Id}_{DateTime.Now:yyyyMMddHHmmssfff}{fileExtension}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Save file
                    using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                    {
                        await Input.NewImage.CopyToAsync(stream);
                    }

                    // Delete old image if it exists and is not default
                    if (!string.IsNullOrEmpty(user.ImagePath) &&
                        user.ImagePath != "/images/default-avatar.png" &&
                        !user.ImagePath.Contains("default-avatar"))
                    {
                        var oldImagePath = user.ImagePath.StartsWith("~/") ? user.ImagePath.Substring(2) : user.ImagePath;
                        var oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, oldImagePath.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            try
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                            catch (Exception ex)
                            {
                                // Log delete error but don't stop the process
                                Console.WriteLine($"Could not delete old image: {ex.Message}");
                            }
                        }
                    }

                    // Set the new image path
                    user.ImagePath = $"/images/users/{uniqueFileName}";
                    hasChanges = true;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Input.NewImage", $"Error uploading image: {ex.Message}");
                    await LoadAsync(user);
                    return Page();
                }
            }

            // Save changes if any
            if (hasChanges)
            {
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    StatusMessage = "Error: Could not update profile.";
                    await LoadAsync(user);
                    return Page();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated successfully!";

            // Force complete page reload with cache busting
            return RedirectToPage(new { refresh = DateTime.Now.Ticks });
        }
    }
}