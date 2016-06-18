using Blog.Models.Commons;
using Blog.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
     public class Rating : Entity<string>
    {
        [Display(ResourceType = typeof(Displays), Name = "UserIp")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string UserIp { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Rate")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public int Rate { get; set; }

        #region Foreign Key(s)
        [Column("Article")]
        public int ArticleId { get; set; }
        #endregion


        #region Navigation(s)
        [ForeignKey("ArticleId")]
        public  Article Article { get; set; }

        #endregion

    }
}
