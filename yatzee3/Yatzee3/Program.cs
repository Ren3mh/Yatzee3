    namespace Yatzee3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hej nye spillere!");

            Console.WriteLine("Velkommen til yatzee!\n\n");

            Console.WriteLine("REGLER:\n" +
                "\t1.En spiller slår med terningerne. \n\n" +
                "\t2.Spilleren kan vælge at beholde et eller flere terninger og kaste de resterende igen. \n\n" +
                "\t3.Spilleren har tre kast i alt til at opnå den ønskede kombination.\n\n" +
                "\t4.Når spilleren er tilfreds med et kast, skal de vælge en kombination fra scorekortet og notere summen af de valgte terninger i feltet.\n\n" +
                "\t5.En kombination kan kun bruges én gang.\n\n" +
                "\t6.Spillet fortsætter med, at spillerne skiftes til at kaste terningerne.\n\n");

            Console.WriteLine("Hvor mange spillere er I?\n" +
                "skriv 2 eller 3 og tryk enter");
            int playerCount = int.Parse(Console.ReadLine());

            //
            switch(playerCount)
            {
                case 2:
                    Console.WriteLine("Du har valgt 2 spillere");
                        break;
                case 3:
                    Console.WriteLine("Du har valgt 3 spillere");
                        break;
                default:
                    Console.WriteLine("Du skal skrive 2 eller 3 og derefter enter");
                    break;
                
            }



            //string[,] scoreBoard = { { 1, 4, 2 }, { 3, 6, 8 } };
            // Kolonne højde er 17: 1 spillernavn, 14 score muligheder, 2 bonus
            // Række længden er 3-4: 1 Score, 2-3 spillere (mindst 2 spillere)

            Console.ReadLine();
        }
    }
}
