using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Class1
    {
        static int Minimums(int a, int b) => a < b ? a : b;

        static int Minimum(int a, int b, int c) => (a = a < b ? a : b) < c ? a : c;


        static int LevenshteinDistance(string firstWord, string secondWord)
        {
            var n = firstWord.Length + 1;
            var m = secondWord.Length + 1;
            var matrixD = new int[n, m];

            const int deletionCost = 1;
            const int insertionCost = 1;

            for (var i = 0; i < n; i++)
            {
                matrixD[i, 0] = i;
            }

            for (var j = 0; j < m; j++)
            {
                matrixD[0, j] = j;
            }

            for (var i = 1; i < n; i++)
            {
                for (var j = 1; j < m; j++)
                {
                    var substitutionCost = firstWord[i - 1] == secondWord[j - 1] ? 0 : 1;

                    matrixD[i, j] = Minimum(matrixD[i - 1, j] + deletionCost,          // удаление
                                            matrixD[i, j - 1] + insertionCost,         // вставка
                                            matrixD[i - 1, j - 1] + substitutionCost); // замена
                }
            }

            return matrixD[n - 1, m - 1];
        }

        static int LevenshteinDistance(string text1, int len1, string text2, int len2)
        {
            if (len1 == 0)
            {
                return len2;
            }

            if (len2 == 0)
            {
                return len1;
            }

            var substitutionCost = 0;
            if (text1[len1 - 1] != text2[len2 - 1])
            {
                substitutionCost = 1;
            }

            var deletion = LevenshteinDistance(text1, len1 - 1, text2, len2) + 1;
            var insertion = LevenshteinDistance(text1, len1, text2, len2 - 1) + 1;
            var substitution = LevenshteinDistance(text1, len1 - 1, text2, len2 - 1) + substitutionCost;

            return Minimum(deletion, insertion, substitution);
        }

             public int DamerauLevenshteinDistance(string firstText, string secondText)
             {
                 var n = firstText.Length + 1;
                 var m = secondText.Length + 1;
                 var arrayD = new int[n, m];

                 for (var i = 0; i < n; i++)
                 {
                     arrayD[i, 0] = i;
                 }

                 for (var j = 0; j < m; j++)
                 {
                     arrayD[0, j] = j;
                 }

                 for (var i = 2; i < n; i++)
                 {
                     for (var j = 2; j < m; j++)
                     {
                         var cost = firstText[i - 1] == secondText[j - 1] ? 0 : 1;

                         arrayD[i, j] = Minimum(arrayD[i - 1, j] + 1,          // удаление
                                                 arrayD[i, j - 1] + 1,         // вставка
                                                arrayD[i - 1, j - 1] + cost); // замена

                         if (i > 1 && j > 1
                             && firstText[i - 1] == secondText[j - 2]
                             && firstText[i - 2] == secondText[j - 1])
                         {
                             arrayD[i, j] = Minimums(arrayD[i, j], arrayD[i - 2, j - 2] + cost); // перестановка

                         }
                     }
                 }

                 return arrayD[n - 1, m - 1];
             }
            
        public int LevenshteinDistances(string word1, string word2) => LevenshteinDistance(word1, word1.Length, word2, word2.Length);

        public void display_menu(string s1, string s2) {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Меню: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1:Расстояние Левенштейна ");
            Console.WriteLine("2:Расстояние Домарау Левенштейна заменой ");
            Console.WriteLine("3:Случайное число ");
            

            Sluchainoe_chislo Chislo = new Sluchainoe_chislo();

            string menu = Console.ReadLine();
            switch (menu)
            {
                case "1":
                        LevenshteinDistances(s1, s2);
                    break;
                case "2":
                    Console.WriteLine("2:Расстояние Домарау Левенштейна заменой " + DamerauLevenshteinDistance(s1, s2));
                    break;
                case "3":
                    Console.WriteLine("3:Случайное число " + Chislo.chislo());
                    break;
                default:
                    display_menu(s1, s2);
                    break;       


            }
        }
        
    }
}
