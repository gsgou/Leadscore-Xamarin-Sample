using System.Net.Http;
using System.Threading.Tasks;
using Leadscore.Models;
using Refit;

namespace Leadscore.Interfaces
{
    [Headers("Content-Type: application/json", "Accept: application/json")]
    public interface IAuthentication
    {
        [Post("/login")]
        Task<LoginResult> Login([Body(BodySerializationMethod.Json)] LoginRequest request);

        [Post("/logout")]
        Task<ApiResponse<HttpContent>> Logout([Body(BodySerializationMethod.Json)] LogoutRequest request);
    }
}