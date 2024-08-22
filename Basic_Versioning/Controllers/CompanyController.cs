using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Basic_Versioning.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CompanyController : ControllerBase
{
	[HttpPut]
	public ActionResult<string> SetCompany(string companyName)
	{
		return Ok($"Company name: {companyName} was set.");
	}

	[HttpPut]
	public ActionResult<string> SetCompany20240100(string companyName, string companyRegion)
	{
		return Ok($"Company name: {companyName} in region: {companyRegion} was set.");
	}

	[HttpGet]
	public ActionResult<Company> ReadCompanyInfo()
	{
		var readCompanyInfo = Company.ReadCompanyInfo();
		return Ok(readCompanyInfo);
	}

	[HttpGet]
	public ActionResult<Company20240100> ReadCompanyInfo20240100()
	{
		var readCompanyInfo = Company20240100.ReadCompanyInfo();
		return Ok(readCompanyInfo);
	}
}