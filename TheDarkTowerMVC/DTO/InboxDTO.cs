using TheDarkTowerMVC.Entity;

namespace TheDarkTowerMVC.DTO
{
    public class InboxDTO
    {
        public String Message { get; set; }

        public String Sender { get; set; }

        public List<UserDTO> Recipients { get; set; } //single or multiple
    }
}
