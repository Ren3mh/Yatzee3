using static Yatzee3.Play;

namespace Yatzee3
{
    // der skal laves exception handling ift. valg af terninger i "input", i Play.DicesToKeep
    // der skal laves exception handling ift. valg af score i "input", i Score.ChooseScore
    internal class Play
    {
        public class Dice
        {
            Random rnd = new Random();

            // instance variables
            public int diceNumber = 1;
            public bool keepDice = false;

            //Array til at gemme terningmønstre
            private string[] dicePatterns =
            {

                    "+-------+\n|       |\n|   *   |\n|       |\n+-------+", // 1

                    "+-------+\n| *     |\n|       |\n|     * |\n+-------+", // 2
            
                    "+-------+\n| *     |\n|   *   |\n|     * |\n+-------+", // 3
                
                    "+-------+\n| *   * |\n|       |\n| *   * |\n+-------+", // 4
            
                    "+-------+\n| *   * |\n|   *   |\n| *   * |\n+-------+", // 5
            
                    "+-------+\n| *   * |\n| *   * |\n| *   * |\n+-------+"  // 6


            };


            // methods
            public int RollDice()
            {
                diceNumber = rnd.Next(1, 7);
                return diceNumber;
            }

            //Metode til at få det visuelle terningmønster
            //public string[] getdicepattern()
            //{
            //    return dicepatterns[dicenumber - 1];// -1, fordi array indekser starter fra 0
            //}
        }

