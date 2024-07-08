using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.IO;
using ActivosControles.Data;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Headers;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.TryAddSingleton<IReportServiceConfiguration>(sp => new ReportServiceConfiguration
{
	ReportingEngineConfiguration = sp.GetService<IConfiguration>(),
	HostAppId = "BlazorReportViewerDemo",
	Storage = new FileStorage(),
	ReportSourceResolver = new UriReportSourceResolver(
		System.IO.Path.Combine(GetReportsDir(sp)))
});


// Add services to the container.
builder.Services.AddRazorPages().AddNewtonsoftJson();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddHttpClient("BinaryEdgeClient", client =>
{
    client.BaseAddress = new Uri("https://api.binaryedge.io/v2/query/domains/subdomain/");
    client.DefaultRequestHeaders.Add("X-Key", "356ec725-b020-4a7b-8d7d-d15101b95f9b"); 
});

builder.Services.AddHttpClient("VirusTotalClient", client =>
{
    client.BaseAddress = new Uri("https://www.virustotal.com/api/v3/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("X-Apikey", "ef07469d348e5bcae004389cd3ec91fced81f7570dc1336dd2e7f2bc0a0ce213"); // Reemplaza con tu clave de API
});







var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
	// ... 
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
// Ensure /login is the default route
app.MapGet("/", context =>
{
    context.Response.Redirect("/login");
    return Task.CompletedTask;
});
app.Run();

static string GetReportsDir(IServiceProvider sp)
{
	return Path.Combine(sp.GetService<IWebHostEnvironment>().ContentRootPath, "Reports");
}
