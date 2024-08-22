#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Attributes_Versioning.Controllers.V3;

public record CompanyModel
{
	public string Name { get; init; } = "Ciklum";
	public string City { get; init; } = "Zlín";
	public string Region { get; init; } = "Valašsko";

	public static CompanyModel ReadCompanyInfo()
	{
		return new CompanyModel();
	}
}