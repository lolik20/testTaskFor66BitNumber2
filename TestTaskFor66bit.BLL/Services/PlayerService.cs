using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskFor66bit.BLL.Interfaces;
using TestTaskFor66bit.BLL.ModelsDTO;
using TestTaskFor66bit.BLL;
using TestTaskFor66bit.DAL.Models;
using TestTaskFor66bit.DAL.Interfaces;
using TestTaskFor66bit.BLL.Exceptions;
using TestTaskFor66bit.BLL.InputDTO;
using TestTaskFor66bit.DAL.Enums;

namespace TestTaskFor66bit.BLL.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        public PlayerService(IPlayerRepository playerRepository, IMapper mapper, ITeamRepository teamRepository)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        public async Task AddPlayer(PlayerDTO playerDTO)
        {
            var player = await _playerRepository.Get(_mapper.Map<PlayerDB>(playerDTO));
            if (player == null)
            {
                var team = await _teamRepository.Get(_mapper.Map<TeamDB>(new TeamDTO() { Title = playerDTO.TeamDTO.Title, Country = playerDTO.TeamDTO.Country }));
                if (team != null)
                {
                    playerDTO.TeamDTO = null;
                    playerDTO.TeamId = team.Id;
                }

                await _playerRepository.Add(_mapper.Map<PlayerDB>(playerDTO) );
            }
            else
                throw new ExistException("Такой юзер уже существует", "");
        }
        public IEnumerable<PlayerDTO> GetPlayers()
        {
            if (_playerRepository.GetAll() == null)
            {
                throw new NotFoundException("БД пустая", "");
            }
            return _mapper.Map<IEnumerable<PlayerDTO>>(_playerRepository.GetAll());
        }
        public async Task<PlayerDTO> GetPlayer(int id)
        {
            if (await _playerRepository.Get(id) != null)
            {
                var player = _mapper.Map<PlayerDTO>(await _playerRepository.Get(id));
                return player;
            }
            else
                throw new NotFoundException("Такого игрока нет в бд", "");

        }
        public async Task DeletePlayer(int id)
        {
            if (await _playerRepository.Get(id) != null)
            {
                await _playerRepository.Delete(await _playerRepository.Get(id));
            }
            else
                throw new NotFoundException("Такого игрока нет в бд", "");
        }
        public async Task EditPlayer(PlayerDTO playerDTO)
        {
            var player = await _playerRepository.Get(playerDTO.Id);
            if (player != null)
            {
                playerDTO.TeamId = player.TeamId;
                await _playerRepository.Update(_mapper.Map<PlayerDB>(playerDTO));
            }
            else
                throw new NotFoundException("Такого игрока нет в бд", "");
        }
    }
}
