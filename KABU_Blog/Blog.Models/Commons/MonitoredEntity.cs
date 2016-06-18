using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models.Commons
{
    public class MonitoredEntity<TId>:Entity<TId>,IMonitoredEntity<TId>
    {

        [Column(Order = 97)]
        public virtual DateTime Created { get; set; }

        [Column(Order = 98)]
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
