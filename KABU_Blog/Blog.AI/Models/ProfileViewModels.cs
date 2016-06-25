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
        [Display(ResourceType = typeof(Displays), Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Surname")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [Display(ResourceType = typeof(Displays), Name = "Birthdate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public DateTime Birthdate { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Displays), Name = "OldPassword")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Displays), Name = "NewPassword")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "StringLenghtOnlyMin", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Displays), Name = "ConfirmNewPassword")]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ComparerPassword")]
        public string ConfirmPassword { get; set; }
    }
}