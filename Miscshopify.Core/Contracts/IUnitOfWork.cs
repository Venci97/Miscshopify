using Microsoft.AspNetCore.Http;
using Miscshopify.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscshopify.Core.Contracts
{
	public interface IUnitOfWork
	{
		void UploadImage(IFormFile file);
    }
}
