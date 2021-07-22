using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WF
{
    public class WordFinder
    {
        private IEnumerable<string> _matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            Console.WriteLine(matrix.ToString());
            _matrix = matrix;

        }

        /* It should return the top 10 most repeated words from the word stream found in the
        matrix. If no words are found, the "Find" method should return an empty set of strings. ​If any
        word in the word stream is found more than once within the stream, the search results
        should count it only once */
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            // I check how many words Im searching. Just to be sure...
            Console.WriteLine(string.Concat("There are: ", wordstream.Count(), " words in the list"));


            List<string> fWords = new List<string>();
            List<string> verticalWords = new List<string>();
            List<string> resultList = new List<string>();

            //I rearrange every char in the vertical dimension to be able to pass it to a string.
            for (int col = 0; col < _matrix.Count(); col++)
            {
                string sVertical = "";
                foreach (string item in _matrix)
                {
                    sVertical = string.Concat(sVertical, item.Substring(col, 1));
                }

                //Console.WriteLine(sVertical.ToString());
                verticalWords.Add(sVertical);
            }

            foreach (string word in wordstream)
            {
                //I search for each word in every item of the list
                foreach (string row in _matrix)
                {
                    if (row.Contains(word.ToUpper()))
                    {
                        fWords.Add(new string(word.ToUpper()));
                        //Since I only want 1 match I skip to next word
                        break;
                    }
                }
            }

            //Horizontal words are easier because I dont need to rearrange anything
            foreach (string word in wordstream)
            {
                //I search for each word in every item of the list
                foreach (string row in _matrix)
                {
                    if (row.Contains(word.ToUpper()))
                    {
                        fWords.Add(new string(word.ToUpper()));
                        //Since I only want 1 match I skip to next word
                        break;
                    }
                }
            }

            if (fWords.Count > 0)
            {
                //I use this LinQ query to group the items by word and then take the top 10 results
                var wCount = fWords.GroupBy(x => x)
                            .Select(g => new { Value = g.Key, Count = g.Count() }).Take(10)
                            .OrderByDescending(x => x.Count);

                foreach (var word in wCount)
                {
                    resultList.Add(new string("Word: " + word.Value + " Count: " + word.Count));
                }
            }


            return resultList;
        }

    }

}