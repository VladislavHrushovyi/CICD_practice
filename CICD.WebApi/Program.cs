using CICD.Application.Extension;
using CICD.Application.Features.AddNewUser;
using CICD.Application.Features.GetUserById;
using CICD.Application.Features.SearchUsers;
using CICD.Application.Features.UpdateUser;
using CICD.Domain.Models;
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
    async ([FromBody] AddNewUserRequest req, [FromServices] AddNewUserHandler handler) => await handler.Handle(req));

app.MapGet("/search/{id}", async (
        [FromQuery] string id,
        [FromServices] GetUserByIdHandler handler)
    => await handler.Handle(id));

app.MapGet("/search", async (
    [FromQuery] string name,
    [FromQuery] string surname,
    [FromServices] SearchUserHandler handler
) => await handler.Handle(new SearchUserRequest() { Name = name, Surname = surname }));

app.MapPatch("/{id}", async (
        [FromQuery]string id, 
        [FromBody]User req, 
        [FromServices]UpdateUserHandler handler)
    => await handler.Handle(id, req));

app.MapGet("/", () => "Hello from CICD");
app.Run();