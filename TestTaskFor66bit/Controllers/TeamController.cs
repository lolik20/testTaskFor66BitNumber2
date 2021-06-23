using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskFor66bit.BLL.Interfaces;

namespace TestTaskFor66bit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController:ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet("all")]
        public async Task<ActionResult>GetAllTeams()
        {
            return Ok(_teamService.GetAllTeams());
        }

    }
}
