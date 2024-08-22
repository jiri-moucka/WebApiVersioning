using VersionsOrchestrator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.CustomSchemaIds(type => type.FullName);
	options.EnableAnnotations();
});

builder.Services.AddControllers(options => { options.Conventions.Add(new NamespaceRoutingConvention()); });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();