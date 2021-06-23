using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskFor66bit.BLL.InputDTO
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public List<PlayerDTO> PlayerDTO { get; set; }
    }
}
