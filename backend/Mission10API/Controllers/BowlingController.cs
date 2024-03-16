using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mission10API.Data;

namespace Mission10API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private IBowlingRepository _bowlerRepository;
        public BowlingController(IBowlingRepository temp) { 
            _bowlerRepository = temp;
        }

        [HttpGet]
        public IEnumerable<Bowler> Get()
        {
            var bowlerData = _bowlerRepository.GetBowlers()
                .Where(x => x.Team.TeamName == "Marlins" || x.Team.TeamName == "Sharks");

            return bowlerData;
        }
    }
}
