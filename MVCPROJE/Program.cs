using Microsoft.EntityFrameworkCore;
using MVCPROJE.Context;
using Microsoft.AspNetCore.Identity;
using MVCPROJE.Data;
using MVCPROJE.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MVCPROJE.Context.UygulamaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(("BaglantiCumlem"))));
builder.Services.AddDbContext<UygulamaDbContext>();
builder.Services.AddDefaultIdentity<Kullanici>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MVCPROJE.Context.UygulamaDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
