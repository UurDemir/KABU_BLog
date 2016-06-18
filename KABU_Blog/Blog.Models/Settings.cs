using Blog.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    class Settings: Entity<string>
    {
        [Column("Key")]
        public override string Id { get; set; }

        public string Value { get; set; }

        public string Extra { get; set; }


    }
}