        public static void Throw(string[,] scoreBoard, int player, int turn, int throws = 3)
        {
            int score = 0;

            // array med terninger og initialiseres
            Dice[] dices = CreateDices();

            // kastene starter
            
            for (int i = 0; i < throws; i++)
            {
                if (i == throws-1)
                {
                    Console.WriteLine("Det er dit {0}. og sidste kast!", i + 1);

                    // terningerne kastes en sidste gang
                    RollDices(dices);
                    break;
                }

                else
                {
                    
                    Console.WriteLine("Dit {0}. kast.", i + 1);

                    // terningerne kastes
                    RollDices(dices);

                    //terningerne vælges/gemmes
                    DicesToKeep(dices);
                }
            }
            
                        //test
            // dices instantiates til test
            Play.Dice[] dices_ = new Play.Dice[5];
            for (int i = 0; i < 5; i++)
            {
                dices_[i] = new Play.Dice();

            }
            dices_[0].diceNumber = 1;
            dices_[1].diceNumber = 2;
            dices_[2].diceNumber = 2;
            dices_[3].diceNumber = 1;
            dices_[4].diceNumber = 1;

            int[] choosenScore = Score.ChooseScore(dices, scoreBoard, player);

            scoreBoard[choosenScore[0], player] = Convert.ToString(choosenScore[1]);
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

            do
            {
                try
                {
                    int[] input = Input.ArrInteger("Vælg terninger der skal gemmes: ", maxNumbers: 6);

                    foreach (int i in input)
                        dices[i-1].keepDice = true;
                }
                catch (IndexOutOfRangeException)
                { 
                    Console.WriteLine("Du kan kun indtaste tal mellem 1-6.\nØnsker du ikke at gemme nogle tryk enter.");
                }

                break;

            } while (true);

            Console.Clear();
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
            public int[] Scores = new int[14];
            public string[] ScoreNames = 
            {
                "1'ere",
                "2'ere",
                "3,ere",
                "4'ere",
                "5'ere",
                "6,ere",
                "Et Par",
                "To Par",
                "Tre Ens",
                "Fire Ens",
                "Lille Straight",
                "Stor Straight",
                "Chancen",
                "Yatzy"
            };

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

                // tjek score ved 1'ere - 6'ere
                int SameNumber(int[] dicesNumbers, int number)
                {
                    int score = 0;

                    foreach (int diceNumber in dicesNumbers)
                        if (diceNumber == number)
                            score += diceNumber;

                    return score;
                }

                int Pair(int[] dicesNumbers, int usedPair = -1)
                {
                    Array.Reverse(dicesNumbers);
                    int score = 0;

                    // find bedste mulige par
                    for (int i = 0; i < dicesNumbers.Length; i++)
                    {
                        if (dicesNumbers[i] == usedPair)
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

                    // se om der er fire ens, hvilket er to par
                    int samePair = FindxSame(dicesNumbers, 4);
                    if (samePair != 0)
                        return samePair;

                    // hvis der ikke er fire ens
                    int par1Score = Pair(dicesNumbers);

                    // remove used numbers
                    int usedPair = par1Score / 2;
                    int par2Score = Pair(dicesNumbers, usedPair);
                    
                    //hvis der ikke er et andet par retuneres 0
                    if (par2Score == 0)
                        return 0;
                    else
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

        public static int[] ChooseScore(Dice[] dices, string[,] scoreBoard, int player) // retunerer {scorename som int, score}
        {
            Kombinationer kombi = new Kombinationer(dices);
            int[] choosenScore = new int[2];

            Console.WriteLine("\nDine mulige Scores:");
            for (int i = 1; i < 15; i++)
            {
                if (scoreBoard[i,player] != "")
                    continue;
                Console.WriteLine($"\tTast {i} for:\t{kombi.ScoreNames[i-1]}: {kombi.Scores[i-1]} point");
            }

            Console.Write("Hvad vælger du? ");
            int input = int.Parse(Console.ReadLine());

            choosenScore[0] = input;
            choosenScore[1] = kombi.Scores[input - 1];

            return choosenScore;
        }
    }

    internal class Input
    {
        public static string StringQuestion(string question, string[] possibleAnswers, string errorMessage)
        {
            do
            {
                Console.Write(question);
                string reply = Console.ReadLine().ToLower();

                foreach (string answer in possibleAnswers)
                {
                    if (answer.ToLower() == reply)
                        return answer;
                }

                PrintPossibleAnswers(errorMessage, possibleAnswers);

            } while (true);
        }

        public static int IntQuestion(string question, int[] possibleAnswers, string errorMessage)
        {
            do
            {
                int reply;

                do
                {
                    Console.Write(question);
                    try
                    {
                        reply = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception ex)
                    { Console.WriteLine("Du skal svare med et tal."); }

                } while (true);

                foreach (int answer in possibleAnswers)
                {
                    if (answer == reply)
                        return answer;
                }

                PrintPossibleAnswers(errorMessage, Array.ConvertAll(possibleAnswers, Convert.ToString));

            } while (true);
        }

        public static int[] ArrInteger(string question, int minNumbers = -1, int maxNumbers = -1)
        {
            do
            {

                Console.WriteLine(question);

                string reply = Console.ReadLine();

                int[] answer = new int[reply.Length];
                
                try
                {
                    for (int i = 0; i < answer.Length; i++)
                    {
                        answer[i] = int.Parse(reply[i].ToString());
                    }
                }
                catch (Exception)
                { 
                    Console.WriteLine("Du skal indtaste en talrække uden mellemrum, og afslutte med enter.");
                    continue;
                }

                int answerLength = answer.Length;

                if (maxNumbers == -1 && minNumbers == -1)
                    return answer;
                
                else if (answerLength >= minNumbers && maxNumbers == -1)
                    return answer;

                else if (answerLength <= maxNumbers && minNumbers == -1)
                    return answer;

                else if (answerLength <= maxNumbers && answerLength >= minNumbers)
                    return answer;

                else
                    Console.WriteLine("Du kan indtaste mellem {0} og {1} tal.", minNumbers, maxNumbers);
        
            } while (true);
        }

        public static bool YesNo()
        {
            do
            {
                Console.Write(", hvad vælger du y/n? ");
                string reply = Console.ReadLine();

                switch (reply)
                {
                    case "Y":
                    case "y":
                        return true;

                    case "N":
                    case "n":
                        return false;

                    default:
                        Console.Write("Du skal svare med \"y\" eller \"n\"");
                        break;
                }
            } while (true);
        }

        static void PrintPossibleAnswers(string errorMessage, string[] possibleAnswers)
        {
            Console.WriteLine(errorMessage + ". Dine svarmuligheder er:"); // fandt intet muligt svar

            for (int i = 0; i < possibleAnswers.Length; i++)
            {
                if (i != possibleAnswers.Length - 1)
                {
                    Console.Write(possibleAnswers[i] + ", ");
                }
                else
                    Console.WriteLine(possibleAnswers[i] + ".");
            }
        }

        
    }

}
