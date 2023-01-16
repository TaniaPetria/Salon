using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Salon.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(
    options => {
        options.Conventions.AuthorizeFolder("/Programari");
        options.Conventions.AuthorizeFolder("/Clienti");
        options.Conventions.AuthorizeFolder("/ProgramariClienti");
        options.Conventions.AllowAnonymousToPage("/ProgramariClienti/Index");
        options.Conventions.AllowAnonymousToPage("/ProgramariClienti/SelectAngajat");
        options.Conventions.AllowAnonymousToPage("/ProgramariClienti/SelectServiciu");
        options.Conventions.AllowAnonymousToPage("/ProgramariClienti/SelectProgramare");
        options.Conventions.AuthorizeFolder("/ProgramariClienti/Salvare");


    });
builder.Services.AddDbContext<SalonContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SalonContext") ?? throw new InvalidOperationException("Connection string 'SalonContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SalonContext") ?? throw new InvalidOperationException("Connection string 'SalonContext' not found.")));



builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
