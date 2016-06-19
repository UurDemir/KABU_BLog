using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Blog.Resources;

namespace Blog.AI.Models
{
    public class UserInformationViewModel
    {
        [Display(ResourceType = typeof(Displays),Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(Messages),ErrorMessageResourceName = "Required")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Surname")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [Display(ResourceType = typeof(Displays), Name = "Birthdate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public DateTime Birthdate { get; set; }
    }
}