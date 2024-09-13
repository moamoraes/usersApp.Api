namespace UsersApp.Domain.Entities
{
    public class User
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Income { get; set; }
        public string CPF { get; set; }
    }
}
