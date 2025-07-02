using testing.IAM.Domain.Model.Aggregates;

namespace testing.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> VerifyToken(string token);
}