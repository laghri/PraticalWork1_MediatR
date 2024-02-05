using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FirstAppWorkHahn.Data;
using FirstAppWorkHahn.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System.Reflection;
using FirstAppWorkHahn.Repositores;
using FirstAppWorkHahn.Validators;
using FluentValidation;
using FirstAppWorkHahn.MediatR.Commands;
using FluentValidation.AspNetCore;
internal class Program
{
    [Obsolete]
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<FirstAppWorkHahnContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("FirstAppWorkHahnContext") ?? throw new InvalidOperationException("EmployesCs")));

        // Add services to the container.

        builder.Services.
             AddControllers()
            .AddFluentValidation(x =>
                  x.RegisterValidatorsFromAssemblyContaining<Program>()
                );


        builder.Services.AddScoped<IGenericRepository<Employes>, EmployesRepository>();
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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