using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models.Commons;

namespace Blog.Models
{
    public class Tag:Entity<int>
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Owner { get; set; }
    }
}
