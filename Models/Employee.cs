using Microsoft.VisualBasic;

namespace EMSwebapp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public Employee()
        {

        }


        public Employee(int id, string name, DateTime dob, string email, string phone, int departmentid)
        {
            Id = id;
            Name = name;
            DOB = dob;
            Email = email;
            Phone = phone;
            DepartmentId = departmentid;
        }


    }
}
