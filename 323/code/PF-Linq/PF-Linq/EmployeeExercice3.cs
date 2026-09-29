namespace PF_Linq
{
    public class EmployeeExercice3
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public static List<EmployeeExercice3> GetAllEmployees()
        {
            List<EmployeeExercice3> listStudents = new List<EmployeeExercice3>()
            {
            new EmployeeExercice3{ID= 101,Name = "Preety", Salary = 10000,
                             Department = "IT"},
            new EmployeeExercice3{ID= 102,Name = "Priyanka", Salary = 15000,
                             Department = "Sales"},
            new EmployeeExercice3{ID= 103,Name = "James", Salary = 50000,
                             Department = "Sales"},
            new EmployeeExercice3{ID= 104,Name = "Hina", Salary = 20000,
                             Department = "IT"},
            new EmployeeExercice3{ID= 105,Name = "Anurag", Salary = 30000,
                             Department = "IT"},
            };
            return listStudents;
        }
    }

}
