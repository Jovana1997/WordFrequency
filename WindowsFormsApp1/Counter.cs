using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    class Counter
    {
        public static void WordFrequencyCounter(string fileName, Dictionary<string, int> words)
        {
            
            var content = File.ReadAllText(fileName);

            var wordPattern = new Regex(@"\b[^\d\W(?!_)]+-?[^\d\W(?!_)]+\b");

            foreach (Match match in wordPattern.Matches(content))
            {
                int currentCount = 0;
                words.TryGetValue(match.Value, out currentCount);

                currentCount++;
                words[match.Value] = currentCount;
            }
            
            
        }
    }
}
