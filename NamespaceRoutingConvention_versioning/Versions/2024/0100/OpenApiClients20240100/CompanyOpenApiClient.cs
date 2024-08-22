using Contracts20240100;

namespace OpenApiClients20240100;

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