using SpeakerManagementSystem.ViewModel;

namespace SpeakerManagementSystem.Repository.Interface
{
    public interface IAuthRepository
    {
        Task<bool> AuthenticateUser(Login model);
    }
}
