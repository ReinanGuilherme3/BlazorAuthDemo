namespace BlazorAuthDemo.Security;

public class UserPolicy
{
    public const string VIEW = "VIEW";
    public const string ADD = "ADD";
    public const string EDIT = "EDIT";
    public const string CREATE = "CREATE";

    public static List<string> GetPolicies()
    {
        return new List<string>
        {
            VIEW,
            ADD,
            EDIT,
            CREATE
        };
    }
}
