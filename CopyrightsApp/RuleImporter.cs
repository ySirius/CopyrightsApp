using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CopyrightsApp
{
    public static class RuleImporter
    {
        private static readonly string FileBlockStart = "File";
        private static readonly string BlockEnd = "End";
        private static readonly string LineCommentLineStart = "LineComment";
        private static readonly string BlockCommentStartLineStart = "BlockCommentStart";
        private static readonly string BlockCommentEndLineStart = "BlockCommentEnd";

        public static void ImportRules(int index)
        {
            List<Rule> rules = RuleDemo.Init();
            Rule rule = rules[index];
            Parser.AddRule(rule);
            ProgressInfo.ShowProgress(rule.FileExtension, ProgressInfo.Stage.RuleImporting);
        }

        public static void ImportRules(string ruleFilePath)
        {
            FileStream ruleFile = new FileStream(ruleFilePath, FileMode.Open, FileAccess.Read);
            StreamReader ruleReader = new StreamReader(ruleFile);
            bool isInFileBlock = false;
            Rule rule = new Rule();
            do
            {
                string currentLine = ruleReader.ReadLine();

                if (currentLine.StartsWith(FileBlockStart))
                {
                    rule = new Rule();
                    isInFileBlock = true;
                    rule.FileExtension = ExtractValue(currentLine);
                }
                else if (isInFileBlock)
                {
                    if (currentLine.StartsWith(LineCommentLineStart))
                    {
                        rule.LineComment = Regex.Escape(ExtractValue(currentLine));
                    }
                    else if (currentLine.StartsWith(BlockCommentStartLineStart))
                    {
                        rule.BlockCommentStart = Regex.Escape(ExtractValue(currentLine));
                    }
                    else if (currentLine.StartsWith(BlockCommentEndLineStart))
                    {
                        rule.BlockCommentEnd = Regex.Escape(ExtractValue(currentLine));
                    }
                    else if (currentLine.StartsWith(BlockEnd))
                    {
                        isInFileBlock = false;
                        rule.GenerateRegex();
                        Parser.AddRule(rule);
                        ProgressInfo.ShowProgress(rule.FileExtension, ProgressInfo.Stage.RuleImporting);
                    }
                }
            } while (!ruleReader.EndOfStream);
        }

        private static string ExtractValue(string line)
        {
            int index = -1, length = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '\"')
                {
                    if (index == -1)
                        index = i + 1;
                    else
                    {
                        length = i - index;
                        break;
                    }
                }
            }
            return line.Substring(index, length);
        }
    }
}
