
/**
	 * @author Anthony Scheeres
	 */
public class UserModel
{
    public int user_id { get; }
    public string username { get; }
    public string password { get; }
    public string email { get; }
    public bool is_super_user { get; }
    public string token { get; }



    /**
	 * @author Anthony Scheeres
	 */
    public UserModel(
        int user_id,
        string username,
        string password,
        string email,
        bool is_super_user,
        string token
        )

    {
        this.user_id = user_id;
        this.username = username;
        this.password = password;
        this.email = email;
        this.is_super_user = is_super_user;
        this.token = token;
    }




}
