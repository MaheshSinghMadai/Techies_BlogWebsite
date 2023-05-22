using Entities.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class BlogPost  : BaseEntity
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Category { get; set; }

        public string Content { get; set; }

        [NotMapped]
        [DisplayName("Upload Thumbnail")]
        public byte[] ProductImage { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
