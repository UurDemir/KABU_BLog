using System.ComponentModel.DataAnnotations;
using Blog.Resources;

namespace Blog.Models.Types
{
    public enum Status
    {
        [Display(ResourceType = typeof(Displays),Name = "Active")]
        Active = 1,
        [Display(ResourceType = typeof(Displays), Name = "Passive")]
        Passive = 0,
        [Display(ResourceType = typeof(Displays), Name = "Draft")]
        Draft = -1,
        [Display(ResourceType = typeof(Displays), Name = "Deleted")]
        Deleted = -999
    }
}