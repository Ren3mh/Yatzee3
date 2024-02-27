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

        public class Scoreboard
        {
            public class Kombination
            {
                public string Name;
                public int Value;

                // a constructor
                public Kombination(string name)
                {
                    Name = name;
                    Value = 0;

                }

            }


            // instance variables
            public Kombination par1 = new Kombination("Par 1");
            public Kombination par2 = new Kombination("Par 2");

            // methods
            public Kombination setScore(Kombination kombination, int score)
            {
                kombination.Value = score;
                return kombination;
            }

        }

        static void Main(string[] args)
        {

            ////Velkost og Regler
            //Console.WriteLine("Hej nye spillere!");

            //Console.WriteLine("Velkommen til yatzee!\n\n");

            //Console.WriteLine("REGLER:\n" +
            //    "\t1.En spiller slår med terningerne. \n\n" +
            //    "\t2.Spilleren kan vælge at beholde et eller flere terninger og kaste de resterende igen. \n\n" +
            //    "\t3.Spilleren har tre kast i alt til at opnå den ønskede kombination.\n\n" +
            //    "\t4.Når spilleren er tilfreds med et kast, skal de vælge en kombination fra scorekortet \n" +
            //    "og notere summen af de valgte terninger i feltet.\n\n" +
            //    "\t5.En kombination kan kun bruges én gang.\n\n" +
            //    "\t6.Spillet fortsætter med, at spillerne skiftes til at kaste terningerne.\n\n" +
            //    "\tOg der er bonus ved 63: 50p og 93: 100p \n\n)");

            ////Spiller antal valg med do-while og switch til at vælge 2 eller 3 spillere
            //Console.WriteLine("Hvor mange spillere er I?\n" +
            //    "skriv 2 eller 3 og tryk enter");
           
            //int chooseAgain = 1;
            //int playerCount;
            //do
            //{
            //    playerCount = int.Parse(Console.ReadLine());
            //    switch (playerCount)
            //    {
            //        case 2:
            //            Console.WriteLine("Du har valgt 2 spillere");
            //            chooseAgain = 1;
            //            break;
            //        case 3:
            //            Console.WriteLine("Du har valgt 3 spillere");
            //            chooseAgain = 1;
            //            break;
            //        default:
            //            Console.WriteLine("Du skal skrive 2 eller 3 og derefter enter");
            //            chooseAgain = 0;
            //            break;

            //    }
            //}while (chooseAgain == 0);



            ////Scoreboard opstart, laver en 2-dimensionel array som har række længde: spillerantal + 1. og en kolonne højde: 17
            ////Kolonne højde er 17: 1 spillernavn, 14 score muligheder, 2 bonus
            ////Række længden er 3 - 4: 1 Score, 2 - 3 spillere(mindst 2 spillere)
            //playerCount = playerCount + 1;
            //string[,] scoreBoard = new string[playerCount, 17];

            //Console.ReadLine();


                // sander
                /*
            // array med terninger initaliceres
            Dice[] dices = new Dice[5];

            for (int i = 0; i < dices.Length; i++)
            {
                dices[i] = new Dice();
            }


                
            // terningerne kastes
            Dice[] RollDices(Dice[] dices, int[] dicesToRoll = null)
            {

                // vælger terningerne der kaste
                if (dicesToRoll == null)
                    dicesToRoll = new int[5];

                Console.WriteLine("Terningerne kastes!");

                foreach (int roll in dicesToRoll)
                    dices[roll].RollDice();

                for (int i = 0; i < 5; i++)
                    Console.WriteLine("\tTerning {0} = {1}", i + 1, dices[i].diceNumber);

                return null;
            }

            RollDices(dices);

            //terningerne vælges
            Console.WriteLine("Vælg terninger der skal gemmes");

            string input = Console.ReadLine();

            int[] saves = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
                saves[i] = int.Parse(input[i].ToString());

            Console.Write("Terninger der gemmes: ");
            foreach (int i in saves)
                Console.Write(i + ", ");

            Console.WriteLine("Terningerne kastes igen");
            RollDices(dices, saves);
            */

            Console.ReadLine();

        }
    }
}
