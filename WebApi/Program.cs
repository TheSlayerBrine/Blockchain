using System.Text;
using Blockchain.Data.Infrastructure.UnitOfWork;
using Blockchain.Data.Repositories;
using Blockchain.Services.Service.Common.Auth;
using BlockChain.Data.Infrastructure.Context;
using Blockchain.Services.Service.Accounts;
using Blockchain.Services.Service.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer((x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = config["Jwt:Issuer"],
                ValidAudience = config["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(config["Jwt:Key"])),
            };
        }
    ));
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("Blockchain");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebApi")));
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<INftRepository, NftRepository>();
builder.Services.AddScoped<ITransactionContractRepository, TransactionContractRepository>();
builder.Services.AddScoped<ITransactionPurchaseRepository, TransactionPurchaseRepository>();
builder.Services.AddScoped<ISmartContractRepository, SmartContractRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAccountService, AccountService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
