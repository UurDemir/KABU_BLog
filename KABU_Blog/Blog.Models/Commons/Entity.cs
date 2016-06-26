using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.Commons
{
    public class Entity<TId>:BaseEntity,IEntity<TId>
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TId Id { get; set; }

        [NotMapped]
        public virtual string SlugId => $"{Id}";
    }
}
