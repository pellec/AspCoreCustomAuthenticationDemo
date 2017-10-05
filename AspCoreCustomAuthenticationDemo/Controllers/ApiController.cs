using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuthenticationDemo.Controllers
{
	[Route("api")]
	public class ApiController : Controller
	{
		[Authorize(ActiveAuthenticationSchemes = Authentication.Scheme.Custom)]
		public IActionResult Get()
		{
			return Ok($"Hello {User.Identity.Name}!");
		}
	}
}