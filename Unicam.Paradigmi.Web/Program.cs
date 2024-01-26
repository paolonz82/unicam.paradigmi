using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Middlewares;
using Unicam.Paradigmi.Models.Extensions;

using Unicam.Paradigmi.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// INIZIALIZZO I SERVIZI

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddModelServices(builder.Configuration);

var app = builder.Build();

//INIZIALIZZO I MIDDLEWARE

app.AddWebMiddleware()
    .AddApplicationMiddleware();

app.Run();
