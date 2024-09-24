using System.Security.Cryptography.X509Certificates;

namespace Motus {
    internal class Program {
        static void Main(string[] args) {
             
        }

        public string ChercheMot()
        {
            Random rnd = new Random();
            int random = rnd.Next(20);
            string mot = ((Dictionnaire)random).ToString();
            return mot;
        }

    }
}
