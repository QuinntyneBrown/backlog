namespace Backlog.Responses
{
    public class RegistrationRequestDto
    {
        public RegistrationRequestDto()
        {

        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddressConfirmation { get; set; }
        public string Password { get; set; }
    }
}
