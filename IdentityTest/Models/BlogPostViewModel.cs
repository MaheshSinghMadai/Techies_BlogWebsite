﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Techie.Models
{
    public class BlogPostViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Title { get; set; }

        [DisplayName("Published Date")]
        public DateTime PublishDate { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }

    }
}
