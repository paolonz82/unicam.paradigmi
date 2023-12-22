
using Microsoft.AspNetCore.Builder;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Middlewares;
using Unicam.Paradigmi.Application.Options;
using Unicam.Paradigmi.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// INIZIALIZZO I SERVIZI
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped< IAziendaService, AziendaService >();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
