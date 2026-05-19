using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var storage = new CycleStorage("cycles.json");
var tracker = new CycleTracker();

var randomCycles = CycleGenerator.GenerateCycles(6, new DateTime(2024, 5, 24));

tracker.Cycles = storage.LoadCycles();

foreach (var cycle in randomCycles)
{
    tracker.AddCycle(cycle);
}

/*
tracker.AddCycle(new Cycle
{
    MenstrualPhase = new MenstrualPhase
    {
        StartDate = new DateTime(2024, 1, 1),
        EndDate = new DateTime(2024, 1, 5),
        FlowIntensity = 2
    },
    FollicularPhase = new FollicularPhase
    {
        StartDate = new DateTime(2024, 1, 6),
        EndDate = new DateTime(2024, 1, 13),
        EnergyLevel = 3
    },
    Ovulation = new Ovulation
    {
        FertileWindowStart = new DateTime(2024, 1, 14),
        FertileWindowEnd = new DateTime(2024, 1, 16),
        OvulationDate = new DateTime(2024, 1, 15),
        FertilityLevel = 3
    },
    LutealPhase = new LutealPhase
    {
        StartDate = new DateTime(2024, 1, 17),
        EndDate = new DateTime(2024, 1, 28),
        MoodLevel = 2
    }
});
*/

storage.SaveCycles(tracker.Cycles);

app.MapGet("/", () => "Small and simple period tracker API \n \n" +
    "Endpoints: \n" +
    "/current-phase - Get current menstrual phase \n" +
    "/average-cycle-length - Get average cycle length \n" +
    "/days-to-ovulation - Get days until ovulation \n" +
    "/cycles - List all cycles with details \n" +
    "/list-all-cycles - List all cycles in raw format");

app.MapGet("/current-phase", () =>
{
    var today = DateTime.Today;
    return tracker.GetCurrentPhase(today);
});

app.MapGet("/average-cycle-length", () =>
{
    return tracker.GetAverageCycleLength();
});

app.MapGet("/days-to-ovulation", () =>
{
    return tracker.GetDaysToOvulation();
});

app.MapGet("/cycles", () =>
{
    return tracker.Cycles.Select(c => new
    {
        CycleStart = c.CycleStartDate.ToString("yyyy-MM-dd"),
        CycleEnd = c.CycleEndDate.ToString("yyyy-MM-dd"),
        MenstrualPhase = new
        {
            Start = c.MenstrualPhase.StartDate.ToString("yyyy-MM-dd"),
            End = c.MenstrualPhase.EndDate.ToString("yyyy-MM-dd"),
            FlowIntensity = c.MenstrualPhase.FlowIntensity
        },
        FollicularPhase = new
        {
            Start = c.FollicularPhase.StartDate.ToString("yyyy-MM-dd"),
            End = c.FollicularPhase.EndDate.ToString("yyyy-MM-dd"),
            EnergyLevel = c.FollicularPhase.EnergyLevel
        },
        Ovulation = new
        {
            FertileWindowStart = c.Ovulation.FertileWindowStart.ToString("yyyy-MM-dd"),
            FertileWindowEnd = c.Ovulation.FertileWindowEnd.ToString("yyyy-MM-dd"),
            OvulationDate = c.Ovulation.OvulationDate.ToString("yyyy-MM-dd"),
            FertilityLevel = c.Ovulation.FertilityLevel
        },
        LutealPhase = new
        {
            Start = c.LutealPhase.StartDate.ToString("yyyy-MM-dd"),
            End = c.LutealPhase.EndDate.ToString("yyyy-MM-dd"),
            MoodLevel = c.LutealPhase.MoodLevel
        }
    });
});

app.MapGet("/list-all-cycles", () =>
{
    return tracker.Cycles;
});

app.Run();
