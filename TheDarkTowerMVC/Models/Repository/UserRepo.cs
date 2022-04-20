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

    public async Task<User> GetUserById(string id)
    {
        var user = databaseContext.Users.Where(y => y.Id == id).Include(x => x.Decks).ToList().First();
        return user;
    }

    public async Task InsertNewUser(User user)
    {
        if (user == null) throw new ArgumentNullException("user");
        else
            databaseContext.Users.Add(user);
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
