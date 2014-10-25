namespace Kitbag.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Status
    {
        public Status()
        {
            Groups = new HashSet<Group>();
            People = new HashSet<Person>();
        }

        public int Id { get; set; }

        [Column("Status")]
        [Required]
        [StringLength(500)]
        public string Status1 { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
