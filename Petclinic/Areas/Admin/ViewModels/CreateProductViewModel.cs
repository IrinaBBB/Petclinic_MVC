using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinic.Models.Shop;

namespace Petclinic.Areas.Admin.ViewModels
{
    public class CreateProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}