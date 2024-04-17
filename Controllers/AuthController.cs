using Microsoft.AspNetCore.Mvc;
using SpeakerManagementSystem.Repository.Interface;
using SpeakerManagementSystem.ViewModel;

namespace SpeakerManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        #region Private
        private readonly IAuthRepository _authRepository;
        #endregion

        #region Constructor
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        #endregion

        #region Public
        public IActionResult Login() => View(new Login());

        public IActionResult AccessDenied() => View();

        [HttpPost]
        public async Task<IActionResult> Login(Login login, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var isAuthenticate = await _authRepository.AuthenticateUser(login);

                if (isAuthenticate)
                {
                    return returnUrl != null ? LocalRedirect(returnUrl) : RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["Error"] = "Wrong credentials. Please, try again!";
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(login);
        }
        #endregion
    }
}
