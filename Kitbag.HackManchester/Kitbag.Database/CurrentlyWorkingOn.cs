namespace Kitbag.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CurrentlyWorkingOn")]
    public partial class CurrentlyWorkingOn
    {
        public CurrentlyWorkingOn()
        {
            Groups = new HashSet<Group>();
            People = new HashSet<Person>();
        }

        public int Id { get; set; }

        [Column("CurrentlyWorkingOn")]
        [Required]
        [StringLength(500)]
        public string CurrentlyWorkingOn1 { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
