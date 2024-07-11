using SimpleList;
var service = new SimpleListService();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapPost("/Kata21Api/Add", (string input) =>
{
    service.Add_S(input);
    return Results.Created();
})
.WithName("Add")
.WithOpenApi();

app.MapPost("/Kata21Api/Delete", (string input) =>
{
    service.Delete_S(input);
    return Results.NoContent();
})
.WithName("Delete")
.WithOpenApi();

app.MapGet("/Kata21Api/Display", () =>
{
    return service.Display_S();
})
.WithName("Display")
.WithOpenApi();

app.Run();


