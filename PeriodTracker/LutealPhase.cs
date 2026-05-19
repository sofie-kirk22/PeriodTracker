public class LutealPhase
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MoodLevel { get; set; } // 1: Low, 2: Medium, 3: High

    public LutealPhase(DateTime startDate, DateTime endDate, int moodLevel)
    {
        StartDate = startDate;
        EndDate = endDate;
        MoodLevel = moodLevel;
    }
}