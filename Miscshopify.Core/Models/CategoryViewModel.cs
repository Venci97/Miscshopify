using Miscshopify.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Core.Models
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string? ImagePath { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        //public List<Product> Products { get; set; };
    }
}