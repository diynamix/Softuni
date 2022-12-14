namespace Telephony
{
    using Core;
    using Core.Interfaces;
    using IO;
    using IO.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}

// Test 1
// 0882134 0882134333 0899213421 0558123 0882134332
// http://softuni.bg http://youtube.com http://www.g00gle.com http://nasa.tap 0882134215 0882134333 08992134215 0558123 3333 1