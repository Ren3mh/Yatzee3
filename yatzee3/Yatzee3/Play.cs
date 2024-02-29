using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Yatzee3
{
    internal class Play
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

        public static int Main(int turns = 3)
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

            //ChooseScore(dices);

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

        //static void ChooseScore(Dice[] dices)
        //{
        //    // mulige scores printes
        //    Score.Kombinationer kombis = FindScores(dices);

        //    Console.WriteLine("Nu kan du vælge disse score: ");

        //    Console.WriteLine("\t1'ere: " + kombis.EnEre);
        //    Console.WriteLine("\t2'ere: " + kombis.ToEre);
        //    Console.WriteLine("\t3'ere: " + kombis.TreEre);
        //    Console.WriteLine("\t4'ere: " + kombis.FireEre);
        //    Console.WriteLine("\t5'ere: " + kombis.FemEre);
        //    Console.WriteLine("\t6'ere: " + kombis.SeksEre);
        //    Console.WriteLine("\tPar: " + kombis.EtPar);
        //    Console.WriteLine("\tTo Par: " + kombis.ToPar);
        //    Console.WriteLine("\tTre Ens: " + kombis.TreEns);
        //    Console.WriteLine("\tFire Ens: " + kombis.FireEns);
        //    Console.WriteLine("\tLille Straight: " + kombis.LilleStraight);
        //    Console.WriteLine("\tStor Straight: " + kombis.StorStraight);
        //    Console.WriteLine("\tChancen: " + kombis.Chancen);
        //    Console.WriteLine("\tYatzy: " + kombis.Yatzy);

        //}
    }
}
