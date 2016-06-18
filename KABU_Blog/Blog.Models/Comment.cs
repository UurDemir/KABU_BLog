using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models.Commons;
using Blog.Models.Types;
using Blog.Resources;

namespace Blog.Models
{
    public class Comment : Entity<int>
    {
        public int ArticleId { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Message")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Message { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "UserIp")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string UserIp { get; set; }


        public DateTime Created { get; set; }

        public Status Type { get; set; }


        #region Foreign Key(s)

        [Column("Parent")]
        public int? ParentId { get; set; }

        #endregion

        #region Navigation(s)

        [ForeignKey("ParentId")]
        public Category Parent { get; set; }

        #endregion
    }
}
