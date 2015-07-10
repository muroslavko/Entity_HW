using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_HW2.Models
{
    class TestWork
    {
        [Key, ForeignKey("Test")]
        public int Id { get; set; }
        public Test Test { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Mark { get; set; }
        public int Time { get; set; }
    }
}
