using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HW2.Models
{
    class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [StringLength(30)]
        public string Description { get; set; }

        public Lecture()
        {
            Teachers = new List<Teacher>();
        }
    }
}
