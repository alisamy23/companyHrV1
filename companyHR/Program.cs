using company.BL.Interface;
using company.BL.Mapper;
using company.BL.Repository;
using company.DAL.Entity;
using company.DAL.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CompanyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyConnectionString"));
});
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));


//add scoped
builder.Services.AddScoped<IDepartmentRep, departmentRep>();
builder.Services.AddScoped<IJobRep, JobRep>();
builder.Services.AddScoped<IBonusRep, BonusRep>();
builder.Services.AddScoped<IVacationRep, VacationRep>();
builder.Services.AddScoped<IGenderRep, GenderRep>();
builder.Services.AddScoped<IReligionRep, ReligionRep>();
builder.Services.AddScoped<IEmployeeRep, EmployeeRep>();
builder.Services.AddScoped<IEmployeeBounsRep, EmployeeBounsRep>();
builder.Services.AddScoped<IEmployeesVacationRep, EmployeesVacationRep>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
