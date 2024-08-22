using Contracts20240200;

namespace OpenApiClients20240200;

public abstract class CompanyOpenApiClient
{
	public static CompanyInformation ReadCompanyInfo()
	{
		return new CompanyInformation
		{
			Name = "Ciklum",
			City = "Zlín"
		};
	}
}