using System;

namespace AlstolphoBot
{
    public class ConsoleTools
    {
        ///<summary>
        ///Log own Messages to console
        ///</summary>
        public static void Print(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{DateTime.Now} {message}");
            Console.ResetColor();
        }
    }
}