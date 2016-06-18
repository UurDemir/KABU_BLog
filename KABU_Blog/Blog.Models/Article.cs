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

        [Display(ResourceType = typeof(Displays), Name = "Status")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public Status Status { get; set; }

        #region Foreign Key(s)

        [Column("Category")]
        public int CategoryId { get; set; }

        #endregion

        #region Navigastion(s)

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        #endregion

        #region Computed Properties

        public override string SlugId => $"article{Id}";

        #endregion

    }
}
