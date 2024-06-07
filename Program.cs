using System.Text.Json.Serialization;
using IndieWorld;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using IndieWorld.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddNpgsql<IndieWorldDbContext>(builder.Configuration["IndieWorldDbConnectionString"]);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:5003")
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

UserApi.Map(app);
PromotionApi.Map(app);
ShowApi.Map(app);
PerformerApi.Map(app);
RoleApi.Map(app);
FilterSearchApi.Map(app);
PromotionPicApi.Map(app);

app.Run();
