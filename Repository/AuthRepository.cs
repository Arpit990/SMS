using Microsoft.AspNetCore.Identity;
using SpeakerManagementSystem.DatabaseContext;
using SpeakerManagementSystem.Models.Common;
using SpeakerManagementSystem.Repository.Interface;
using SpeakerManagementSystem.ViewModel;

namespace SpeakerManagementSystem.Repository
{
    public class AuthRepository : IAuthRepository
    {
        #region Private
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        #endregion

        #region Constructor
        public AuthRepository(
            SpeakerMgmtDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion

        #region Public
        public async Task<bool> AuthenticateUser(Login model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        #endregion
    }
}
