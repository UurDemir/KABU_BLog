using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Resources;

namespace Blog.Models.Commons
{
    public class MonitoredEntity<TId>:Entity<TId>,IMonitoredEntity
    {

        [Column(Order = 97)]
        [Display(ResourceType = typeof(Displays),Name = "CreatedDate")]
        public virtual DateTime Created { get; set; }

        [Column(Order = 98)]
        [Display(ResourceType = typeof(Displays), Name = "UpdatedDate")]
        public virtual DateTime Updated { get; set; }

        #region Foreign Key(s)

        [Column("CreatedBy", Order = 99)]
        public virtual string CreatedId { get; set; }

        [Column("UpdatedBy", Order = 100)]
        public virtual string UpdatedId { get; set; }

        #endregion

        #region Navigation(s)

        [ForeignKey("CreatedId")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("UpdatedId")]
        public virtual User UpdatedBy { get; set; }

        #endregion

    }
}
