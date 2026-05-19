public class MenstrualPhase
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int FlowIntensity { get; set; } // 1: Light, 2: Medium, 3: Heavy

    public MenstrualPhase(DateTime startDate, DateTime endDate, int flowIntensity)
    {
        StartDate = startDate;
        EndDate = endDate;
        FlowIntensity = flowIntensity;
    }
}