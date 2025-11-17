// See https://aka.ms/new-console-template for more information
public static class ParserExtensinons
{
    public static T As<T>(this object obj) where T : class
    {
        return (T)obj;
    }
    public static byte[] AsByteArray(this object obj)
    {
           return obj as byte[] ?? new byte[0];
    }
}