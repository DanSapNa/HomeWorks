using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = $"{Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))}\\Text.txt";
            string text = File.ReadAllText(path);
            string citationPattern = @"\[\d\]";
            string target = "";
            string yearsPattern = @"[0-9]{4}s";
            string regularPattern = @"regular";
            string lastParagraphPattern = @"\n*.+$";

            Regex regex = new Regex(citationPattern);
            Console.WriteLine(regex.Replace(text, target));

            regex = new Regex(yearsPattern);
            foreach (Match match in regex.Matches(text))
            {
                Console.WriteLine($"\t{match.Value}");
            }

            regex = new Regex(regularPattern, RegexOptions.IgnoreCase);
            Console.WriteLine($"'regular' - {regex.Matches(text).Count} count");

            regex = new Regex(lastParagraphPattern, RegexOptions.Multiline|RegexOptions.IgnoreCase);
            Match res = Regex.Match(text, lastParagraphPattern, RegexOptions.Multiline | RegexOptions.RightToLeft | RegexOptions.IgnoreCase);
            Console.WriteLine(res.Value);

            Console.ReadKey();
        }
    }
}
