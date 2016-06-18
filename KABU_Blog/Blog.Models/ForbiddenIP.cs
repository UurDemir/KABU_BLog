using Blog.Models.Commons;
using Blog.Models.Types;
using Blog.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class ForbiddenIP : MonitoredEntity<int>
    {
        public string Ip { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "UserIp")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Reason { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "BlockingTime")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public DateTime BlockingTime { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Status")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public Status Status {get ; set;}
    }
}
