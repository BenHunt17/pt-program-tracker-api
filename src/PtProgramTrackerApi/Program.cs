using PtProgramTrackerApi.Application.Services;
using PtProgramTrackerApi.DataPersistence;
using PtProgramTrackerApi.DataPersistence.DataAccess;
using PtProgramTrackerApi.Domain.Interfaces.DataAccess;
using PtProgramTrackerApi.Domain.Interfaces.Services;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddScoped<DataContext, DataContext>();

builder.Services.AddScoped<IClientDataAccess, ClientDataAccess>();
builder.Services.AddScoped<IExerciseDataAccess, ExerciseDataAccess>();
builder.Services.AddScoped<IProgramDataAccess, ProgramDataAccess>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IProgramService, ProgramService>();

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            var origins = builder.Configuration["Cors:AllowedOrigins"]?.Split(";") ?? [];
            policy.WithOrigins(origins)
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
