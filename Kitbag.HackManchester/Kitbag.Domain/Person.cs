using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitbag.Domain
{
    [Table("Person")]
    public partial class Person
    {
        public Person()
        {
            Groups = new HashSet<Group>();
            CurrentlyWorkingOns = new HashSet<CurrentlyWorkingOn>();
            Groups1 = new HashSet<Group>();
            Status = new HashSet<Status>();
        }

        public int Id { get; set; }

        public int? ManagerId { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        public int? SocialMediaSourceId { get; set; }

        [StringLength(256)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string LastName { get; set; }

        [StringLength(256)]
        public string JobTitle { get; set; }

        public int? OrganisationId { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual Group Group { get; set; }

        public virtual SocialMediaSource SocialMediaSource { get; set; }

        public virtual ICollection<CurrentlyWorkingOn> CurrentlyWorkingOns { get; set; }

        public virtual ICollection<Group> Groups1 { get; set; }

        public virtual ICollection<Status> Status { get; set; }
    }
}
