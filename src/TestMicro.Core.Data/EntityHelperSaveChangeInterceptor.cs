using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TestMicro.Core.Data.Abstractions;

namespace TestMicro.Core.Data;

public class EntityHelperSaveChangeInterceptor: SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries())
        {
            switch (entityEntry.State)
            {
                case EntityState.Added:
                {
                    if (entityEntry.Entity is ICreateTime createTime)
                        createTime.CreatedAt = DateTime.UtcNow;
                    break;
                }
                case EntityState.Modified:
                {
                    if (entityEntry.Entity is IUpdateTime createTime)
                        createTime.UpdatedAt = DateTime.UtcNow;
                    break;
                }
                case EntityState.Deleted:
                {
                    if (entityEntry.Entity is ISoftDelete softDelete)
                    {
                        softDelete.DeletedAt = DateTime.UtcNow;
                        entityEntry.State = EntityState.Modified;
                    }

                    break;
                }
            }
        }
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}