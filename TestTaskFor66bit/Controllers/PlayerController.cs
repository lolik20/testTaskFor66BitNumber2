using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestTaskFor66bit.BLL.Interfaces;
using TestTaskFor66bit.BLL.InputDTO;
using TestTaskFor66bit.ViewModels;

namespace TestTaskFor66bit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpPost("add")]
        public async Task AddPlayer(AddPlayerViewModel playerToBeAdded)
        {
           await _playerService.AddPlayer(new PlayerDTO() { Name = playerToBeAdded.Name,SurName=playerToBeAdded.SurName,BornDate=playerToBeAdded.BornDate,Gender=playerToBeAdded.Gender, TeamDTO = new TeamDTO() { Country = playerToBeAdded.Country, Title = playerToBeAdded.Title } }) ;
        }
        [HttpGet("all")]
        public async Task<ActionResult>GetPlayers()
        {
            return Ok(_playerService.GetPlayers());
        }
        [HttpPost("edit")]
        public async Task<ActionResult>EditPlayer(EditPlayerViewModel playerToBeEdited)
        {
            return Ok(_playerService.EditPlayer(new PlayerDTO() { Id=playerToBeEdited.Id,Name=playerToBeEdited.Name,SurName=playerToBeEdited.SurName,Gender=playerToBeEdited.Gender,BornDate=playerToBeEdited.BornDate}));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPlayer(int id)
        {
            return Ok( await _playerService.GetPlayer(id));
        }
    }
}
