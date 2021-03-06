﻿using System.ComponentModel.DataAnnotations;
using Blog.Models.Commons;
using Blog.Models.Types;
using Blog.Resources;

namespace Blog.Models
{
    public class Page : MonitoredEntity<int>
    {
        [Display(ResourceType = typeof(Displays), Name = "Title")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Title { get; set; }

        [DataType(DataType.Html)]
        [Display(ResourceType = typeof(Displays), Name = "Content")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Content { get; set; }
        
        #region Computed Properties

        public override string SlugId => $"page{Id}";

        #endregion
    }
}
