
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Middlewares;
using Unicam.Paradigmi.Application.Options;
using Unicam.Paradigmi.Application.Services;
using Unicam.Paradigmi.Application.Validators;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// INIZIALIZZO I SERVIZI
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(
    AppDomain.CurrentDomain.GetAssemblies().
           SingleOrDefault(assembly => assembly.GetName().Name == "Unicam.Paradigmi.Application")
    );


builder.Services.AddDbContext<MyDbContext>(conf=>
{
    conf.UseSqlServer("data source=localhost;Initial catalog=paradigmi;User Id=paradigmi;Password=paradigmi;TrustServerCertificate=True");
});
builder.Services.AddScoped< IAziendaService, AziendaService >();
builder.Services.AddScoped<AziendaRepository>();
builder.Services.AddScoped<ITokenService,TokenService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        string key = "Unicam.ParadigmiChiave1234567890123";
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key)
            );
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://paradigmi.unicam.it",
            IssuerSigningKey  = securityKey
        };
        options.Events = new JwtBearerEvents()
        {
            OnAuthenticationFailed = onAuthFailed
        };
    });

Task onAuthFailed(AuthenticationFailedContext context)
{
    return Task.CompletedTask;
}

//Prendo il singolo valore
string host = builder.Configuration
    .GetValue<string>("EmailOption:Host");
//Prendo un oggetto e lo bindo alla sezione una tantum
var emailOption = new EmailOption();
builder.Configuration.GetSection("EmailOption")
    .Bind(emailOption);
//Pattern Options : Prendo l'oggetto e lo dichiaro come servizio
builder.Services.Configure<EmailOption>(
    builder.Configuration.GetSection("EmailOption")
    );
var app = builder.Build();

//INIZIALIZZO I MIDDLEWARE

app.UseMiddleware<MiddlewareExample>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (HttpContext context, Func<Task> next) =>
{
    //await context.Response.WriteAsync("Prova");
    await next.Invoke();
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
