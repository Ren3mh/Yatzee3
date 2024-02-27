namespace Yatzee3
{
    internal class Program
    {

        public class Dice
        {
            Random rnd = new Random();

            // instance variables
            public int diceNumber = 1;

            // methods
            public int RollDice()
            {
                diceNumber = rnd.Next(1, 7);
                return diceNumber;
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Renés roderi:
            Console.WriteLine("velkommen til yatzee!");

            Console.WriteLine("spiller 1, skriv dit navn og afslut med enter:");
            string spiller1 = Console.ReadLine();

            Console.WriteLine("spiller 2, skriv dit navn og afslut med enter:");
            string spiller2 = Console.ReadLine();


            Console.WriteLine(spiller1 + " kast terningerne med enter!");
            Console.ReadLine();
            {
                int terning1, terning2, terning3, terning4, terning5;
                Random r = new Random();
                terning1 = r.Next(1, 6);
                terning2 = r.Next(1, 6);
                terning3 = r.Next(1, 6);
                terning4 = r.Next(1, 6);
                terning5 = r.Next(1, 6);
                Console.WriteLine(spiller1 + " du har slået: " + terning1 + ", " + terning2 + ", " + terning3 + ", " + terning4 + " & " + terning5);
            }

            /*
            if (input < 9)
            {
                // input is less than 9.
                system.console.writeline(
                    "tic-tac-toe has more than {0}" +
                     " maximum turns.", input);
            }
            */
            Console.ReadLine();
        }
    }
}
