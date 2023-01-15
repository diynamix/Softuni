namespace Telephony.IO.Interfaces
{
    public interface IReader
    {
        // This ReadLine is abstract and it is NOT neccessaryly reffered to the console!!!
        // This can be Console.ReadLine() but also can be File.ReadLine()
        string ReadLine();
    }
}
