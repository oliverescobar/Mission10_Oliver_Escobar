namespace Mission10API.Data
{
    public interface IBowlingRepository
    {
        IEnumerable<Bowler> Bowlers { get; }
        IEnumerable<Team> Teams { get; }
        IEnumerable<Bowler> GetBowlers();
    }
}
