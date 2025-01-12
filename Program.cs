using Microsoft.AspNetCore.Identity;
using GlamTreasures.Data;
using GlamTreasures.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<GlamTreasuresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GlamTreasuresContext"),
        sqlServerOptionsAction: sqlOptions => sqlOptions.EnableRetryOnFailure()));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<GlamTreasuresContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

await AdminSeedService.SeedAdminUser(app.Services);

app.Run();