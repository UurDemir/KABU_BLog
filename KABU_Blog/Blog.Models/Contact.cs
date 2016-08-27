using System;
using System.ComponentModel.DataAnnotations;
using Blog.Models.Commons;
using Blog.Models.Types;
using Blog.Resources;

namespace Blog.Models
{
    public class Contact : Entity<int>
    {
        [Display(ResourceType = typeof (Displays), Name = "FullName")]
        [Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Required")]
        [StringLength(50,MinimumLength = 2, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "StringLenghtWithMin")]
        public string Fullname { get; set; }

        [Display(ResourceType = typeof (Displays), Name = "Email")]
        [RegularExpression(
            @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
            ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Regex")]
        [Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Required")]
        public string Email { get; set; }

        //[Display(ResourceType = typeof (Displays), Name = "PhoneNumber")]
        //[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Required")]
        //[StringLength(20,MinimumLength = 10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "StringLenghtWithMin")]
        public string PhoneNumber { get; set; }

        //[Display(ResourceType = typeof (Displays), Name = "Title")]
        //[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Required")]
        //[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "StringLenght")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof (Displays), Name = "Message")]
        [Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Required")]
        [StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "StringLenght")]
        public string Message { get; set; }

        //[Display(ResourceType = typeof (Displays), Name = "UserIp")]
        //[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string UserIp { get; set; }

        //[Display(ResourceType = typeof (Displays), Name = "Status")]
        //[Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Required")]
        public ContactStatus ContactStatus { get; set; }


        [Display(ResourceType = typeof(Displays), Name = "CreatedDate")]
        public DateTime Created { get; set; }
    }
}