using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_HW2.DataAccess;

namespace Entity_HW2.Models
{
    class Question : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Test> Tests { get; set; }

        public Question()
        {
            Tests = new List<Test>();
        }
    }
}
