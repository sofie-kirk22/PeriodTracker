public class CycleTracker
{
    public List<Cycle> Cycles { get; set; }

    public CycleTracker()
    {
        Cycles = new List<Cycle>();
    }

    public void AddCycle(Cycle cycle)
    {
        Cycles.Add(cycle);
    }

    public Cycle? GetCurrentCycle()
    {
        DateTime today = DateTime.Today;
        return Cycles.FirstOrDefault(c => c.CycleStartDate <= today && c.CycleEndDate >= today);
    }

    public string GetCurrentPhase(DateTime today)
    {
        var currentCycle = GetCurrentCycle();

        if (currentCycle == null)
        {
            return "No active phase";
        }


        if(today >= currentCycle.MenstrualPhase.StartDate && today <= currentCycle.MenstrualPhase.EndDate)
        {
            return "Menstrual Phase";
        }
        else if(today >= currentCycle.FollicularPhase.StartDate && today <= currentCycle.FollicularPhase.EndDate)
        {
            return "Follicular Phase";
        }
        else if(today >= currentCycle.Ovulation.FertileWindowStart && today <= currentCycle.Ovulation.FertileWindowEnd)
        {
            return "Ovulation";
        }
        else if(today >= currentCycle.LutealPhase.StartDate && today <= currentCycle.LutealPhase.EndDate)
        {
            return "Luteal Phase";
        }
        else
        {
            return "No active phase";
        }
    }

    public double GetAverageCycleLength()
    {
        if (Cycles.Count == 0) return 0;
        return Cycles.Average(c => c.CycleLength);
    }

    public double GetDaysToOvulation()
    {
        var currentCycle = GetCurrentCycle();
        if (currentCycle == null) return -1; // No active cycle
        DateTime today = DateTime.Today;
        if (today < currentCycle.Ovulation.FertileWindowStart)
        {
            return (currentCycle.Ovulation.FertileWindowStart - today).Days;
        }
        else if (today > currentCycle.Ovulation.FertileWindowEnd)
        {
            return -1; // Ovulation has passed
        }
        else
        {
            return 0; // Currently in ovulation window
        }
    }

    public DateTime PredictNextCycleStart()
    {
        if (Cycles.Count == 0) return DateTime.Today;

        var lastCycle = Cycles.OrderByDescending(c => c.CycleStartDate).First();
        var averageCycleLength = GetAverageCycleLength();
        return lastCycle.CycleStartDate.AddDays(averageCycleLength);
    }

    public int GetTotalCyclesTracked()
    {
        return Cycles.Count;
    }

    public Cycle? GetLatestCycle()
    {
        return Cycles.OrderByDescending(c => c.CycleStartDate).FirstOrDefault();
    }
}