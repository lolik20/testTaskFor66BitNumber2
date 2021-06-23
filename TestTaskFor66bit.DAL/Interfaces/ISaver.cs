using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskFor66bit.DAL.Interfaces
{
    public interface ISaver
    {
        public Task SaveChangesDatabase();
    }
}
