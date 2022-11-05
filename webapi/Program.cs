using webapi.Data;
using Microsoft.EntityFrameworkCore;
using webapi.Services;
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

// <Auth>
builder.Services.AddAuthentication(TokenAuthenticationSchemeOptions.Name)
.AddScheme<TokenAuthenticationSchemeOptions, TokenAuthenticationHandler>(TokenAuthenticationSchemeOptions.Name, option => {});

builder.Services.AddScoped<UserRegisterService>();
builder.Services.AddScoped<UserLoginService>();
builder.Services.AddScoped<UserConfirmationService>();
builder.Services.AddScoped<UserCheckpointService>();
// </Auth>

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
