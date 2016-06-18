using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models.Commons;
using Blog.Models.Types;
using Blog.Resources;

namespace Blog.Models
{
    public class Category:MonitoredEntity<int>
    {
        [Display(ResourceType = typeof(Displays),Name = "Name")]
        [Required(ErrorMessageResourceType = typeof(Messages),ErrorMessageResourceName = "Required")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Description")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Description { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Slug { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Status")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public Status Status { get; set; }

        #region Foreign Key(s)

        [Column("Parent")]
        public int? ParentId { get; set; }

        #endregion

        #region Navigation(s)

        [ForeignKey("ParentId")]
        public Category Parent { get; set; }

        #endregion

        #region Computed Properties

        public override string SlugId => $"category{Id}";

        #endregion
    }
}
