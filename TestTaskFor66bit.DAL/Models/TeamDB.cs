using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskFor66bit.DAL.Enums;

namespace TestTaskFor66bit.DAL.Models
{
    public class TeamDB
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Country Country { get; set; }
        public List<PlayerDB> PlayerDB { get; set; }
    }
}
