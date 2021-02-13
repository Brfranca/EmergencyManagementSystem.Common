namespace EmergencyManagementSystem.Common.Common.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long EmployeeId { get; set; }
    }
}
