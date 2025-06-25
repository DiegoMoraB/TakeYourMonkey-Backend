using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace testing.IAM.Domain.Model.Entities;

public partial class Asset : IEntityWithCreatedUpdatedDate
{
    [Column("created_at")]public DateTimeOffset? CreatedDate { get; set; }
    [Column("updated_at")]public DateTimeOffset? UpdatedDate { get; set; }
}