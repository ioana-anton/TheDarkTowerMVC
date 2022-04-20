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
        var user = await databaseContext.Users.FindAsync(id);
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
        var byLogin2 = databaseContext.Users.Where(x => x.Password.Equals(loginUserDTO.Password) && (x.Email.Equals(loginUserDTO.Username) || x.Name.Equals(loginUserDTO.Username))).AsEnumerable().FirstOrDefault(defaultValue: null);
        var byLogin = new User();
        byLogin.Name = loginUserDTO.Username;
        byLogin.Password = loginUserDTO.Password;

        Console.WriteLine("UserRepo; Method: GetUserByLogin; loginUserDTO: username= " + loginUserDTO.Username + " password= " + loginUserDTO.Password);
        Console.WriteLine("UserRepo; Method: GetUserByLogin; byLogin: username= " + byLogin2?.Email + " password= " + byLogin2?.Password);
        return byLogin2;
    }
}
