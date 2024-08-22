using Controllers20240100.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests20240100.Company;

public class ReadCompanyInfoTests
{
	[Fact]
	public void ReturnsOkResultWithValidCompanyInfo()
	{
		//Arrange
		var testCompany = new TestCompany { Name = "Ciklum", City = "Zlín" };
		var controller = new CompanyController();

		//Act
		var result = controller.ReadCompanyInfo();

		//Assert
		var okResponse = Assert.IsType<OkObjectResult>(result.Result);
		Assert.Equal(StatusCodes.Status200OK, okResponse.StatusCode);
		Assert.Equivalent(okResponse.Value, testCompany);
	}
}