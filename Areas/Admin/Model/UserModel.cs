namespace SAOnlineMart.Areas.Admin.Model
{
    public class UserAccount
    {
        public int UserId { get; set; } 
        public string userName { get; set; } = string.Empty; 
        public string userEmail { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string userPassword { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
