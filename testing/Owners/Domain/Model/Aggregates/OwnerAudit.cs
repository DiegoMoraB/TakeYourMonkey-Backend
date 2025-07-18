using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace testing.Owners.Domain.Model.Aggregates;

public partial class OwnerAudit : IEntityWithCreatedUpdatedDate
{
    [Column("create_at")]  public DateTimeOffset? CreatedDate { get; set; }
    [Column("updated_at")] public DateTimeOffset? UpdatedDate { get; set; }
}