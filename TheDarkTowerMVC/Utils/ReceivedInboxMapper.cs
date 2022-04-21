using AutoMapper;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Entity;

namespace TheDarkTowerMVC.Utils
{
    public class ReceivedInboxMapper
    {
        private readonly IMapper _mapper;

        //    public static List<InboxDTO> mapInboxListToInboxDTOList(List<Inbox> inboxes)
        //    {
        //        List<InboxDTO> inboxDTOs = new List<InboxDTO>();
        //        InboxDTOBuilder inboxDTOBuilder = new InboxDTOBuilder();


        //        foreach (var inbox in inboxes)
        //        {
        //            // List<UserDTO> recipients = _mapper.Map<List<UserDTO>>(inbox.Re)
        //            var inboxDTO = inboxDTOBuilder.setSender(inbox.Sender.Id).setRecipients();
        //        }
        //    }
    }
}
