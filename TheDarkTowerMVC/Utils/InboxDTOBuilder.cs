using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Entity;

namespace TheDarkTowerMVC.Utils
{
    public class InboxDTOBuilder
    {
        InboxDTO inboxDTO;

        public InboxDTOBuilder()
        {
            inboxDTO = new InboxDTO();
        }

        public InboxDTOBuilder setSender(String senderId)
        {
            inboxDTO.Sender = senderId;
            return this;
        }

        public InboxDTOBuilder setRecipients(List<UserDTO> recipients)
        {
            inboxDTO.Recipients = recipients;
            return this;
        }

        public InboxDTOBuilder setMessage(String message)
        {
            inboxDTO.Message = message;
            return this;
        }

        public InboxDTO build()
        {
            return inboxDTO;
        }

    }
}
