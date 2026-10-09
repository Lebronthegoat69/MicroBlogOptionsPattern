
using MicroBlog.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure site settings from appsettings.json
builder.Services.Configure<SiteOptions>(
    builder.Configuration.GetSection("SiteOptions"));

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();