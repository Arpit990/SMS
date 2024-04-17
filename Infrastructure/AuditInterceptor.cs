using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SpeakerManagementSystem.Models.Common;

public class AuditInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var entries = eventData.Context.ChangeTracker.Entries()
            .Where(e => e.Entity is IAuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                var auditableEntity = (IAuditableEntity)entry.Entity;
                auditableEntity.CreatedDate = DateTime.UtcNow;
                auditableEntity.CreatedBy = "Arpit"; // Set CreatedBy from your authentication context
            }

            if (entry.State == EntityState.Modified)
            {
                var auditableEntity = (IAuditableEntity)entry.Entity;
                auditableEntity.ModifiedDate = DateTime.UtcNow;
                auditableEntity.ModifiedBy = "Arpit"; // Set ModifiedBy from your authentication context
            }
        }

        return base.SavingChanges(eventData, result);
    }
}
