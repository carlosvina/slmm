using System;

namespace SLMM
{
    class Program
    {

        static void Main(string[] args)
        {

            int width, length;                 
            
            if (args.Length == 2 && int.TryParse(args[0], out width) 
                && int.TryParse(args[1], out length))
            {
                Console.WriteLine($"Dimensions of the garden set from arguments: [width, length] = ({width}, {length})");
            }
            else
            {
                Console.WriteLine($"Couldn't load dimensions from command line arguments. Please specify: ");
                width = ParseValue("Width");
                length =ParseValue("Length");
            }

            ConsoleWrapper console = new ConsoleWrapper();

            var garden = new Garden(width, length, console);
            garden.Run();

        }

        private static int ParseValue(string dimension)
        {
            string strValue;
            int value;
            
            Console.Write($"{dimension}: ");
            strValue = Console.ReadLine();

            while (!int.TryParse(strValue, out value) || value <= 0)
            {
                Console.WriteLine("Please type a valid integer greater than zero");
                Console.Write($"{dimension}: ");
                strValue = Console.ReadLine();
            }

            return value;
        }
    }
    
}
