using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CopyrightsApp
{
    public class RuleDemo
    {
        public static List<Rule> Init()
        {
            List<Rule> Rules = new List<Rule>();
            Rule net = new Rule()
            {
                FileExtension = "File \".cs\"",
                LineComment = "LineComment  \"//\"",
                BlockCommentStart = "BlockCommentStart \"/*\"",
                BlockCommentEnd = "BlockCommentEnd \"*/\"",
            };
            Rules.Add(net);

            Rule go = new Rule()
            {
                FileExtension = "File \".go\"",
                LineComment = "LineComment  \"//\"",
                BlockCommentStart = "BlockCommentStart \"/*\"",
                BlockCommentEnd = "BlockCommentEnd \"*/\"",
            };
            Rules.Add(go);

            Rule vue = new Rule()
            {
                FileExtension = "File \".html.css.vue.scss.ts.tsx\"",
                LineComment = "LineComment  \"//\"",
                BlockCommentStart = "BlockCommentStart \"/*\"",
                BlockCommentEnd = "BlockCommentEnd \"*/\"",
            };
            Rules.Add(vue);

            Rule py = new Rule()
            {
                FileExtension = "File \".py.json\"",
                LineComment = "LineComment  \"#\"",
                BlockCommentStart = "BlockCommentStart \"/*\"",
                BlockCommentEnd = "BlockCommentEnd \"*/\"",
            };
            Rules.Add(py);

            Rule weapp = new Rule()
            {
                FileExtension = "File \".js.wxss.wxml.json\"",
                LineComment = "LineComment  \"#\"",
                BlockCommentStart = "BlockCommentStart \"/*\"",
                BlockCommentEnd = "BlockCommentEnd \"*/\"",
            };
            Rules.Add(weapp);


            foreach (var rule in Rules)
            {
                rule.FileExtension = ExtractValue(rule.FileExtension);
                rule.LineComment = Regex.Escape(ExtractValue(rule.LineComment));
                rule.BlockCommentStart = Regex.Escape(ExtractValue(rule.BlockCommentStart));
                rule.BlockCommentEnd = Regex.Escape(ExtractValue(rule.BlockCommentEnd));
                rule.GenerateRegex();
            }

            return Rules;
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
