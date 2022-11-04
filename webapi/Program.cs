using webapi.Data;
using Microsoft.EntityFrameworkCore;
using webapi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using webapi.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("ShifterrConnectionString");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(
    JwtBearerDefaults.AuthenticationScheme,
    options => options.TokenValidationParameters = new TokenValidationParameters 
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value)),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidateAudience = true,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
    }
);

builder.Services.AddScoped<UserRegisterService>();
builder.Services.AddScoped<UserLoginService>();
builder.Services.AddScoped<UserConfirmationService>();
builder.Services.AddScoped<UserInfoHelperService>();
builder.Services.AddScoped<EmailService>();

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
