using System.Data.Entity;
using TheDarkTowerMVC.Data;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Entity;

public class UserRepo
{
    private readonly DatabaseContext databaseContext;

    public UserRepo(DatabaseContext dbContext)
    {
        databaseContext = dbContext;
    }

    public async Task<User> GetUserById(String id)
    {
        var user = databaseContext.Users.Where(y => y.Id == id).Include(x => x.Decks).ToList().First();
        return user;
    }

    public List<Inbox> GetReceivedInbox(String id)
    {
        var messages = databaseContext.Inbox.Where(u => u.Sender.Id.Equals(id)).Include(x => x.Recipients).ToList();
        return messages;
    }
    public List<CardDeck> GetCardDecks(String owner)
    {

        var decks = databaseContext.CardDecks.Where(y => y.UserId == owner || y.byAdmin).ToList();

        return decks;
    }
    public List<User> GetFriendList(String id)
    {
        if (id == null) throw new ArgumentNullException("id");
        var users = new List<User>();
        var friends = databaseContext.FriendList.Where(u => u.User.Id.Equals(id)).ToList();
        if (friends.Count > 0)
            if (friends[0].Id != null && friends[0].Id != "")
                Console.WriteLine("UserRepo; GetFriendList; " + friends[0].Id);

        foreach (var friend in friends)
        {
            var user = databaseContext.Users.Where(u => u.Id.Equals(friend.Id)).ToList().FirstOrDefault();
            Console.WriteLine("UserRepo; GetFriendList; FriendId" + friend.Id);
            // Console.WriteLine("UserRepo; GetFriendList; FriendUser" + friend.User.Username);
            users.Add(user);
        }
        if (users.Count == 0)
        {
            Console.WriteLine("UserRepo; GetFriendList; No friends found!");
            return null;
        }

        Console.WriteLine("UserRepo; GetFriendList; There were " + users.Count + " friends found!");

        return users;
    }

    public async Task InsertNewUser(User user)
    {
        if (user == null) throw new ArgumentNullException("user");
        else
            databaseContext.Users.Add(user);
        await databaseContext.SaveChangesAsync();
    }

    public async Task InsertNewMessage(User user, User friend, String message)
    {
        if (user == null) throw new ArgumentNullException("user");
        //var inbox = new Inbox();
        //List<Recipient> recipients = new List<Recipient>();
        //inbox.Sender = user;
        //foreach (var recipientId in recipientIds)
        //{
        //    var recipientUser = databaseContext.Users.Where(u => u.Id.Equals(recipientId)).FirstOrDefault();
        //    var recipient = new Recipient();
        //    if (recipientUser != null)
        //    {
        //        recipient.Receiver = recipientUser;
        //        Console.WriteLine("UseRepo; InsertNewMessage; recipientUser: " + recipient.Receiver.Username);
        //    }
        //    recipients.Add(recipient);
        //}
        //inbox.Recipients = recipients;
        ////databaseContext.Inbox.Add()
        Inbox inbox = new Inbox();
        inbox.Sender = user;
        inbox.Message = message;
        Recipient recipient = new Recipient();
        recipient.Receiver = friend;
        inbox.Recipients.Add(recipient);
        databaseContext.Inbox.Add(inbox);

        await databaseContext.SaveChangesAsync();
    }

    public async Task InsertNewFriend(User user, String friendUsername)
    {
        if (user == null) throw new ArgumentNullException("user");
        else
        {
            //databaseContext.Users.Add(user);
            var friendUser = databaseContext.Users.Where(u => u.Username.Equals(friendUsername)).ToList().FirstOrDefault();
            if (friendUser == null) throw new ArgumentNullException("friend");
            var friend = new Friend();
            friend.Id = friendUser.Id;
            friend.User = user;

            databaseContext.Add(friend);

            var friend2 = new Friend();
            friend2.Id = user.Id;
            friend2.User = friendUser;

            databaseContext.Add(friend2);

        }
        await databaseContext.SaveChangesAsync();
    }

    public User? GetUserByLogin(LoginUserDTO loginUserDTO)
    {
        var byLogin = databaseContext.Users.Where(x => x.Password.Equals(loginUserDTO.Password) && x.Username.Equals(loginUserDTO.Username)).AsEnumerable().FirstOrDefault(defaultValue: null);

        Console.WriteLine("UserRepo; INPUT; Method: GetUserByLogin; loginUserDTO: username= " + loginUserDTO.Username + " password= " + loginUserDTO.Password);
        Console.WriteLine("UserRepo; OUTPUT; Method: GetUserByLogin; byLogin: username= " + byLogin?.Username + " password= " + byLogin?.Password);
        return byLogin;
    }
}
