public static class CycleGenerator
{
    private static Random _random = new Random();

    public static Cycle GenerateCycle(DateTime startDate)
    {
        // Random lengths
        int menstrualLength = _random.Next(3, 7);
        int follicularLength = _random.Next(5, 10);
        int ovulationWindowLength = _random.Next(2, 4);
        int lutealLength = _random.Next(10, 15);

        var menstrualStart = startDate;
        var menstrualEnd = menstrualStart.AddDays(menstrualLength - 1);

        var follicularStart = menstrualEnd.AddDays(1);
        var follicularEnd = follicularStart.AddDays(follicularLength - 1);

        var ovulationStart = follicularEnd.AddDays(1);
        var ovulationEnd = ovulationStart.AddDays(ovulationWindowLength - 1);
        var ovulationDate = ovulationStart.AddDays(_random.Next(0, ovulationWindowLength));

        var lutealStart = ovulationEnd.AddDays(1);
        var lutealEnd = lutealStart.AddDays(lutealLength - 1);

        return new Cycle
        {
            MenstrualPhase = new MenstrualPhase
            {
                StartDate = menstrualStart,
                EndDate = menstrualEnd,
                FlowIntensity = _random.Next(1, 5)
            },
            FollicularPhase = new FollicularPhase
            {
                StartDate = follicularStart,
                EndDate = follicularEnd,
                EnergyLevel = _random.Next(1, 5)
            },
            Ovulation = new Ovulation
            {
                FertileWindowStart = ovulationStart,
                FertileWindowEnd = ovulationEnd,
                OvulationDate = ovulationDate,
                FertilityLevel = _random.Next(1, 5)
            },
            LutealPhase = new LutealPhase
            {
                StartDate = lutealStart,
                EndDate = lutealEnd,
                MoodLevel = _random.Next(1, 5)
            }
        };
    }

    public static List<Cycle> GenerateCycles(int count, DateTime firstStartDate)
    {
        var cycles = new List<Cycle>();
        var currentStart = firstStartDate;

        for (int i = 0; i < count; i++)
        {
            var cycle = GenerateCycle(currentStart);
            cycles.Add(cycle);

            // next cycle starts the day after this one ends
            currentStart = cycle.LutealPhase.EndDate.AddDays(1);
        }

        return cycles;
    }
}