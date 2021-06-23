using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskFor66bit.DAL.Models;

namespace TestTaskFor66bit.DAL.Interfaces
{
    public interface ITeamRepository
    {
        public Task<TeamDB> Get(int id);
        public Task<TeamDB> Get(TeamDB teamDB);
        public IEnumerable<TeamDB> GetAll();
        public Task Add(TeamDB team);
    }
}
