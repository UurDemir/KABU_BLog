using System.ComponentModel.DataAnnotations;
using Blog.Models.Types;
using Blog.Resources;

namespace Blog.Models.Commons
{
    public abstract class BaseEntity
    {
        [Display(ResourceType = typeof(Displays), Name = "Status")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public Status Status { get; set; }
    }
}