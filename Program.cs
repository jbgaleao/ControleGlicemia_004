using ControleGlicemia_002.Context;
using ControleGlicemia_002.Mappers;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GlicemiaContext>(opt => opt
    .UseSqlServer(builder.Configuration
    .GetConnectionString("GlicemiaConn")));
builder.Services.AddAutoMapper(typeof(GlicemiaMapper));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Glicemias}/{action=Index}/{id?}");

app.Run();
