using CICD.Application.Extension;
using CICD.Application.Features.AddNewUser;
using CICD.Infrastructure.CosmosDb.Extension;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFeatureApplicationHandlers();
builder.Services.AddRepositories();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/add-user", 
    async ([FromBody] AddNewUserRequest req, [FromServices]AddNewUserHandler handler) => await handler.Handle(req));

app.Run();
