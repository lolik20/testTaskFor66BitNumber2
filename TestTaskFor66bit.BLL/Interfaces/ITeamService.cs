using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskFor66bit.BLL.InputDTO;
using TestTaskFor66bit.BLL.ModelsDTO;

namespace TestTaskFor66bit.BLL.Interfaces
{
    public interface ITeamService
    {
        public Task<TeamDTO> GetTeam(int id);
        public Task<TeamDTO> GetTeam(TeamDTO team);
        public IEnumerable<TeamDTO> GetAllTeams();
        public Task AddTeam(TeamDTO team);
    }
}
