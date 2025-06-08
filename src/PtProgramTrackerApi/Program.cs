using PtProgramTrackerApi.Application.Services;
using PtProgramTrackerApi.DataPersistence;
using PtProgramTrackerApi.Domain.Interfaces.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<DataContext, DataContext>();

builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
