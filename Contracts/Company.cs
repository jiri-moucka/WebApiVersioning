namespace Contracts;

public record Company
{
	public string Name { get; init; } = "Ciklum";
	public string City { get; init; } = "Zlín";

	public static Company ReadCompanyInfo()
	{
		return new Company();
	}
}