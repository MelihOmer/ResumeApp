using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using ResumeApp.Core.Entities.Identity;
using ResumeApp.Repository;
using ResumeApp.Service.Extensions;
using ResumeApp.Web.ActionFilters;
using ResumeApp.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddServicesAndRepositoryLoad();
builder.Services.IocLoadWeb();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddCustomAutoMapper();
builder.Services.AddCustomFluentValidation();
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 4;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddErrorDescriber<IdentityErrorDescriber>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "ResumeApp";
    opt.ExpireTimeSpan = TimeSpan.FromDays(5);
    opt.LoginPath = new PathString("/Account/Login");
});
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 3;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
    config.HasRippleEffect = true;
});


builder.Services.AddScoped(typeof(ModelStateFilter<>));


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

app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=panel}/{action=index}/{id?}");

app.Run();
