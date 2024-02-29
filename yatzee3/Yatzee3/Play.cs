using static Yatzee3.Play;

namespace Yatzee3
{
    // der skal laves exception handling ift. valg af terninger i "input", i DicesToKeep
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

        public static int Turn(Program.ScoreBoard scoreBoard, int turns = 3)
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

            score = Score.ChooseScore(dices);

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

    internal class Score
    {
        public class Kombinationer
        {
            // kombinationer
            public int EnEre;
            public int ToEre;
            public int TreEre;
            public int FireEre;
            public int FemEre;
            public int SeksEre;
            public int EtPar;
            public int ToPar;
            public int TreEns;
            public int FireEns;
            public int LilleStraight;
            public int StorStraight;
            public int Chancen_;
            public int Yatzy_;

            public int[] Scores = new int[14];

            public Kombinationer(Play.Dice[] dices_)
            {
                int[] dices = dicesToArray(dices_);

                // find the best score each
                Scores[0] = SameNumber(dices, 1);
                Scores[1] = SameNumber(dices, 2);
                Scores[2] = SameNumber(dices, 3);
                Scores[3] = SameNumber(dices, 4);
                Scores[4] = SameNumber(dices, 5);
                Scores[5] = SameNumber(dices, 6);
                Scores[6] = Pair(dices);
                Scores[7] = TwoPairs(dices);
                Scores[8] = FindxSame(dices, 3);
                Scores[9] = FindxSame(dices, 4);
                Scores[10] = Straight(dices, false);
                Scores[11] = Straight(dices, true);
                Scores[12] = Chancen(dices);
                Scores[13] = Yatzy(dices);

                EnEre = SameNumber(dices, 1);
                ToEre = SameNumber(dices, 2);
                TreEre = SameNumber(dices, 3);
                FireEre = SameNumber(dices, 4);
                FemEre = SameNumber(dices, 5);
                SeksEre = SameNumber(dices, 6);
                EtPar = Pair(dices);
                ToPar = TwoPairs(dices);
                TreEns = FindxSame(dices, 3);
                FireEns = FindxSame(dices, 4);
                LilleStraight = Straight(dices, false);
                StorStraight = Straight(dices, true);
                Chancen_ = Chancen(dices);
                Yatzy_ = Yatzy(dices);

                // tjek score ved 1'ere - 6'ere
                int SameNumber(int[] dicesNumbers, int number)
                {
                    int score = 0;

                    foreach (int diceNumber in dicesNumbers)
                        if (diceNumber == number)
                            score += diceNumber;

                    return score;
                }

                int Pair(int[] dicesNumbers, int used = -2)
                {
                    Array.Reverse(dicesNumbers);
                    int score = 0;

                    // find bedste mulige par
                    for (int i = 0; i < dicesNumbers.Length; i++)
                    {
                        if (dicesNumbers[i] == used || dicesNumbers[i] == used + 1)
                            continue;

                        int posibleScore = 0;
                        int number1 = dicesNumbers[i];

                        for (int j = i + 1; j < dices.Length; j++)
                        {
                            if (number1 == dicesNumbers[j])
                                posibleScore = number1 * 2;
                        }

                        //se om paret er bedre
                        if (posibleScore == 12)
                            return 12;
                        else if (posibleScore > score)
                            score = posibleScore;
                    }
                    return score;
                }

                int TwoPairs(int[] dicesNumbers)
                {
                    Array.Sort(dicesNumbers);
                    Array.Reverse(dicesNumbers);

                    int score = 0;

                    int par1Score = Pair(dicesNumbers);

                    // remove used numbers
                    int used = -2;
                    for (int i = 0; i < dices.Length; i++)
                    {
                        if (dicesNumbers[i] == par1Score / 2)
                        {
                            used = i;
                            break;
                        }
                    }

                    int par2Score = Pair(dicesNumbers, used);

                    return par1Score + par2Score;
                }

                int FindxSame(int[] dicesNumbers, int x)
                {
                    int[] destinct = dicesNumbers.Distinct().ToArray();

                    foreach (int num in destinct)
                    {
                        int times = 0;

                        for (int i = 0; i < dicesNumbers.Length; i++)
                        {
                            if ((dicesNumbers[i] == num))
                                times++;

                            if (times == x)
                                return times * num;
                        }
                    }
                    return 0;
                }

                int Straight(int[] dicesNumbers, bool stor)
                {
                    int[] destinct = dicesNumbers.Distinct().ToArray();

                    if (destinct.Length < 4)
                        return 0;

                    else if (destinct[0] == 6 && stor == true)
                        return 20;

                    else if (destinct[0] == 5 && stor == false)
                        return 15;

                    else
                        return 0;

                }

                int Chancen(int[] dicesNumbers)
                {
                    int score = 0;
                    foreach (int num in dicesNumbers) { score += num; }
                    return score;
                }

                int Yatzy(int[] dicesNumbers)
                {
                    int[] destinct = dicesNumbers.Distinct().ToArray();
                    if ((destinct.Length > 1))
                        return 0;
                    else
                        return 50;
                }

                int[] dicesToArray(Play.Dice[] dices)
                {
                    int[] diceNumbers = new int[dices.Length];
                    for (int i = 0; i < dices.Length; i++)
                        diceNumbers[i] = dices[i].diceNumber;
                    Array.Sort(diceNumbers); // sorterer dem lav->høj

                    return diceNumbers;
                }

            }
        }

        public static int ChooseScore(Dice[] dices)
        {
            Kombinationer kombinationer = new Kombinationer(dices);

            Program.ScoreBoard.

            Console.WriteLine("Dine mulige Scores:");

            

        }
    }
}
