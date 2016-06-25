using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blog.Models.Commons;
using Blog.Models.Types;
using Blog.Resources;

namespace Blog.Models
{
    public class Article : MonitoredEntity<int>
    {
        [Display(ResourceType = typeof(Displays), Name = "Title")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Title { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Content")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Content { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "ContentSummary")]
        public string ContentSummary { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "ViewCount")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public int ViewCount { get; set; }

        
        #region Navigastion(s)

        public virtual List<ArticleInfo> ArticleInfos { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<ArticleChange> ArticleChanges { get; set; }
        #endregion

        #region Computed Properties

        public override string SlugId => $"article{Id}";

        #endregion

    }
}
