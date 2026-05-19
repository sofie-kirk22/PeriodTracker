# Cycle Tracker (C#)

A simple period and cycle tracking application built in C#.  
The app models menstrual cycles using four biological phases and allows tracking, analysis, and basic predictions.

---

## Features

- Track full cycles with:
  - Menstrual phase (flow intensity)
  - Follicular phase (energy level)
  - Ovulation (fertility window + level)
  - Luteal phase (mood level)
- Get current cycle and phase
- Calculate average cycle length
- Estimate days until ovulation
- Predict next period start
- Save and load data from file (JSON)
- Generate random test data

---

## Project Structure
- Cycle.cs
- MenstrualPhase.cs
- FollicularPhase.cs
- Ovulation.cs
- LutealPhase.cs
- CycleTracker.cs
- CycleStorage.cs
- CycleGenerator.cs
- Program.cs

---

## Getting Started

1. Clone the repo
2. Open in Visual Studio or VS Code
3. Run the project:

```bash
dotnet run
```

---

## Saving & Loading

Cycles are stored in a JSON file:

```C#
var storage = new CycleStorage("cycles.json");

tracker.Cycles = storage.LoadCycles();
storage.SaveCycles(tracker.Cycles);
```

---

## Generate Test Data
```C#
var cycles = CycleGenerator.GenerateCycles(5, new DateTime(2024, 1, 1));

foreach (var cycle in cycles)
{
    tracker.AddCycle(cycle);
}
```

---

## Notes

This is a learning project focused on:
- Object-oriented design in C#
- Working with dates and time
- Basic data persistence (JSON)

--- 

## Future Ideas

- UI (console → web or desktop)
- User profiles
- Statistics & insights
- Notifications/reminders