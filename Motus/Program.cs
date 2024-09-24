using System.Diagnostics.Metrics;

namespace Motus
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string Essai;
            bool fin = false;

            Letter firstLetter = start();
            Console.WriteLine($"{firstLetter.letter} _ _ _ _ _ _ _\n");

            while (!fin)
            {

                Console.WriteLine("Entrez un mot de 8 lettres : ");
                Essai = Console.ReadLine();

                // appelle fct pour comparer les lettres
                Letter[] mots = Compare(Essai);

                for (int i = 0; i < 8; i++)
                {
                    if (mots[i].isWellPlaced)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(mots[i].letter);
                    }
                    else if (mots[i].isWrongPlaced)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(mots[i].letter);
                    }
                    else if (mots[i].isNotPresent)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("_");
                    }
                    Console.Write(" ");
                }
                Console.WriteLine("\n\n");

                int cpt = 0;
                foreach (Letter l in mots)
                {
                    if (!l.isWellPlaced)
                    {
                        cpt++;
                    }
                }

                if (cpt == 8)
                    fin = true;
            }
        }
    }
}

