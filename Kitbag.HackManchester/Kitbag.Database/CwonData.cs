namespace Kitbag.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CwonData : DbContext
    {
        public CwonData()
            : base("name=CwonData")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<CurrentlyWorkingOn> CurrentlyWorkingOns { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<SocialMediaSource> SocialMediaSources { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<CurrentlyWorkingOn>()
                .HasMany(e => e.Groups)
                .WithMany(e => e.CurrentlyWorkingOns)
                .Map(m => m.ToTable("GroupCurrentlyWorkingOn").MapLeftKey("CurrentlyWorkingOnId").MapRightKey("GroupId"));

            modelBuilder.Entity<CurrentlyWorkingOn>()
                .HasMany(e => e.People)
                .WithMany(e => e.CurrentlyWorkingOns)
                .Map(m => m.ToTable("PersonCurrentlyWorkingOn").MapLeftKey("CurrentlyWorkingOnId").MapRightKey("PersonId"));

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Group1)
                .WithOptional(e => e.Group2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.People)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.OrganisationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Status)
                .WithMany(e => e.Groups)
                .Map(m => m.ToTable("GroupStatus").MapLeftKey("GroupId").MapRightKey("StatusId"));

            modelBuilder.Entity<Group>()
                .HasMany(e => e.People1)
                .WithMany(e => e.Groups1)
                .Map(m => m.ToTable("PersonGroup").MapLeftKey("GroupId").MapRightKey("PersonId"));

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Status)
                .WithMany(e => e.People)
                .Map(m => m.ToTable("PersonStatus").MapLeftKey("PersonId").MapRightKey("StatusId"));

            modelBuilder.Entity<SocialMediaSource>()
                .HasMany(e => e.People)
                .WithRequired(e => e.SocialMediaSource)
                .WillCascadeOnDelete(false);
        }
    }
}
