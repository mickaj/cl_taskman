using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            AppRunner app = new AppRunner(new ConsoleEx());

            app.Start();
        }
    }
}
