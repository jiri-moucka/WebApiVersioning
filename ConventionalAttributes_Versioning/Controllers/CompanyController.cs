using Asp.Versioning;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConventionalAttributes_Versioning.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/[controller]/[action]")]
// [Route("api/v{version:apiVersion}/[controller]/[action]")]
public class CompanyController : ControllerBase
{
	[HttpPut]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public ActionResult<string> SetCompanyName(string companyName)
	{
		return Ok($"Company name {companyName} was set.");
	}

	[HttpGet]
	[MapToApiVersion("1.0")]
	public ActionResult<Company> ReadCompanyInfoV1()
	{
		var readCompanyInfo = Company.ReadCompanyInfo();
		return Ok(readCompanyInfo);
	}

	[HttpGet]
	[MapToApiVersion("2.0")]
	public ActionResult<Company> ReadCompanyInfoV2()
	{
		var readCompanyInfo = Company.ReadCompanyInfo();
		return Ok(readCompanyInfo);
	}
}