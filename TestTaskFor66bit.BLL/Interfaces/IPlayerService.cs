using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskFor66bit.BLL.InputDTO;
using TestTaskFor66bit.BLL.ModelsDTO;

namespace TestTaskFor66bit.BLL.Interfaces
{
    public interface IPlayerService
    {
        public Task AddPlayer(PlayerDTO playerDTO);
        public IEnumerable<PlayerDTO> GetPlayers();
        public Task<PlayerDTO> GetPlayer(int id);
        public Task DeletePlayer(int id);
        public Task EditPlayer(PlayerDTO playerDTO);
    }
}
