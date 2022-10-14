using MarketApp.Domain.Commons;
using MarketApp.Service.Helpers;

namespace MarketApp.Service.Extensions;

public static class AuditableExtension
{
    public static void Create(this Auditable auditable)
    {
        auditable.CreatedAt = DateTime.UtcNow;
        auditable.CreatedBy = HttpContextHelper.UserId;
    }

    public static void Update(this Auditable auditable)
    {
        auditable.UpdatedAt = DateTime.UtcNow;
        auditable.UpdatedBy = HttpContextHelper.UserId;
    }

    public static void Delete(this Auditable auditable)
    {
        auditable.DeletedAt = DateTime.UtcNow;
        auditable.DeletedBy = HttpContextHelper.UserId;
    }

}