using InfoSales.BusinessL;
using InfoSales.BusinessL.Interfaces;
using InfoSales.BusinessL.Repositories;
using InfoSales.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConn"));
});
builder.Services.AddRazorPages();
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
builder.Services.AddScoped<ICustomers, CustomerRepo>();
builder.Services.AddScoped<IUsers, UserRepo>();
builder.Services.AddScoped<IProducts, ProductRepo>();
builder.Services.AddScoped<IDashboardVM, DashboardVMRepo>();
builder.Services.AddScoped<ITransactions, TransactionRepo>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.LoginPath = "/";
        options.LogoutPath = "/";
        //options.AccessDeniedPath = new PathString("/UnAuthorize");
    });
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseCookiePolicy();

app.MapRazorPages();

app.Run();
