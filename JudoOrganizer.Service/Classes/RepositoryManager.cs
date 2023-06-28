using JudoOrganizer.Data;
using JudoOrganizer.Service.Interfaces;

namespace JudoOrganizer.Service.Classes;

public class RepositoryManager : IRepositoryManager
{
    private ApplicationContext _applicationContext;

    private ICityService _cityService;
    private IClubService _clubService;
    private ICoachService _coachService;
    private ICountryService _countryService;
    private IMatchService _matchService;
    private IMatchResultService _matchResultService;
    private IRegistrationService _registrationService;
    private ISportCategoryService _sportCategoryService;
    private ISportsmanService _sportsmanService;
    private ITournamentService _tournamentService;
    private ITournamentResultService _tournamentResultService;
    private IUserService _userService;
    private IWeighingService _weighingService;
    private IWeightService _weightService;

    public RepositoryManager(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public ICityService City
    {
        get
        {
            if (_cityService is null)
                _cityService = new CityService(_applicationContext);
            return _cityService;
        }
    }

    public IClubService Club
    {
        get
        {
            if (_clubService is null)
                _clubService = new ClubService(_applicationContext);
            return _clubService;
        }
    }
    
    public ICoachService Coach
    {
        get
        {
            if (_coachService is null)
                _coachService = new CoachService(_applicationContext);
            return _coachService;
        }
    }
    
    public ICountryService Country
    {
        get
        {
            if (_countryService is null)
                _countryService = new CountryService(_applicationContext);
            return _countryService;
        }
    }

    public IMatchService Match
    {
        get
        {
            if (_matchService is null)
                _matchService = new MatchService(_applicationContext);
            return _matchService;
        }
    }
    
    public IMatchResultService MatchResult
    {
        get
        {
            if (_matchResultService is null)
                _matchResultService = new MatchResultService(_applicationContext);
            return _matchResultService;
        }
    }

    public IRegistrationService Registration
    {
        get
        {
            if (_registrationService is null)
                _registrationService = new RegistrationService(_applicationContext);
            return _registrationService;
        }
    }
    
    public ISportCategoryService SportCategory
    {
        get
        {
            if (_sportCategoryService is null)
                _sportCategoryService = new SportCategoryService(_applicationContext);
            return _sportCategoryService;
        }
    }
    
    public ISportsmanService Sportsman
    {
        get
        {
            if (_sportsmanService is null)
                _sportsmanService = new SportsmanService(_applicationContext);
            return _sportsmanService;
        }
    }
    
    public ITournamentService Tournament
    {
        get
        {
            if (_tournamentService is null)
                _tournamentService = new TournamentService(_applicationContext);
            return _tournamentService;
        }
    }
    
    public ITournamentResultService TournamentResult
    {
        get
        {
            if (_tournamentResultService is null)
                _tournamentResultService = new TournamentResultService(_applicationContext);
            return _tournamentResultService;
        }
    }

    public IUserService User
    {
        get
        {
            if (_userService is null)
                _userService = new UserService(_applicationContext);
            return _userService;
        }
    }
    
    public IWeighingService Weighing
    {
        get
        {
            if (_weighingService is null)
                _weighingService = new WeighingService(_applicationContext);
            return _weighingService;
        }
    }
    
    public IWeightService Weight
    {
        get
        {
            if (_weightService is null)
                _weightService = new WeightService(_applicationContext);
            return _weightService;
        }
    }
}