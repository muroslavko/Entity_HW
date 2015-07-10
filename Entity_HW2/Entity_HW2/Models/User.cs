using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HW2.Models
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Sity { get; set; }
        public string Univercity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<TestWork> TestWorks { get; set; }

        public User()
        {
            TestWorks = new List<TestWork>();
        }
    }
}
