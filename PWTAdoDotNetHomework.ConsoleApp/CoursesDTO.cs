using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWT.AdoDotNet.Homework
{
    [Table("tbl_courses")]
    public class CoursesDTO
    {
        [Key]
        public int? CourseID { get; set; }

        public string? CourseName { get; set; }

        public string? Description { get; set; }

        public bool DeleteFlag { get; set; }

    }
}
