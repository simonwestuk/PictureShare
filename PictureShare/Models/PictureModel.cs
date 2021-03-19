using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Models
{
    public class PictureModel
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        public string UserEmail { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public string Caption { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
