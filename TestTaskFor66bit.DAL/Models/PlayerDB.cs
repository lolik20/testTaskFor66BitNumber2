using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskFor66bit.DAL.Enums;

namespace TestTaskFor66bit.DAL.Models
{
    public class PlayerDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BornDate { get; set; }
        [ForeignKey("TeamDB")]
        public int? TeamId { get; set; }
        public TeamDB TeamDB { get; set; }
    }
}
