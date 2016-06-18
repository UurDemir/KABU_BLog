using Blog.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    class Rating : Entity<string>
    {
        public string UserIP { get; set; }

        public string Rate { get; set; }

        #region Foreign Key(s)


        #endregion
        public string ArticleId { get; set; }
    }
}
