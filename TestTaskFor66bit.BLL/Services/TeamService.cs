using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskFor66bit.BLL.Exceptions;
using TestTaskFor66bit.BLL.InputDTO;
using TestTaskFor66bit.BLL.Interfaces;
using TestTaskFor66bit.BLL.ModelsDTO;
using TestTaskFor66bit.DAL.Interfaces;
using TestTaskFor66bit.DAL.Models;

namespace TestTaskFor66bit.BLL.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public TeamService(IMapper mapper,ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
        }
        public async Task AddTeam(TeamDTO teamDTO)
        {
            var team = await _teamRepository.Get(_mapper.Map<TeamDB>(teamDTO));
            if (team == null)
            {
               await _teamRepository.Add(_mapper.Map<TeamDB>(teamDTO));
            }
            else
                throw new ExistException("Такая команда уже существует", "");
        }

        public IEnumerable<TeamDTO> GetAllTeams()
        {
            var teams = _teamRepository.GetAll();
            if (teams == null)
                throw new NotFoundException("БД Пустая", "");
            
            return _mapper.Map<IEnumerable<TeamDTO>>(teams);
        }

        public async Task<TeamDTO> GetTeam(int id)
        {
            if (await _teamRepository.Get(id) != null)
            {
                var team = _mapper.Map<TeamDTO>(await _teamRepository.Get(id));
                return team;
            }
            else
                throw new NotFoundException("Такой команды нет в БД", "");
        }
        public async Task<TeamDTO> GetTeam(TeamDTO teamDTO)
        {
            if (await _teamRepository.Get(_mapper.Map<TeamDB>(teamDTO)) != null)
            {
                var team = _mapper.Map<TeamDTO>(await _teamRepository.Get(_mapper.Map<TeamDB>(teamDTO)));
                return team;
            }
            else
                throw new NotFoundException("Такой команды нет в БД", "");
        }
    }
}
