using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models;

namespace Blog.AI.Models
{
    public class ArticleViewModel
    {
        public Article Article { get; set; }

        public int CategoryIds { get; set; }

    }
}