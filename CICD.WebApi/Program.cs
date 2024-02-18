using CICD.Application.Extension;
using CICD.Application.Features.AddNewUser;
using CICD.Application.Features.DeleteUserHandler;
using CICD.Application.Features.GetUserById;
using CICD.Application.Features.SearchUsers;
using CICD.Application.Features.UpdateUser;
using CICD.Domain.Models;
using CICD.Infrastructure.CosmosDb.Extension;
using CIDI_practice.Extension;
using Microsoft.AspNetCore.Mvc;

foreach (var arg in args)
{
    Console.WriteLine(arg);
}

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntryArguments(args);
builder.Services.AddFeatureApplicationHandlers();
builder.Services.AddRepositories();
builder.Services.AddCors();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x =>
{
    x.AllowAnyHeader();
    x.AllowAnyMethod();
    x.AllowAnyOrigin();
});
app.UseHttpsRedirection();
app.MapPost("/add-user",
    async ([FromBody] AddNewUserRequest req, [FromServices] AddNewUserHandler handler) => await handler.Handle(req));

app.MapGet("/search/{id}", async (
        string id,
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
app.MapDelete("/user/{id}", async (string id, DeleteUserHandler handler) => await handler.Handle(id));
app.MapGet("/", () => @"<h1>HELLO FROM WEB API<\h1>");
app.Run();