using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var storage = new CycleStorage("cycles.json");
var tracker = new CycleTracker();

var randomCycles = CycleGenerator.GenerateCycles(6, new DateTime(2024, 5, 24));

foreach (var cycle in randomCycles)
{
    tracker.AddCycle(cycle);
}

tracker.Cycles = storage.LoadCycles();
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

tracker.AddCycle(new Cycle
{
    MenstrualPhase = new MenstrualPhase
    {
        StartDate = new DateTime(2024, 1, 29),
        EndDate = new DateTime(2024, 2, 2),
        FlowIntensity = 3
    },
    FollicularPhase = new FollicularPhase
    {
        StartDate = new DateTime(2024, 2, 3),
        EndDate = new DateTime(2024, 2, 10),
        EnergyLevel = 4
    },
    Ovulation = new Ovulation
    {
        FertileWindowStart = new DateTime(2024, 2, 11),
        FertileWindowEnd = new DateTime(2024, 2, 13),
        OvulationDate = new DateTime(2024, 2, 12),
        FertilityLevel = 4
    },
    LutealPhase = new LutealPhase
    {
        StartDate = new DateTime(2024, 2, 14),
        EndDate = new DateTime(2024, 2, 25),
        MoodLevel = 3
    }
});

tracker.AddCycle(new Cycle
{
    MenstrualPhase = new MenstrualPhase
    {
        StartDate = new DateTime(2024, 2, 26),
        EndDate = new DateTime(2024, 3, 2),
        FlowIntensity = 2
    },
    FollicularPhase = new FollicularPhase
    {
        StartDate = new DateTime(2024, 3, 3),
        EndDate = new DateTime(2024, 3, 12),
        EnergyLevel = 3
    },
    Ovulation = new Ovulation
    {
        FertileWindowStart = new DateTime(2024, 3, 13),
        FertileWindowEnd = new DateTime(2024, 3, 16),
        OvulationDate = new DateTime(2024, 3, 14),
        FertilityLevel = 3
    },
    LutealPhase = new LutealPhase
    {
        StartDate = new DateTime(2024, 3, 17),
        EndDate = new DateTime(2024, 3, 30),
        MoodLevel = 1
    }
});

tracker.AddCycle(new Cycle
{
    MenstrualPhase = new MenstrualPhase
    {
        StartDate = new DateTime(2024, 3, 31),
        EndDate = new DateTime(2024, 4, 4),
        FlowIntensity = 2
    },
    FollicularPhase = new FollicularPhase
    {
        StartDate = new DateTime(2024, 4, 5),
        EndDate = new DateTime(2024, 4, 9),
        EnergyLevel = 2
    },
    Ovulation = new Ovulation
    {
        FertileWindowStart = new DateTime(2024, 4, 10),
        FertileWindowEnd = new DateTime(2024, 4, 12),
        OvulationDate = new DateTime(2024, 4, 11),
        FertilityLevel = 3
    },
    LutealPhase = new LutealPhase
    {
        StartDate = new DateTime(2024, 4, 13),
        EndDate = new DateTime(2024, 4, 24),
        MoodLevel = 2
    }
});

tracker.AddCycle(new Cycle
{
    MenstrualPhase = new MenstrualPhase
    {
        StartDate = new DateTime(2024, 4, 25),
        EndDate = new DateTime(2024, 4, 30),
        FlowIntensity = 4
    },
    FollicularPhase = new FollicularPhase
    {
        StartDate = new DateTime(2024, 5, 1),
        EndDate = new DateTime(2024, 5, 8),
        EnergyLevel = 2
    },
    Ovulation = new Ovulation
    {
        FertileWindowStart = new DateTime(2024, 5, 9),
        FertileWindowEnd = new DateTime(2024, 5, 11),
        OvulationDate = new DateTime(2024, 5, 10),
        FertilityLevel = 2
    },
    LutealPhase = new LutealPhase
    {
        StartDate = new DateTime(2024, 5, 12),
        EndDate = new DateTime(2024, 5, 23),
        MoodLevel = 1
    }
});

storage.SaveCycles(tracker.Cycles);

app.MapGet("/", () => "Small and simple period tracker API");

app.Run();
