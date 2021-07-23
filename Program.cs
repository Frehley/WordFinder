using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
namespace WF
{
    class Program
    {
        const int MATRIX_ROWS = 64;
        const int MATRIX_COLUMNS = 64;
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static void Main(string[] args)
        {
            IEnumerable<string> matrix = GenerateMatrix(MATRIX_ROWS, MATRIX_COLUMNS);

            //In case I need to visualize de matrix in the console
            PrintMatrix(matrix);

            var wordfinder = new WordFinder(matrix);
            var words = new Word();

            List<string> result = wordfinder.Find(words.stream).ToList();
            result.ForEach(Console.WriteLine);
        }


        private static IEnumerable<string> GenerateMatrix(int rows, int cols)
        {
            var random = new Random();

            StringBuilder sRow = new StringBuilder("", MATRIX_ROWS);

            //I create a list of string wich later will be returned as IEnumerable
            List<string> arrayList = new List<string>();

            for (int i = 0; i < rows; i++)
            {
                sRow.Clear();
                //I will have a char in each column
                for (int col = 0; col < cols; col++)
                {
                    sRow.Append(new string(Enumerable.Repeat(chars, 1).Select(s => s[random.Next(s.Length)]).ToArray()));
                }
                //I trim it just in case I left any spaces
                arrayList.Add(sRow.ToString().Trim());
            }

            return arrayList;
        }

        private static void PrintMatrix(IEnumerable<string> matrix)
        {
            foreach (string row in matrix)
            {
                Console.WriteLine(row);
            }
        }


    }
}
