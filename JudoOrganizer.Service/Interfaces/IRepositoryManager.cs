namespace JudoOrganizer.Service.Interfaces;

public interface IRepositoryManager
{
    ICityService City { get; }
    IClubService Club { get; }
    ICoachService Coach { get; }
    ICountryService Country { get; }
    IMatchResultService MatchResult { get; }
    IMatchService Match { get; }
    ISportCategoryService SportCategory { get; }
    ISportsmanService Sportsman { get; }
    ITournamentService Tournament { get; }
    ITournamentResultService TournamentResult { get; }
    IUserService User { get; }
    IWeightService Weight { get; }
}