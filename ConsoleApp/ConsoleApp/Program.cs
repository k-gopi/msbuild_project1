using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Allow serving static files (like HTML, CSS, JS)
builder.Services.AddDirectoryBrowser();

// Listen on all network interfaces
builder.WebHost.UseUrls("http://0.0.0.0:80");

var app = builder.Build();

// Serve static files from wwwroot
app.UseDefaultFiles();  // Automatically looks for index.html or login.html
app.UseStaticFiles();

// Optional: redirect root to /login.html
app.MapGet("/", context =>
{
    context.Response.Redirect("/login.html");
    return Task.CompletedTask;
});

// Handle login POST
app.MapPost("/login", async (HttpContext context) =>
{
    var form = await context.Request.ReadFormAsync();
    var username = form["username"];
    var email = form["email"];
    var password = form["password"];

    // Dummy login validation (you can modify this logic as needed)
    if (username == "admin" && password == "pass123" && email == "admin@example.com")
    {
        return Results.Ok("✅ Login successful!");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();
