using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskFor66bit.DAL.Interfaces;

namespace TestTaskFor66bit.DAL.EF
{
    public class Saver :ISaver
    {
        private readonly ApplicationContext _dbContext;
        public Saver(ApplicationContext context )
        {
            _dbContext = context;
        }
       public async Task SaveChangesDatabase()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
