var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// app.MapGet("/", () => "Hello World!")
// 	.WithName("GetHelloWorld")
// 	.WithTags("Greetings");

app.MapGet("/api/greet1", (string name) => $"Hello {name}!")
	.WithName("GreetPerson1")
	.WithTags("Greetings")
	.Produces<string>(StatusCodes.Status200OK);

app.MapGet("/api/greet2", (string name) => $"Hello {name}!")
	.WithName("GreetPerson2")
	.WithTags("Greetings")
	.Produces<string>(StatusCodes.Status200OK);

app.MapGet("/api/greet3", (string name) => $"Hello {name}!")
	.WithName("GreetPerson3")
	.WithTags("Greetings2")
	.Produces<string>(StatusCodes.Status200OK);

app.MapGet("/api/greet4", (string name) => $"Hello {name}!")
	.WithName("GreetPerson4")
	.WithTags("Greetings2")
	.Produces<string>(StatusCodes.Status200OK);

app.Run();