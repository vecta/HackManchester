namespace Kitbag.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Group")]
    public partial class Group
    {
        public Group()
        {
            Group1 = new HashSet<Group>();
            People = new HashSet<Person>();
            CurrentlyWorkingOns = new HashSet<CurrentlyWorkingOn>();
            Status = new HashSet<Status>();
            People1 = new HashSet<Person>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public int OwnerId { get; set; }

        public int? ParentId { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<Group> Group1 { get; set; }

        public virtual Group Group2 { get; set; }

        public virtual ICollection<Person> People { get; set; }

        public virtual ICollection<CurrentlyWorkingOn> CurrentlyWorkingOns { get; set; }

        public virtual ICollection<Status> Status { get; set; }

        public virtual ICollection<Person> People1 { get; set; }
    }
}
