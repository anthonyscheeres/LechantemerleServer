
/**
	 * @author Anthony Scheeres
	 */
public class UserModel
{
    public int? user_id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public bool? is_super_user { get; set; }
    public string? token { get; set; }

    public UserModel()
    {
    }



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
