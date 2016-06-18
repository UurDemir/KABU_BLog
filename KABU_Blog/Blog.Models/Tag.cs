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
