using ApplicationCore.Entities.Concrete;
using ApplicationCore.Interfaces;
using AutoMapper;
using Infrastructure.AutoMapper;
using Infrastructure.Context;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new Mapping());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);



//2 tane database'i json dosyasına gönderdik.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionStringIdentity = builder.Configuration.GetConnectionString("IdentityConnection");


// infrastructure'ı bilgeadam/dependencies sağ tıkla seç ve ekle
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddDbContext<StoreIdentityDbContext>(options =>
{
    options.UseSqlServer(connectionStringIdentity);
});



builder.Services.AddIdentity<ApplicationUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedPhoneNumber = false;
    x.SignIn.RequireConfirmedEmail = false;
    x.SignIn.RequireConfirmedAccount = false;
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 1;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireLowercase = false;
})
    .AddEntityFrameworkStores<StoreIdentityDbContext>()
    .AddDefaultTokenProviders();

// her seferinde yeniden oluştur ve sil: interface ve classlar birbirine bağlı ise. Yaşam döngüsü
builder.Services.AddScoped(typeof(IRepositoryService<>), typeof(EfRepository<>));
builder.Services.AddScoped<IMovieCategoryService, MovieCategoryService>();
builder.Services.AddScoped<IDirectorService, DirectorService>();



//add - migration InitialCreate -context AppDbContext -outputdir Context / Migrations


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


// authentication eklemeyi unutma
app.UseAuthentication();
app.UseAuthorization();


// areas ekledikten sonra bu hale getiriyoruz; program.cs'i.
app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    
app.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
