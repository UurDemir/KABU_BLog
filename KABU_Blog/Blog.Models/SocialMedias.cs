using Blog.Models.Commons;
using Blog.Models.Types;
using Blog.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    class SocialMedias : Entity<string>
    {
        [Display(ResourceType = typeof(Displays), Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Name { get; set; }


        public string Icon { get; set; }

        public string Link { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Status")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public Status Status { get; set; }
    }
}
