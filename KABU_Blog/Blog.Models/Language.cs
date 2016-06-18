using System.ComponentModel.DataAnnotations;
using Blog.Models.Commons;
using Blog.Resources;

namespace Blog.Models
{
    public class Language:Entity<string>
    {
        [Display(ResourceType = typeof(Displays),Name = "DisplayName")]
        [Required(ErrorMessageResourceType = typeof(Messages),ErrorMessageResourceName = "Required")]
        public string DisplayName { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "NativeName")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string NativeName { get; set; }
    }
}
