using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitbag.Domain
{
    [Table("SocialMediaSource")]
    public partial class SocialMediaSource
    {
        public SocialMediaSource()
        {
            People = new HashSet<Person>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
