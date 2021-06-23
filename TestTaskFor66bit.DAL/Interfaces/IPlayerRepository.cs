using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskFor66bit.DAL.Models;

namespace TestTaskFor66bit.DAL.Interfaces
{
    public interface IPlayerRepository
    {
        public Task<PlayerDB> Get(int id);
        public Task<PlayerDB> Get(PlayerDB playerDB);
        public IEnumerable<PlayerDB> GetAll();
        public Task Delete(PlayerDB player);
        public Task Add(PlayerDB player);
        public Task Update(PlayerDB player);
    }
}
