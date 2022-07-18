namespace NetSamples.Extensions;

public static class StringExtension
{
    public static bool IsEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }
}

public static class InterfaceExtenstion
{
    public static void DoSmthElse(this ISomeInterface interfaceObj)
    {
        Console.WriteLine("Do smth else");
    }
}