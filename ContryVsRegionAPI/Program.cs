
using AutoMapper;
using ContryVsRegionAPI.Contex;
using ContryVsRegionAPI.DTO;
using ContryVsRegionAPI.Halper;
using ContryVsRegionAPI.Models;
using ContryVsRegionAPI.Repostory;
using ContryVsRegionAPI.Servics;
using Microsoft.EntityFrameworkCore;
using ContryVsRegionAPI.Controllers;
using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddControllersWithViews()
                        .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    );
        builder.Services.AddDbContext<AppDbContext>(p => p.UseNpgsql(builder.Configuration.GetConnectionString("Defaultconnection")));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddTransient<ICountryRepostory<Country>, CountryRepostory>();
        builder.Services.AddTransient<ICountryServics<Country, CountryDTO>, CountryServices>();
        builder.Services.AddTransient<ICountryRepostory<Region>, RegionRepostory>();
        builder.Services.AddTransient<ICountryServics<Region, RegionDTO>, RegionServices>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();


        app.Run();
    }
}