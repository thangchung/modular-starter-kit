using System.Threading.Tasks;

namespace MSK.Application.Module.Identity.Services
{
    public interface ILoginService<T>
    {
        Task<bool> ValidateCredentials(T user, string password);
        Task<T> FindByUsername(string user);
        Task SignIn(T user);
    }
}
