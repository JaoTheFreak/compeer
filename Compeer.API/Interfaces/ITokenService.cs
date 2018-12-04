using Compeer.Core.Entities;

namespace Compeer.API.Interfaces
{
    public interface ITokenService
    {
        Compeer.API.Model.JsonWebToken GetNewToken(User userToUse);
    }
}