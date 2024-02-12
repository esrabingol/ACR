namespace ASP.WEBUI.Models
{
    //Ekrandan alınıcak bilgiler
    public class UserRegisterModel
    {
        public string Name { get; set;}
        public string SurName { get; set; }
        public string MailAdress { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }


    }
}
