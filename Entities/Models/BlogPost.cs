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
        public string Content { get; set; }   
        public string AuthorName { get; set; }

        //[Required]
        //public string ApplicationUserId { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }

    }
}
