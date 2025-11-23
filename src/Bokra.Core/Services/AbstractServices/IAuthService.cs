using Bokra.Core.Common;
using Bokra.Core.Entities.Identity;

namespace Bokra.Core.Services.AbstractServices
{
    public interface IAuthService
    {
        public Task<Response<string>> SignUpAsync(User user, string password);
        public Task<Response<string>> Login(User user, string password);
    }
}
