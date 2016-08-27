using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Models;

namespace Blog.UI.Models
{
    public class SidebarViewModel
    {
        public List<Article> Articles { get; set; }
        public List<Category> Categories { get; set; }
    }
}