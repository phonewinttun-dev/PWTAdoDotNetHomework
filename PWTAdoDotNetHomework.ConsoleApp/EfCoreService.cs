using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWT.AdoDotNet.Homework
{
    public class EfCoreService
    {
        AppDbContext db = new AppDbContext();

        public void Read() 
        {
            List<InstructorsDTO> lst = db.Instructors.ToList();

            foreach (var item in lst) 
            {
                Console.WriteLine($"{item.InstructorID} {item.Name} {item.Department}");
            }
            
        }

        public void Create() 
        { 
            InstructorsDTO instructor = new InstructorsDTO() 
            { 
                Name = "Daw Mar",
                PhoneNumber = "09234567891",
                Department = "Maths"
            };

            if (instructor is not null)
            {
                db.Instructors.Add(instructor);
                int result = db.SaveChanges();
                string message = result > 0 ? "Create Successful!" : "Create Failed!";
                Console.WriteLine(message);
            }
        }

        public void Update() 
        {
            InstructorsDTO? editInstructors = db.Instructors.Where(x => x.InstructorID == 5).FirstOrDefault();
            if (editInstructors is not null)
            {
                editInstructors.Department = "English";
                int result = db.SaveChanges();
                string message = result > 0 ? "Update Successful!" : "Update failed!";
                Console.WriteLine(message);
            }
        }

        public void Delete() 
        { 
            InstructorsDTO? removedInstructors = db.Instructors.Where(x => x.InstructorID == 5).FirstOrDefault();
            if (removedInstructors is not null)
            {
                removedInstructors.DeleteFlag = true;
                int result = db.SaveChanges();
                string message = result > 0 ? "Delete successful!" : "Delete Failed!";
                Console.WriteLine(message);
            }
        }
    }
}
