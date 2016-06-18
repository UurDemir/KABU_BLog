using System.ComponentModel.DataAnnotations;
using Blog.Resources;

namespace Blog.Models.Types
{
    public enum Status : short
    {
        [Display(ResourceType = typeof(Displays), Name = "Active")]
        Active = 1,
        [Display(ResourceType = typeof(Displays), Name = "Passive")]
        Passive = 0,
        [Display(ResourceType = typeof(Displays), Name = "Draft")]
        Draft = -1,
        [Display(ResourceType = typeof(Displays), Name = "Deleted")]
        Deleted = -999
    }

    public enum CommentStatus : short
    {
        [Display(ResourceType = typeof(Displays), Name = "New")]
        New = 0,
        [Display(ResourceType = typeof(Displays), Name = "Approved")]
        Approved = 1,
        [Display(ResourceType = typeof(Displays), Name = "Ignored")]
        Ignored = -1
    }

    public enum ContactStatus : short
    {
        [Display(ResourceType = typeof(Displays), Name = "Read")]
        Read = 1,
        [Display(ResourceType = typeof(Displays), Name = "UnRead")]
        UnRead = 0
    }

    public enum BlockStatus
    {
        Allowed = 1,

        Banned = 0
    }
}