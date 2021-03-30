using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DTStamp { get; set; }

        public string User { get; set; }

        public int ImageId { get; set; }

    }

}
