using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskFor66bit.BLL.InputDTO
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Gender { get; set; }
        public DateTime BornDate { get; set; }
        public int? TeamId { get; set; }
        public  TeamDTO TeamDTO { get; set; }
    }
}
