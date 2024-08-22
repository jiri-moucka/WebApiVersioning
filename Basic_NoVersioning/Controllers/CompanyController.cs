using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Basic_NoVersioning.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CompanyController : ControllerBase
{
	[HttpPut]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public ActionResult<string> SetCompanyName(string companyName)
	{
		return Ok($"Company name {companyName} was set.");
	}
	
	[HttpGet]
	public ActionResult<Company> ReadCompanyInfo()
	{
		var readCompanyInfo = Company.ReadCompanyInfo();
		return Ok(readCompanyInfo);
	}
}