﻿    namespace Yatzee3
{
    internal class Program
    {

        public class Dice
        {
            Random rnd = new Random();

            // instance variables
            public int diceNumber = 1;
            public bool keepDice = false;

            // methods
            public int RollDice()
            {
                diceNumber = rnd.Next(1, 7);
                return diceNumber;
            }

        }

        /*
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
        */

        public class Scoreboard
        {
            public static void Velkomst()
            {
                
                //Velkost og Regler
                Console.WriteLine("Hej nye spillere!");

                Console.WriteLine("Velkommen til yatzee!\n\n");

                Console.WriteLine("REGLER:\n" +
                    "\t1.En spiller slår med terningerne. \n\n" +
                    "\t2.Spilleren kan vælge at beholde et eller flere terninger og kaste de resterende igen. \n\n" +
                    "\t3.Spilleren har tre kast i alt til at opnå den ønskede kombination.\n\n" +
                    "\t4.Når spilleren er tilfreds med et kast, skal de vælge en kombination fra scorekortet \n" +
                    "og notere summen af de valgte terninger i feltet.\n\n" +
                    "\t5.En kombination kan kun bruges én gang.\n\n" +
                    "\t6.Spillet fortsætter med, at spillerne skiftes til at kaste terningerne.\n\n" +
                    "\tOg der er bonus ved 63: 50p og 93: 100p \n\n)");
            }



            //// 1: lav scoreboard-array med playerCount 2: udfyld scoreNavne i søjle 0
            ////Scoreboard opstart, laver en 2-dimensionel array som har række længde: spillerantal + 1. og en kolonne højde: 17
            ////Kolonne højde er 17: 1 spillernavn, 14 score muligheder, 2 bonus
            ////Række længden er 3 - 4: 1 Score, 2 - 3 spillere(mindst 2 spillere)
            //playerCount = playerCount + 1;
            //string[,] scoreBoard = new string[playerCount, 17];
        }

        static void Main(string[] args)
        {

            Scoreboard.Velkomst();

            //Spiller antal valg med do-while og switch til at vælge 2 eller 3 spillere
            Console.WriteLine("Hvor mange spillere er I?\n" +
                "skriv 2 eller 3 og tryk enter");

            int chooseAgain = 1;
            int playerCount;
            do
            {
                playerCount = int.Parse(Console.ReadLine());
                switch (playerCount)
                {
                    case 2:
                        Console.WriteLine("Du har valgt 2 spillere");
                        chooseAgain = 1;
                        break;
                    case 3:
                        Console.WriteLine("Du har valgt 3 spillere");
                        chooseAgain = 1;
                        break;
                    default:
                        Console.WriteLine("Du skal skrive 2 eller 3 og derefter enter");
                        chooseAgain = 0;
                        break;

                }
            } while (chooseAgain == 0);



            //Scoreboard opstart, laver en 2-dimensionel array som har række længde: spillerantal + 1. og en kolonne højde: 17
            //Kolonne højde er 17: 1 spillernavn, 14 score muligheder, 2 bonus
            //Række længden er 3 - 4: 1 Score, 2 - 3 spillere(mindst 2 spillere)
            playerCount = playerCount + 1;
            string[,] scoreBoard = new string[playerCount, 17];

            Console.ReadLine();

        }

        static int Play(int turns = 3)
        {
            int score = 0;

            // array med terninger og initialiseres
            Dice[] dices = CreateDices();

            // turene starter
            for (int i = 0; i < turns; i++)
            {
                if (i == turns - 1)
                {
                    Console.WriteLine("Det er din {0}. og sidste tur!", i + 1);

                    // terningerne kastes en sidste gang
                    RollDices(dices);
                    break;
                }

                else
                {
                    Console.WriteLine("Din {0}. tur.", i + 1);

                    // terningerne kastes
                    RollDices(dices);

                    //terningerne vælges/gemmes
                    DicesToKeep(dices);
                }
            }

            PrintDices(dices);

            foreach (Dice dice in dices)
                score += dice.diceNumber;

            //int score = terning1.diceNumber + terning2.diceNumber;
            //Console.WriteLine("Terning: 1, 2: {0}, {1}", terning1.diceNumber, terning2.diceNumber);
            return score;
        }

        static void RollDices(Dice[] dices)
        {
            Console.WriteLine("Terningerne kastes!");

            for (int i = 0; i < dices.Length; i++)
            {
                if (dices[i].keepDice == false)
                    dices[i].RollDice();
                Console.WriteLine("Terning: {0} = {1}", i + 1, dices[i].diceNumber);
            }
        }

        static void DicesToKeep(Dice[] dices)
        {
            //sætter keepDice til false
            foreach (Dice dice in dices)
                dice.keepDice = false;

            Console.Write("Vælg terninger der skal gemmes: ");

            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                int keep = int.Parse(input[i].ToString()) - 1;
                dices[keep].keepDice = true;
            }

            PrintDices(dices);
        }

        static void PrintDices(Dice[] dices)
        {
            Console.WriteLine("Gemte terninger: ");
            for (int i = 0; i < dices.Length; i++)
            {
                switch (dices[i].keepDice)
                {
                    case true:
                        Console.WriteLine("\t Terning: {0} = {1}", i + 1, dices[i].diceNumber);
                        break;

                    case false:
                        break;
                }
            }
            Console.WriteLine();
        }

        static Dice[] CreateDices(int amount = 5)
        {
            Dice[] dices = new Dice[amount];

            for (int i = 0; i < 5; i++)
                dices[i] = new Dice();

            return dices;
        }
    }
}
