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
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationContext _dbContext;
        public readonly ISaver _saver;
        public TeamRepository(ApplicationContext context, ISaver saver)
        {
            _dbContext = context;
            _saver = saver;
        }
        public async Task Add(TeamDB team)
        {
            await _dbContext.Teams.AddAsync(team);
           await _saver.SaveChangesDatabase();
        }
        
        public async Task<TeamDB> Get(int id)
        {
            return await _dbContext.Teams.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<TeamDB> Get(TeamDB teamDB)
        {
           return await _dbContext.Teams.Where(x=>x.Title==teamDB.Title&&x.Country==teamDB.Country).AsNoTracking().FirstOrDefaultAsync();
        }
        public IEnumerable<TeamDB> GetAll()
        {
            return _dbContext.Teams.AsNoTracking().ToList();
        }
    }
}
