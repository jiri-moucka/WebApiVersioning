namespace Contracts20240200;

public sealed record CompanyInformation
{
	public required string Name { get; init; }
	public required string City { get; init; }
}