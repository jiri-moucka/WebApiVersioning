using Contracts20240100;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Controllers20240100.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CompanyController : ControllerBase
{
	[HttpPut]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[SwaggerOperation(Tags = ["Company version 20240100"])]
	public ActionResult<string> SetCompanyName(string companyName)
	{
		return Ok($"Company name {companyName} was set.");
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[SwaggerOperation(Tags = ["Company version 20240100"])]
	public ActionResult<CompanyInformation> ReadCompanyInfo()
	{
		var readCompanyInfo = OpenApiClients20240100.CompanyOpenApiClient.ReadCompanyInfo();
		return Ok(readCompanyInfo);
	}
}