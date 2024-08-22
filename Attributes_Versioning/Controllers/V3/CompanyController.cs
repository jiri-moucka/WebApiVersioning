using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Attributes_Versioning.Controllers.V3;

[ApiController]
[ApiVersion("3.0")]
// [Route("api/[controller]/[action]")]
[Route( "api/v{version:apiVersion}/[controller]/[action]" )]
public class CompanyController : ControllerBase
{
	[HttpPut]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public ActionResult<string> SetCompanyName(string companyName)
	{
		return Ok($"Company name {companyName} was set.");
	}

	[HttpGet]
	public ActionResult<CompanyModel> ReadCompanyInfo()
	{
		var readCompanyInfo = CompanyModel.ReadCompanyInfo();
		return Ok(readCompanyInfo);
	}
}