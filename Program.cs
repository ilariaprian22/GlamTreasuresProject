using Microsoft.AspNetCore.Identity;
using GlamTreasures.Data;
using GlamTreasures.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();

// Configure the GlamTreasuresContext with transient error resiliency
builder.Services.AddDbContext<GlamTreasuresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GlamTreasuresContext"))
           .EnableRetryOnFailure());

// Configure Identity services
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<GlamTreasuresContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

var app = builder.Build();

// Configure the HTTP request pipeline
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

// Seed admin user
await AdminSeedService.SeedAdminUser(app.Services);

app.Run();