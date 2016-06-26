using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Blog.Models;

namespace Blog.AI.Models
{
    public class ArticleViewModel
    {
        public Article Article { get; set; }

        [UIHint("MultiSelect")]
        public int[] CategoryIds { get; set; }

    }
}