using Microsoft.EntityFrameworkCore;
using RefreshFW.Domain.Entities;

namespace RefreshFW.Persistance
{
    public class RefreshFrameWorkDBContext : DbContext
    {
        public RefreshFrameWorkDBContext(DbContextOptions<RefreshFrameWorkDBContext> options) : base(options)
        {

        }

        public DbSet<CustomerIndividu> customer_individus { get; set; }

        // mapping properties and fields name:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CustomerIndividu:
            modelBuilder.Entity<CustomerIndividu>()
                .Property(b => b.FullName).HasColumnName("full_name");

            modelBuilder.Entity<CustomerIndividu>()
                .Property(b => b.IdentityNumber).HasColumnName("identity_number");

            modelBuilder.Entity<CustomerIndividu>()
                .Property(b => b.IsActive).HasColumnName("is_active");

            modelBuilder.Entity<CustomerIndividu>()
                .Property(b => b.CreatedDate).HasColumnName("created_date");

            modelBuilder.Entity<CustomerIndividu>()
                .Property(b => b.CreatedBy).HasColumnName("created_by");

            modelBuilder.Entity<CustomerIndividu>()
                .Property(b => b.ModifiedDate).HasColumnName("modified_date");

            modelBuilder.Entity<CustomerIndividu>()
                .Property(b => b.ModifiedBy).HasColumnName("modified_by");

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Get all the entities that inherit from AuditAbleEntity and have a state of Added or Modified
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditAble && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            // For each entity we will set the Audit properties
            foreach (var entityEntry in entries)
            {
                // If the entity state is Added let's set the Created_date and Created_by properties
                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditAble)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
                    ((AuditAble)entityEntry.Entity).CreatedBy = "";
                }
                else
                {
                    // If the state is Modified then we don't want to modify the Created_date and Created_by properties so we set their state as IsModified to false
                    Entry((AuditAble)entityEntry.Entity).Property(p => p.CreatedDate).IsModified = false;
                    Entry((AuditAble)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
                }

                // In any case we always want to set the properties Modified_date and Modified_by
                ((AuditAble)entityEntry.Entity).ModifiedDate = DateTime.UtcNow;
                ((AuditAble)entityEntry.Entity).ModifiedBy = "";
            }

            // After we set all the needed properties we call the base implementation of SaveChangesAsync to actually save our entities in the database
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}