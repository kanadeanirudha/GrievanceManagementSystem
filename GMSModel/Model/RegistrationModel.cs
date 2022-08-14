namespace GMS.Model
{
    public class RegistrationModel: BaseModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EnrollmentNumber { get; set; }
        public string ContactNumber { get; set; }
        public string EntityType { get; set; }
    }
}
