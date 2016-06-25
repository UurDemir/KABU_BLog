using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Models.Commons;
using Blog.Models.Types;
using Blog.Resources;

namespace Blog.Models
{
    public class Comment : Entity<int>
    {
        [Display(ResourceType = typeof (Displays), Name = "FullName")]
        [Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Required")]
        [StringLength(50,MinimumLength = 2, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "StringLenghtWithMin")]
        public string Fullname { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Regex")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Email { get; set; }

        [Display(ResourceType = typeof (Displays), Name = "Message")]
        [Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Required")]
        [StringLength(2000,ErrorMessageResourceType = typeof(Messages),ErrorMessageResourceName = "StringLenght")]
        public string Message { get; set; }

        [Display(ResourceType = typeof (Displays), Name = "UserIp")]
        [Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "Required")]
        public string UserIp { get; set; }


        [Display(ResourceType = typeof (Displays), Name = "CreatedDate")]
        public DateTime Created { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Status")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public CommentStatus CommentStatus { get; set; }

        #region Foreign Key(s)

        [Column("Parent")]
        public int? ParentId { get; set; }

        [Column("Article")]
        public int ArticleId { get; set; }

        #endregion

        #region Navigation(s)

        [ForeignKey("ParentId")]
        public Comment Parent { get; set; }

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

        #endregion
    }
}