using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PictureShare.Models
{
    public class PictureViewModel
    {
        public PictureModel Picture { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
