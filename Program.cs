using Microsoft.AspNetCore.Mvc.RazorPages;
using mssp_application.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Add Mongo DB conneection & datas as a singleton service. 
// Then you can inject it into your components or pages.
builder.Services.AddSingleton<MongoConnection>();
//Launch app on port 5010
builder.WebHost.UseUrls("http://0.0.0.0:5010");

var app = builder.Build();

// Load secrets from environment variables
builder.Configuration.AddUserSecrets<Program>(optional: true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Load secrets from environment variables
    builder.Configuration.AddUserSecrets<Program>(optional: true);
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
