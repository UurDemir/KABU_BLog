using Blog.Models.Commons;
using Blog.Models.Types;
using Blog.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class ForbiddenIp : MonitoredEntity<int>
    {
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Ip { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Reason")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Reason { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "EndDate")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public DateTime EndDate { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Status")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public BlockStatus Status {get ; set;}
    }
}
