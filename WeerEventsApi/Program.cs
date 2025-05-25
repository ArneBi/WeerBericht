using WeerEventsApi.Facade.Controllers;
using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Factories;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Steden.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<IMetingLogger>(MetingLoggerFactory.Create(true,true));
builder.Services.AddSingleton<IStadRepository, StadRepository>();
builder.Services.AddSingleton<IStadManager, StadManager>();
builder.Services.AddSingleton<IDomeinController, DomeinController>();

var app = builder.Build();

app.MapGet("/", () => "WEER - WEERsomstandigheden Evalueren En Rapporteren");

app.MapGet("/steden", (IDomeinController dc) => dc.GeefSteden());

app.MapGet("/weerstations", (IDomeinController controller) => controller.GeefWeerstations());

app.MapGet("/metingen", (IDomeinController controller) => controller.GeefMetingen());

app.MapGet("/weerbericht", (IDomeinController controller) => controller.GeefWeerbericht());

app.MapPost("/doemeting", (IDomeinController controller) =>
{
    controller.DoeMetingen();
    return Results.Ok("Metingen uitgevoerd");
});

app.Run();
