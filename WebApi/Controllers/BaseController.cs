using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class BaseController : ControllerBase
	{
	}
}
