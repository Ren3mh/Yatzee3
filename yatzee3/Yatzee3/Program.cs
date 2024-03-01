    namespace Yatzee3
{
    internal class Program
    {
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

        public class StartNewGame
        {
            public static void Velkomst()
            {

                //Velkost og Regler

                string velkomstBesked = "Hej nye spillere!\nVelkommen til yatzee!\n\n";
                string standardRegler = @"REGLER:
    1.En spiller slår med terningerne.
    2.Spilleren kan vælge at beholde et eller flere terninger og kaste de resterende igen.
    3.Spilleren har tre kast i alt til at opnå den ønskede kombination.
    4.Når spilleren er tilfreds med et kast, skal de vælge en kombination fra scorekortet og notere summen af de valgte terninger i feltet.
    5.En kombination kan kun bruges én gang.
    6.Spillet fortsætter med, at spillerne skiftes til at kaste terningerne.
    Og der er bonus ved 63: 50p og 93: 100p" + "\n";

                Console.WriteLine(velkomstBesked + standardRegler);
            }

        }

        public class ScoreBoard
        {

            public static void PrintScoreBoard(string[,] scoreBoardArr)
            {
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
            }

            //Laver scoreboard med 3*17 til 2 spillere med score kategorier og spiller1 og spiller2, printer derefter til consol
            public static string[,] createScoreBoard2()
            {
                string[,] scoreBoardArr = new string[,]  { { "Score", "Player1", "Player2" }, { "1'ere", "", "" }, { "2'ere", "", "" }, { "3'ere", "", "" },
                    { "4'ere", "", "" }, { "5'ere", "", "" }, { "6'ere", "", "" }, { "1 Par", "", "" }, { "2 Par", "", "" }, { "3 ens", "", "" }, 
                    { "4 ens", "", "" }, { "Li straigth", "", "" }, { "St straight", "", "" }, { "Chancen", "", "" }, { "Yatzee", "", "" }, { "Bonus63", "", "" }, { "Bonus93", "", "" }, };

                PrintScoreBoard(scoreBoardArr);

                return scoreBoardArr;

            }

            //Laver scoreboard med 4*17 til 3 spillere med score kategorier og spiller1, spiller2 og spiller3 printer derefter til consol
            public static string[,] createScoreBoard3()
            {
                string[,] scoreBoardArr = new string[,]  { { "Score", "Player1", "Player2", "Player3" }, { "1'ere", "", "", "" }, { "2'ere", "", "", "" }, { "3'ere", "", "", "" },
                    { "4'ere", "", "", "" }, { "5'ere", "", "", "" }, { "6'ere", "", "", "" }, { "1 Par", "", "", "" }, { "2 Par", "", "", "" }, { "3 ens", "", "", "" },
                    { "4 ens", "", "", "" }, { "Li straigth", "", "", "" }, { "St straight", "", "", "" }, { "Chancen", "", "", "" }, { "Yatzee", "", "", "" }, { "Bonus63", "", "", "" }, { "Bonus93", "", "", "" }, };

                PrintScoreBoard(scoreBoardArr);

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
                ScoreBoard.createScoreBoard2();
               
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

            


            // skaber scoreboard
            string[,] scoreBoard = ScoreBoard.createScoreBoard2();

            //det bliver første spillers tur
            Play.Turn(scoreBoard, 1);
            Program.ScoreBoard.PrintScoreBoard(scoreBoard);

            Console.ReadKey();

            //Scoreboard.Velkomst();

            ////Spiller antal valg med do-while og switch til at vælge 2 eller 3 spillere (burde måske laves med try/catch/exception)
            //Console.WriteLine("\n Hvor mange spillere er I?\n" +
            //    "skriv 2 eller 3 og tryk enter");

            //int chooseAgain = 1;
            //int playerCount;
            //do
            //{
            //    playerCount = int.Parse(Console.ReadLine());
            //    switch (playerCount)
            //    {
            //        case 2:
            //            Console.WriteLine("Du har valgt 2 spillere, tryk enter for at begynde...");
            //            chooseAgain = 1;
            //            break;
            //        case 3:
            //            Console.WriteLine("Du har valgt 3 spillere, tryk enter for at begynde...");
            //            chooseAgain = 1;
            //            break;
            //        default:
            //            Console.WriteLine("Du skal skrive 2 eller 3 og derefter enter");
            //            chooseAgain = 0;
            //            break;

            //    }
            //} while (chooseAgain == 0);

            
            ////enter eller whatever for continue
            //Console.ReadLine();
            //Console.Clear() ;

            //if (playerCount == 2)
            //    { Scoreboard.createScoreBoard2(); }
            //else
            //{ Scoreboard.createScoreBoard3(); }

            //Console.WriteLine("\n\nSpiller1 din terning... Din terning blev... Hvor vil du gemme? Tryk enter");
            //Console.ReadLine() ;


            //Scoreboard.permScore();
            //Console.WriteLine("\n\nSpiller2 din terning... Din terning blev... Hvor vil du gemme? Tryk enter");

            //Console.ReadLine();

            
        }
    }
}
