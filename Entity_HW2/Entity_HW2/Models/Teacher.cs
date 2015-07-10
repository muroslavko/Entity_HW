using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_HW2.DataAccess;

namespace Entity_HW2.Models
{
    class Teacher : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Lecture> Lectures { get; set; }

        public Teacher()
        {
            Lectures = new List<Lecture>();
        }
    }
}
