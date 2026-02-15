using DnD_Manager.Components;
using DnD_Manager.Data;
using DnD_Manager.Models;
using DnD_Manager.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Blazor Server services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Database context
builder.Services.AddDbContext<CharacterContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("CharacterContext"),
        new MySqlServerVersion(new Version(8, 3, 0))));

// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<CharacterContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/login";
});

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorization();

// Stub email sender
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, StubEmailSender>();

// Application services
builder.Services.AddScoped<CharacterService>();

var app = builder.Build();

// Apply migrations and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CharacterContext>();
    context.Database.Migrate();
    await DbInitializer.InitializeAsync(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
