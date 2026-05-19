public class Cycle
{
    public MenstrualPhase MenstrualPhase { get; set; }
    public FollicularPhase FollicularPhase { get; set; }
    public Ovulation Ovulation { get; set; }
    public LutealPhase LutealPhase { get; set; }

    public DateTime CycleStartDate => MenstrualPhase.StartDate;
    public DateTime CycleEndDate => LutealPhase.EndDate;

    public int CycleLength => (CycleEndDate - CycleStartDate).Days + 1;
}
