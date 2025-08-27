using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rplace.Models;
using Rplace.Services.JWT;
using Rplace.Services.Password;
using Rplace.Services.Profiles;
using Rplace.UseCase.AcceptInvite;
using Rplace.UseCase.ColorPixel;
using Rplace.UseCase.CreateRoom;
using Rplace.UseCase.EditProfile;
using Rplace.UseCase.GetInvite;
using Rplace.UseCase.GetPixel;
using Rplace.UseCase.GetPlan;
using Rplace.UseCase.GetPlayer;
using Rplace.UseCase.GetProfile;
using Rplace.UseCase.GetRoom;
using Rplace.UseCase.InvitePlayer;
using Rplace.UseCase.Login;
using Rplace.UseCase.PromotePlayer;
using Rplace.UseCase.RemovePlayer;
using Rplace.UseCase.UpgradePlan;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<rplaceDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

builder.Services.AddTransient<IPasswordService, PBKDF2PasswordService>();
builder.Services.AddTransient<IProfileService, EFProfileService>();
builder.Services.AddSingleton<IJWTService, JWTService>();

builder.Services.AddTransient<AcceptInviteUseCase>();
builder.Services.AddTransient<ColorPixelUseCase>();
builder.Services.AddTransient<CreateProfileUseCase>();
builder.Services.AddTransient<CreateRoomUseCase>();
builder.Services.AddTransient<EditProfileUseCase>();
builder.Services.AddTransient<GetInviteUseCase>();
builder.Services.AddTransient<GetPixelUseCase>();
builder.Services.AddTransient<GetPlanUseCase>();
builder.Services.AddTransient<GetPlayerUseCase>();
builder.Services.AddTransient<GetProfileUseCase>();
builder.Services.AddTransient<GetRoomUseCase>();
builder.Services.AddTransient<InvitePlayerUseCase>();
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<PromotePlayerUseCase>();
builder.Services.AddTransient<RemovePlayerUseCase>();
builder.Services.AddTransient<UpgradePlanUseCase>();

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "rplace-app",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

var app = builder.Build();

app.Run();