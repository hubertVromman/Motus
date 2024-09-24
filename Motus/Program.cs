
namespace Motus
{
    internal class Program
    {
    
        static void Main(string[] args)
        {

            string Essai;
            bool fin = false;
            string Word = ChercheMot();
            
            Console.WriteLine($"{Word[0]} _ _ _ _ _ _ _\n");

            while (!fin)
            {

                Console.WriteLine("Entrez un mot de 8 lettres : ");
                Essai = Console.ReadLine();

                // appelle fct pour comparer les lettres
                Letter[] CharWord = Verify.verifyWord(Essai, Word);

                for (int i = 0; i < 8; i++)
                {
                    if (CharWord[i].isWellPlaced)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(CharWord[i].letter);
                    }
                    else if (CharWord[i].isWrongPlaced)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(CharWord[i].letter);
                    }
                    else if (CharWord[i].notPresent)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(CharWord[i].letter);
                    }
                    Console.Write(" ");
                }
                Console.WriteLine("\n\n");

                int cpt = 0;
                foreach (Letter l in CharWord)
                {
                    if (l.isWellPlaced)
                    {
                        cpt++;
                    }
                }

                if (cpt == 8)
                    fin = true;
            }
            

        }
        public static string ChercheMot()
        {
            Random rnd = new Random();
            int random = rnd.Next(20);
            string mot = ((Dico)random).ToString();
            return mot;
        }
    }
}







