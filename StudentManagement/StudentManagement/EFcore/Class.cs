using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebAPI.EFcore
{
    [Table("Class")]
    public class Class
    {
        [Key, Required]
        public int id { get; set; }

        public virtual Student Student {get ; set;}

        public string name { get; set; } = string.Empty;
        public string tern { get; set; } = string.Empty;
        public string cousera { get; set; } = string.Empty;

    }
}
