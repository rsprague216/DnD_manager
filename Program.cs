using DnD_Manager.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CharacterContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("CharacterContext"),
        new MySqlServerVersion(new Version(8, 3, 0))));
// builder.Services.AddSingleton<MongoContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CharacterContext>();
    DbInitializer.Initialize(context);
    // var context = scope.ServiceProvider.GetRequiredService<CharacterContext>();
    // DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// app.UseStaticFiles();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
