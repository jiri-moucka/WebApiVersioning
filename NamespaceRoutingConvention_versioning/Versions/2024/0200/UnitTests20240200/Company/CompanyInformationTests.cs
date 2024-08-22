using Controllers20240200.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests20240200.Company;

public class CompanyInformationTests
{
	[Fact]
	public void SetNameAndReturnsOkResultWithValidValue()
	{
		// Arrange
		const string companyName = "TestCompanyName";
		var controller = new CompanyController();

		// Act
		var result = controller.SetCompanyName(companyName);

		// Assert
		var okResult = Assert.IsType<OkObjectResult>(result.Result);
		Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
		Assert.Equal($"Company name {companyName} was set.", okResult.Value);
	}
}