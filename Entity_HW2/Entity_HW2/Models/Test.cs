using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HW2.Models
{
    class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public ICollection<Question> Questions { get; set; }
        public TestWork TestWorks { get; set; }
        public int MaxTime { get; set; }
        public int PassMark { get; set; }

        public Test()
        {
            Questions = new List<Question>();
            //this.Questions = new HashSet<Question>();
            //this.Categories = new HashSet<Category>();
            //Categories = new List<Category>();
        }
    }
}
