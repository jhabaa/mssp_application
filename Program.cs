using Microsoft.AspNetCore.Mvc.RazorPages;
using mssp_application.Components;

var builder = WebApplication.CreateBuilder(args);

//Load envs datas ( for Github actions)
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Mongo DB conneection & datas as a singleton service. 
// Then you can inject it into your components or pages.
builder.Services.AddSingleton<MongoConnection>();

//Launch app on port 5010
builder.WebHost.UseUrls("http://0.0.0.0:5010");

if(builder.Environment.IsDevelopment())
{
    // In development, load secrets from user secrets here
    // Load secrets from environment variables
    builder.Configuration.AddUserSecrets<Program>(optional: true);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
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
