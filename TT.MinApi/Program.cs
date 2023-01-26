using Microsoft.AspNetCore.Http.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TT.Repository;
using TT.Services;
using TT.Services.Interfaces;
using TT.Models.Models;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
var connectionString = builder.Configuration.GetConnectionString("GamesConnection") ?? "";
builder.Services.AddDIServices(connectionString);
builder.Services.AddScoped<IGameService, GameService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/Start", async (IGameService GameService, string gamerName) =>
{
    return await GameService.StartGame(gamerName);
});

app.MapPost("/MakeMove", async (HttpContext http, IGameService GameService, [AsParameters] MoveParameters moveParameters) =>
{
    var currentGame =await GameService.GetCurrentGame(true);
    if (currentGame == null || currentGame.EndDate != null)
    {
        return Results.BadRequest("Current Game not found, please start a new game");
    }
    var moveResponse = await GameService.MakeMove(moveParameters.Move, currentGame.Id);
    var moveWinner = (moveResponse.Winner == null) ? "Tie" : (moveResponse.Winner == false) ? "Human wins!" : "Computer wins!";
    var metadata = new
    {
        moveWinner = moveWinner,
    };
    http.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
    return Results.Ok(moveResponse);
}).WithOpenApi(generatedOperation =>
{
    var parameter = generatedOperation.Parameters[0];
    parameter.Description = "Enter the number [1,3] according your move: 1:Rock, 2:Paper, 3: Scissors";
    return generatedOperation;
});
app.MapPost("/End", async (HttpContext http, IGameService GameService) =>
{
    var gameResponse = await GameService.EndGame();
    var currentGame =await GameService.GetCurrentGame(false);
    if (currentGame == null)
    {
        return Results.BadRequest("Open Game not found, please start a new game");
    }
    var result = "Tie";
    if (currentGame != null && currentGame.HumanWins != null && currentGame.ComputerWins != null)
    {
        result = (currentGame.HumanWins > currentGame.ComputerWins) ? "Human wins!" : "Computer wins!";
        var metadata = new
        {
            currentGame.HumanWins,
            currentGame.ComputerWins,
            result = result,

        };
        http.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
    }
    return Results.Ok(gameResponse);
});
app.MapGet("/GetHistoricResults", (HttpContext http, IGameService GameService, [AsParameters] GameParameters GameParameters) =>
{
    var pagedPeople = GameService.HistoricResults(GameParameters);
    var metadata = new
    {
        pagedPeople.TotalCount,
        pagedPeople.PageSize,
        pagedPeople.CurrentPage,
        pagedPeople.TotalPages,
        pagedPeople.HasNext,
        pagedPeople.HasPrevious
    };
    http.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
    return Results.Ok(pagedPeople);
});


app.Run();

