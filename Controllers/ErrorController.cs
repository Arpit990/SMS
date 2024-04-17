using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace SpeakerManagementSystem.Controllers
{
	public class ErrorController : Controller
	{
		[Route("Error/{statusCode}")]
		public IActionResult HttpStatusCodeHandler(int statusCode)
		{
			if (HttpContext != null)
			{
				var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
				ViewBag.Error = exceptionHandlerPathFeature.Error.Message;
				ViewBag.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;
			}

			switch (statusCode)
			{
				case 404:
					ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found.";
					break;
				// Handle other status codes as needed
				default:
					ViewBag.ErrorMessage = "An error occurred.";
					break;
			}
			return View("Error");
		}
	}
}
