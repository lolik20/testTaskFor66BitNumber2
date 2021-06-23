using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskFor66bit.ViewModels
{
    public class EditPlayerViewModel
    {
        [Required]
        public int Id { get; set;}
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BornDate { get; set; }
        [Required]
        public int TeamId { get; set; }
    }
}
