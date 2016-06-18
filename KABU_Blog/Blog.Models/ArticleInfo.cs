﻿using System;
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
    public class ArticleInfo : Entity<int>
    {
        [Display(ResourceType = typeof(Displays), Name = "Key")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Key { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Value")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Value { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Extra")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Extra { get; set; }

        #region Foreign Key(s)

        [Column("Article")]
        public int ArticleId { get; set; }

        #endregion

        #region Navigation(s)

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

        #endregion
    }
}
