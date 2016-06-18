using Blog.Models.Commons;
using Blog.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
     public class Rating : Entity<string>
    {
        [Display(ResourceType = typeof(Displays), Name = "UserIp")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string UserIP { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Rate")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Rate { get; set; }

        #region Foreign Key(s)
        [Column("Article")]
        public string ArticleId { get; set; }
        #endregion


        #region Navigation(s)
        [ForeignKey("ArticleId")]
        public  Article Article { get; set; }

        #endregion

    }
}
