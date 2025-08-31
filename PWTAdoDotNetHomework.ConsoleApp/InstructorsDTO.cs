using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWT.AdoDotNet.Homework
{
    [Table("tbl_instructors")]
    public class InstructorsDTO
    {
        [Key]
        public int ?InstructorID { get; set; }

        public string ?Name { get; set; }    

        public string ?PhoneNumber { get; set; }

        public string ?Department { get; set; } 

        public bool DeleteFlag { get; set; }

    }
}
