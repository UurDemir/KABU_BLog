using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Models.Commons;
using Blog.Models.Types;
using Blog.Resources;

namespace Blog.Models
{
    public class Category : MonitoredEntity<int>
    {
        [Display(ResourceType = typeof(Displays),Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(Messages),ErrorMessageResourceName = "Required")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Description")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Description { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Slug { get; set; }
        

        #region Foreign Key(s)

        [Column("Parent")]
        [UIHint("DropDown")]
        public int? ParentId { get; set; }

        [Column("Language")]
        [UIHint("DropDown")]
        public string LanguageId { get; set; }

        #endregion

        #region Navigation(s)

        [ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }

        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; }

        public virtual List<Article> Articles { get; set; }

        #endregion

        #region Computed Properties

        public override string SlugId => $"category{Id}";

        #endregion
    }
}
