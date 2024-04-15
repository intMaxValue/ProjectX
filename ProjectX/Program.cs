using ProjectX.Core.Hubs;
using ProjectX.Extensions;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddApplicationDbContext(builder.Configuration);

builder.Services.AddApplicationServices("6863376da90e549");

builder.Services.AddControllersWithViews();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

    // Seed Admin
    SeedRoles.SeedAdministrator(app);

    // Seed salon owners
    SeedRoles.SeedSalonOwners(app);

    // Seed regular users
    SeedRoles.SeedUsers(app);
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    //Admin
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "Error",
        pattern: "/Error/{statusCode}",
        defaults: new { controller = "Error", action = "Error" });

    endpoints.MapControllerRoute(
        name: "salon",
        pattern: "Salon",
        defaults: new { controller = "MySalon", action = "Index" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapHub<ChatHub>("/chatHub");

});




app.MapRazorPages();

app.Run();
