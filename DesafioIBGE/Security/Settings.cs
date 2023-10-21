namespace DesafioIBGE.Security;

public class Settings
{
    private static string secret = "01d01e4729847b54a33daffe8431985f308805ad100379e38e190ae51adb62fb";

    public static string Secret
    {
        get => secret;
        set => secret = value;
    }
}