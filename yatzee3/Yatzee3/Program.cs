    namespace Yatzee3
{
    internal class Program
    {
        
        public class StartNewGame
        {
            public static string standardRegler = @"REGLER:
    1.En spiller slår med terningerne.
    2.Spilleren kan vælge at beholde et eller flere terninger og kaste de resterende igen.
    3.Spilleren har tre kast i alt til at opnå den ønskede kombination.
    4.Når spilleren er tilfreds med et kast, skal de vælge en kombination fra scorekortet og notere summen af de valgte terninger i feltet.
    5.En kombination kan kun bruges én gang.
    6.Spillet fortsætter med, at spillerne skiftes til at kaste terningerne.
    Og der er bonus ved 63: 50p og 93: 100p" + "\n";

            public static void Velkomst()
            {

                //Velkost og Regler

                string velkomstBesked = "Hej nye spillere!\nVelkommen til yatzee!\n\n";
                

                Console.WriteLine(velkomstBesked + Program.StartNewGame.standardRegler);
            }

            public static int ChoosePlayers()
            {
                                //Spiller antal valg med do-while og switch til at vælge 2 eller 3 spillere (burde måske laves med try/catch/exception)
                string question = "\nHvor mange spillere er I? Skriv 2 eller 3 og tryk enter: ";
                int[] answers = { 2, 3 };

                int chooseAgain = 1;
                int playerCount;
                do
                {
                    playerCount = Input.IntQuestion(question, answers, "Du skal svare med 2 eller 3");
                    switch (playerCount)
                    {
                        case 2:
                            Console.WriteLine("Du har valgt 2 spillere, tryk enter for at begynde...");
                            chooseAgain = 1;
                            break;
                        case 3:
                            Console.WriteLine("Du har valgt 3 spillere, tryk enter for at begynde...");
                            chooseAgain = 1;
                            break;
                        default:
                            Console.WriteLine("Du skal skrive 2 eller 3 og derefter enter");
                            chooseAgain = 0;
                            break;

                    }
                } while (chooseAgain == 0);

                return playerCount;

                /*
                //enter eller whatever for continue. Clearer consol og viser scoreboard for 2 eller 3 personer
                Console.ReadLine();
                Console.Clear();

                if (playerCount == 2)
                { Scoreboard.createScoreBoard2(); }
                else
                { Scoreboard.createScoreBoard3(); }

               
                */
            }

        }

        public class Scoreboard
        {
            public static void CheckForBonus(string[,] scoreboard, int player)
            {
                int score = 0;

                // gennemgår scorene i 1-6
                for (int s = 1; s <= 6; s++)
                {
                    string x = scoreboard[s, player];
                    try
                    {                        
                        score += int.Parse(scoreboard[s, player]);
                    }
                    catch (System.FormatException)
                    { score += 0; }
                }

                if (score > 92)
                {
                    scoreboard[15, player] = "50"; // indsæt på bonus 63
                    scoreboard[16, player] = "50"; // indsæt på bonus 93
                }
                else if (score > 62)
                {
                    scoreboard[15, player] = "50"; // indsæt på bonus 63
                }

            }

            public static void PrintScoreboard(string[,] scoreBoardArr)
            {
                Console.WriteLine("\t\tSCOREBOARD");
                for (int i = 0; i < scoreBoardArr.GetLength(0); i++)
                {
                    for (int j = 0; j < scoreBoardArr.GetLength(1); j++)
                    {
                        {
                            System.Console.Write($"{scoreBoardArr[i, j]} ");
                        }
                        System.Console.Write("\t\t");
                    }
                    System.Console.WriteLine();
                }
                Console.WriteLine();
            }

            //Laver scoreboard med 3*17 til 2 spillere med score kategorier og spiller1 og spiller2, printer derefter til consol
            public static string[,] createScoreBoard2()
            {
                string[,] scoreBoardArr = new string[,]  { { "Score", "Player1", "Player2" }, { "1'ere", "", "" }, { "2'ere", "", "" }, { "3'ere", "", "" },
                    { "4'ere", "", "" }, { "5'ere", "", "" }, { "6'ere", "", "" }, { "1 Par", "", "" }, { "2 Par", "", "" }, { "3 ens", "", "" }, 
                    { "4 ens", "", "" }, { "Li straigth", "", "" }, { "St straight", "", "" }, { "Chancen", "", "" }, { "Yatzee", "", "" }, { "Bonus63", "", "" }, { "Bonus93", "", "" }, };

                PrintScoreboard(scoreBoardArr);

                return scoreBoardArr;

            }

            //Laver scoreboard med 4*17 til 3 spillere med score kategorier og spiller1, spiller2 og spiller3 printer derefter til consol
            public static string[,] createScoreBoard3()
            {
                string[,] scoreBoardArr = new string[,]  { { "Score", "Player1", "Player2", "Player3" }, { "1'ere", "", "", "" }, { "2'ere", "", "", "" }, { "3'ere", "", "", "" },
                    { "4'ere", "", "", "" }, { "5'ere", "", "", "" }, { "6'ere", "", "", "" }, { "1 Par", "", "", "" }, { "2 Par", "", "", "" }, { "3 ens", "", "", "" },
                    { "4 ens", "", "", "" }, { "Li straigth", "", "", "" }, { "St straight", "", "", "" }, { "Chancen", "", "", "" }, { "Yatzee", "", "", "" }, { "Bonus63", "", "", "" }, { "Bonus93", "", "", "" }, };

                PrintScoreboard(scoreBoardArr);

                return scoreBoardArr;

            }

            //// 1: lav scoreboard-array med playerCount 2: udfyld scoreNavne i søjle 0
            ////Scoreboard opstart, laver en 2-dimensionel array som har række længde: spillerantal + 1. og en kolonne højde: 17
            ////Kolonne højde er 17: 1 spillernavn, 14 score muligheder, 2 bonus
            ////Række længden er 3 - 4: 1 Score, 2 - 3 spillere(mindst 2 spillere)
            //playerCount = playerCount + 1;
            //string[,] scoreBoard = new string[playerCount, 17];

            //clearer console og indsætter scoreboard som det første så det altid står øverst/samme sted
            public static void permScore()
            {
                Console.Clear();
                Scoreboard.createScoreBoard2();
               
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

            // spillet starter
            StartNewGame.Velkomst();

            // vælg antal spillere
            int players = 2; //StartNewGame.ChoosePlayers(); // 2 til test

            // initialiserer scoreboard
            string[,] scoreBoard;

            if (players == 2)
                scoreBoard = Scoreboard.createScoreBoard2();
            else
                scoreBoard = Scoreboard.createScoreBoard3();

            //scoreBoard[1, 1] = "5"; // sætter Spiller 1's 1'ere til 5 / til test

            //start spil
            Console.Write("Tryk enter for at komme i gang!");
            Console.ReadKey();
            Console.Clear();

            // turene kører
            int turns = 4; //scoreBoard.GetLength(0); // 4 ture til test

            for (int t = 1; t <= turns; t++)
            {
                //det bliver første spillers tur
                for (int p = 1; p <= players; p++)
                {
                    Console.Clear();
                    Console.WriteLine($"Det er {scoreBoard[0, p]}; {t}. tur.\n");

                    Play.Throw(scoreBoard, p, t);
                    

                    Console.Clear();
                    Program.Scoreboard.PrintScoreboard(scoreBoard);

                    Console.Write("\nTryk inter for at fortsætte spillet.");
                    Console.ReadKey();

                    Console.Clear();
                }
            }

            Console.ReadKey();

        }
    }
}
