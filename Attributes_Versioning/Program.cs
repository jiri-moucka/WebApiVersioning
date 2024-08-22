using Asp.Versioning;
using Attributes_Versioning;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services
	.AddApiVersioning(options =>
	{
		options.DefaultApiVersion = new ApiVersion(1, 0);
		options.AssumeDefaultVersionWhenUnspecified = false;
		options.ReportApiVersions = true;
		options.UnsupportedApiVersionStatusCode = 501;
	})
	.AddApiExplorer(options =>
	{
		options.GroupNameFormat =
			"'v'VVV"; // add the versioned api explorer, which also adds IApiVersionDescriptionProvider servicenote: the specified format code will format the version as "'v'major[.minor][-status]"
		options.SubstituteApiVersionInUrl =
			true; // note: this option is only necessary when versioning by url segment. the SubstitutionFormat can also be used to control the format of the API version in route templates
	});

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
	options.OperationFilter<SwaggerDefaultValues>(); // add a custom operation filter which sets default values

	var fileName = $"{typeof(Program).Assembly.GetName().Name}.xml";
	var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
	// integrate xml comments
	options.IncludeXmlComments(filePath);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
	var apiVersionDescriptions = app.DescribeApiVersions();

	foreach (var apiVersionDescription in apiVersionDescriptions)
	{
		var url = $"/swagger/{apiVersionDescription.GroupName}/swagger.json";
		var name = apiVersionDescription.GroupName.ToUpperInvariant();
		options.SwaggerEndpoint(url, name);
	}
});

app.UseHttpsRedirection();
// app.UseRouting();

app.MapControllers();

app.Run();