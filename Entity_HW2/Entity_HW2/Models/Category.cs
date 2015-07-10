using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HW2.Models
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Lecture> Lectures { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Test> Tests { get; set; }

        public Category()
        {
            Questions = new List<Question>();
            Lectures = new List<Lecture>();
            Users = new List<User>();
            Tests = new List<Test>();
        }
    }
}
