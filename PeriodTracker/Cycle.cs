public class Cycle
{
    public required MenstrualPhase MenstrualPhase { get; set; }
    public required FollicularPhase FollicularPhase { get; set; }
    public required Ovulation Ovulation { get; set; }
    public required LutealPhase LutealPhase { get; set; }

    public DateTime CycleStartDate => MenstrualPhase.StartDate;
    public DateTime CycleEndDate => LutealPhase.EndDate;

    public int CycleLength => (CycleEndDate - CycleStartDate).Days + 1;
}
