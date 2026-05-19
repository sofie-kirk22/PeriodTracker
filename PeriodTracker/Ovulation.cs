public class Ovulation
{
    public DateTime OvulationDate { get; set; }
    public DateTime FertileWindowStart { get; set; }
    public DateTime FertileWindowEnd { get; set; }
    public int FertilityLevel { get; set; } // 1: Low, 2: Medium, 3: High

    public Ovulation(DateTime ovulationDate, DateTime fertileWindowStart, DateTime fertileWindowEnd, int fertilityLevel)
    {
        OvulationDate = ovulationDate;
        FertileWindowStart = fertileWindowStart;
        FertileWindowEnd = fertileWindowEnd;
        FertilityLevel = fertilityLevel;
    }
}