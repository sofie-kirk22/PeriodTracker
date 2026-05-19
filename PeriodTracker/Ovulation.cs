public class Ovulation
{
    public DateTime OvulationDate { get; set; }
    public DateTime FertileWindowStart { get; set; }
    public DateTime FertileWindowEnd { get; set; }
    public int FertilityLevel { get; set; } // 1: Low, 2: Medium, 3: High
}