namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static List<int> Filtrer(List<int> entiers, Func<int, bool> filtre)
        {
            List<int> result = new();

            foreach (int entier in entiers)
            {
                if (filtre(entier))
                {
                    result.Add(entier);
                }
            }
            return result;
        }

        public static List<dynamic> GetCarreType(List<float> liste)
        {
            List<dynamic> result1 = new();

            foreach (var item in liste)
            {
                Type type = item.GetType();
                dynamic carre = Convert.ChangeType(item * item, type);
                result1.Add(carre);
            }
            return result1;
        }

        public static List<dynamic> GetCarreTypeLambda(List<float> liste, Func<List<float>, List<dynamic>> filtre)
        {
            List<dynamic> result2 = new();

            var preList = filtre(liste);

            foreach (var item in preList)
            {
                result2.Add(item);
            }
            return result2;
        }
        static void Main(string[] args)
        {
            List<int> entiers = new() { 1, 2, 3, 4, 5 };

            // Filtrer les nombres pairs
            List<int> pairs = Filtrer(entiers, x => x % 2 == 0);
            Console.WriteLine(string.Join(", ", pairs));
            // Affiche "2, 4"
            // Filtrer les nombres impairs
            List<int> impairs = Filtrer(entiers, x => x % 2 == 1);
            Console.WriteLine(string.Join(", ", impairs));
            // Affiche "1, 3, 5"
            // Filtrer les nombres plus grands que 3
            List<int> grands = Filtrer(entiers, x => x > 3);
            Console.WriteLine(string.Join(", ", grands));
            // Affiche "4, 5"

            List<float> nbDecimal = new() { 1.342f, 2.321f, 6.321f };

            List<dynamic> test = GetCarreType(nbDecimal);
            Console.WriteLine(string.Join(", ", test));

            Func<List<float>, List<dynamic>> passoire = maListe =>
            {
                List<dynamic> truc = new();

                foreach (var item in maListe)
                {
                    dynamic carre = item * item;
                    truc.Add(carre);
                }

                return truc;
            };

            List<dynamic> test2 = GetCarreTypeLambda(nbDecimal, passoire);
            Console.WriteLine(string.Join(", ", test2));
        }
    }
}