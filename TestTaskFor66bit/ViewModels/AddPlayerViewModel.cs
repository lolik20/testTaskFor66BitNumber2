using System;
using System.ComponentModel.DataAnnotations;

namespace TestTaskFor66bit.ViewModels
{
    public class AddPlayerViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BornDate { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Country { get; set; }
        
    }
}
