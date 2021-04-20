using System.ComponentModel.DataAnnotations;

namespace PictureShare.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Category Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
