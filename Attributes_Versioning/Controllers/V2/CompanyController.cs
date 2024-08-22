using Asp.Versioning;
using Attributes_Versioning.Controllers.V1;
using Contracts;
using Microsoft.AspNetCore.Mvc;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Attributes_Versioning.Controllers.V2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/[controller]/[action]")]
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