using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWT.AdoDotNet.Homework
{
    internal class EfCoreService2
    {
        AppDbContext2 db = new AppDbContext2();

        public void Read()
        {
            List<CoursesDTO> lst = db.Courses.ToList();
            foreach (var item in lst)
            {
                Console.WriteLine($"{item.CourseID} {item.CourseName} {item.Description}");
            }
        }

        public void Create()
        {
            CoursesDTO course = new CoursesDTO()
            {
                CourseName = "Physics",
                Description = "This is Physics Fundamental Course",
            };
            if (course is not null)
            {
                db.Courses.Add(course);
                int result = db.SaveChanges();
                string message = result > 0 ? "Create Successful!" : "Create Failed!";
                Console.WriteLine(message);
            }
        }

        public void Update()
        {
            CoursesDTO? editCourse = db.Courses.Where(x => x.CourseID == 5).FirstOrDefault();
            if (editCourse is not null)
            {
                editCourse.Description = "This is Advanced Physics Course";
                int result = db.SaveChanges();
                string message = result > 0 ? "Update Successful!" : "Update Failed!";
                Console.WriteLine(message);
            }
        }

        public void Delete()
        {
            CoursesDTO? removedCourse = db.Courses.Where(x => x.CourseID == 2).FirstOrDefault();
            if (removedCourse is not null)
            {
                removedCourse.DeleteFlag = true;
                int result = db.SaveChanges();
                string message = result > 0 ? "Delete Successful!" : "Delete Failed!";
                Console.WriteLine(message);
            }
        }
    }
}
