var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Respond to HTTP GET /
app.MapGet("/", () => "Hello World! welcome to gopi");

app.Run();
