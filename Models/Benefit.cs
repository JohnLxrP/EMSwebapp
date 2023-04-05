namespace EMSwebapp.Models
{
    public class Benefit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee>? Employees { get; set; }


        public Benefit()
        {

        }

        public Benefit(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}