namespace Contracts;

public record Company20240100
{
	public string Name { get; init; } = "Ciklum";
	public string City { get; init; } = "Zlín";
	public string Region { get; init; } = "Valašsko";

	public static Company20240100 ReadCompanyInfo()
	{
		return new Company20240100();
	}
}