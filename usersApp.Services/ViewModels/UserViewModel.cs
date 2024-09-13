namespace UsersApp.Application.ViewModels
{
    public class UserViewModel
    {
        public required string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public required string CPF { get; set; }
        public decimal Income { get; set; }
    }
}
