using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CopyrightsApp
{
    public static class Parser
    {
        private static List<Rule> Rules = new List<Rule>();
        public static StringBuilder ParsedLines { get; set; } = new StringBuilder();
        private static readonly object _ParsedLinesSync = new object();

        public static void TraverseSourceForParse(string sourceDirectory)
        {
            ParsedLines = new StringBuilder();
            Parallel.ForEach(Directory.GetFiles(sourceDirectory, "*.*", SearchOption.AllDirectories), filePath => ParseFile(filePath, FindRule(filePath)));
        }

        public static void AddRule(Rule rule)
        {
            Rules.Add(rule);
        }
        private static void ParseFile(string filePath, Rule rule)
        {
            if (rule is null)
                return;

            StreamReader reader = new StreamReader(filePath);
            string fileContent = reader.ReadToEnd().Normalize();

            if (!(rule.LineCommentRegex is null))
                fileContent = rule.LineCommentRegex.Replace(fileContent, string.Empty);
            if (!(rule.BlockCommentRegex is null))
                fileContent = rule.BlockCommentRegex.Replace(fileContent, string.Empty);

            lock (_ParsedLinesSync)
            {
                ParsedLines.Append(fileContent.RemoveEmptyLines());
                ProgressInfo.ShowProgress(filePath, ProgressInfo.Stage.FileParsed);
            }

            reader.Close();
        }

        private static string RemoveEmptyLines(this string content)
        {
            StringBuilder removed = new StringBuilder();

            foreach (string line in content.Split('\n', '\r'))
                if (line.Trim() != string.Empty)
                    removed.AppendLine(line);

            return removed.ToString();
        }

        private static Rule FindRule(string path)
        {
            foreach (Rule rule in Rules)
            {
                string ext = Path.GetExtension(path).Replace(".", "");
                //if (path.EndsWith(rule.FileExtension))
                //    return rule;
                if (rule.FileExtension.Contains(ext))
                    return rule;
            }
            return null;
        }
    }
}
