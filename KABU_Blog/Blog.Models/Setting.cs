using Blog.Models.Commons;
using Blog.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Setting: Entity<string>
    {
        [Column("Key")]
        public override string Id { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Value")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Required")]
        public string Value { get; set; }

        [Display(ResourceType = typeof(Displays), Name = "Extra")]
        public string Extra { get; set; }


    }
}
