using Microsoft.AspNetCore.Mvc;
using SpeakerManagementSystem.DatabaseContext;
using SpeakerManagementSystem.Models;
using SpeakerManagementSystem.Repository.Interface;
using SpeakerManagementSystem.ViewModel.Common;

namespace SpeakerManagementSystem.Controllers
{
	public class OrganizationController : Controller
	{
		#region Private
		private readonly IOrganizationRepository _organizationRepository;
		#endregion

		#region Constructor
		public OrganizationController(IOrganizationRepository organizationRepository)
		{
			_organizationRepository = organizationRepository;
		}
		#endregion

		#region Public
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetAllOrganization()
		{
			try
			{
				return Json(await _organizationRepository.GetAll());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				throw;
			}
		}

		public async Task<IActionResult> GetOrganizationById(int id)
		{
			try
			{
				return Json(await _organizationRepository.Get(x => x.Id == id));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateOrganization(Organization model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _organizationRepository.Add(model);
					await _organizationRepository.SaveChangesAsync ();
					return Json(FormResult.Success());
				}
				return Json(FormResult.Error(ModelState));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> EditOrganization(Organization model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _organizationRepository.Update(model);
					await _organizationRepository.SaveChangesAsync();
					return Json(FormResult.Success());
				}
				return Json(FormResult.Error(ModelState));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				throw;
			}
		}


		public async Task<IActionResult> DeleteOrganization(int id)
		{
			try
			{
				await _organizationRepository.Remove(x => x.Id == id);
				await _organizationRepository.SaveChangesAsync();
				return Json(FormResult.Success());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				throw;
			}
		}
		#endregion
	}
}
