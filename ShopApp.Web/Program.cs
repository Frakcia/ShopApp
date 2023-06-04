using FluentValidation.AspNetCore;
using ShopApp.Web.StartupConfigurations;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
//// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());


builder.Services
  .AddSwagger()
  .AddDependecyInjectionContainers(configuration);
  //.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
