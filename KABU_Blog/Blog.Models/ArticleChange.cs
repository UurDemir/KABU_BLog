using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models.Commons;
using Blog.Resources;

namespace Blog.Models
{
    public class ArticleChange : Entity<int>
    {
        [Display(ResourceType = typeof(Displays),Name = "Description")]
        public string Description { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "CreatedDate")]
        public DateTime Created { get; set; }

        #region Foreign Key(s)

        [Column("Article")]
        public int ArticleId { get; set; }

        [Column("User")]
        public string UserId { get; set; }

        #endregion

        #region Navigation(s)

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

        #endregion
    }
}
