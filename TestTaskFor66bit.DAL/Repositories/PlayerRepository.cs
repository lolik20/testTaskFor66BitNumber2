using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskFor66bit.DAL.EF;
using TestTaskFor66bit.DAL.Interfaces;
using TestTaskFor66bit.DAL.Models;

namespace TestTaskFor66bit.DAL.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationContext _dbContext;
        private readonly ISaver _saver;
        public PlayerRepository(ApplicationContext context, ISaver saver)
        {
            _dbContext = context;
            _saver = saver;
        }
        public async Task<PlayerDB> Get(int id)
        {
            return await _dbContext.Players.AsNoTracking().FirstOrDefaultAsync() ;
        }
        public async Task<PlayerDB> Get(PlayerDB playerDB)
        {
            return await _dbContext.Players.Where(x => x.Name == playerDB.Name && x.SurName == playerDB.SurName && x.BornDate == playerDB.BornDate && x.Gender == playerDB.Gender && x.TeamDB.Country == playerDB.TeamDB.Country && x.TeamDB.Title == playerDB.TeamDB.Title).AsNoTracking().FirstOrDefaultAsync();
        }
        public IEnumerable<PlayerDB> GetAll()
        {
            return _dbContext.Players.Include(x => x.TeamDB);
        }
        public async Task Delete(PlayerDB player)
        {
            _dbContext.Players.Remove(player);
            await _saver.SaveChangesDatabase();
        }
        public async Task Add(PlayerDB player)
        {
            await _dbContext.Players.AddAsync(player);
           await _saver.SaveChangesDatabase();
        }
        public async Task Update(PlayerDB player)
        {
            _dbContext.Update(player);
          await  _saver.SaveChangesDatabase();
        }
    }

}
