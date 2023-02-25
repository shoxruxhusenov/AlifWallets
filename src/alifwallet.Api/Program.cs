using alifwallet.Api.Configurations;
using alifwallet.Api.Middlewares;
using alifwallet.Service.Interfaces;
using alifwallet.Service.Repositories;
using alifwallet.Service.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IXAuthorize,XAuthorize>();
builder.Services.AddScoped<IWalletService, WalletService>();

builder.ConfigureDataAccess();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
