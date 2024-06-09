using JobBoard.Web.Services;
using JobBoard.Web.Components;
using JobBoard.Web.Models;
using JobBoard.Web.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"])
});

builder.Services.AddScoped<ApiService<JobDto>>();
builder.Services.AddScoped<ApiService<LocationDto>>();
builder.Services.AddScoped<ApiService<LocationForPersonDto>>();
builder.Services.AddScoped<ApiService<CategoryDto>>();
builder.Services.AddScoped<ApiService<CompanyDto>>();
builder.Services.AddScoped<ApiService<PersonDto>>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
