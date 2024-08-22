using Contracts20240200;
using OpenApiClients20240200;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Controllers20240200.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CompanyController : ControllerBase
{
	[HttpPut]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[SwaggerOperation(Tags = ["Company version 20240200"])]
	public ActionResult<string> SetCompanyName(string companyName)
	{
		return Ok($"Company name {companyName} was set.");
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[SwaggerOperation(Tags = ["Company version 20240200"])]
	public ActionResult<CompanyInformation> ReadCompanyInfo()
	{
		var readCompanyInfo = CompanyOpenApiClient.ReadCompanyInfo();
		return Ok(readCompanyInfo);
	}
}