namespace PersonMVC.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        
        public string Gender { get; set; } = null!;

        public string Address { get; set; } = null!; 
    }
}
