namespace Stealer
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            //string result = spy.StealFieldInfo("Stealer.Hacker", new string[] { "username", "password" });
            //string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            //string result = spy.RevealPrivateMethods("Stealer.Hacker");
            string result = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}