using ExampleWebApiCore.Core.Services.IRepository;
using ExampleWebApiCore.Core.Services.Repository;
using ExampleWebApiCore.Core.Utilities.UtilitiServices.IRepository;
using ExampleWebApiCore.Core.Utilities.UtilitiServices.Repository;
using ExampleWebApiCore.DataLayer.Context;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
})
    //for use newtonSoftJson (serialize,deserialize)
    .AddNewtonsoftJson()
    //for get xml to outpt api
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region ConnectToSqlServer
builder.Services.AddDbContext<ExampleWebApiContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExampleWebApiConnection"));
});
#endregion

#region JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    });
#endregion

#region IOC
builder.Services.AddTransient<IUtilitiesRepository, UtilitiesRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<ISendCodeRepository, SendCodeRepository>();
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
