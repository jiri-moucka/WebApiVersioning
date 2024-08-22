#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Attributes_Versioning.Controllers.V1;

public record CompanyModel
{
	public string Name { get; init; } = "Ciklum";
	public string City { get; init; } = "Zlín";

	public static CompanyModel ReadCompanyInfo()
	{
		return new CompanyModel();
	}
}