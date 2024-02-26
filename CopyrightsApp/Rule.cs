using System.Text.RegularExpressions;

namespace CopyrightsApp
{
    public class Rule
    {
        public string FileExtension { get; set; } = string.Empty;
        public string LineComment { get; set; } = string.Empty;
        public string BlockCommentStart { get; set; } = string.Empty;
        public string BlockCommentEnd { get; set; } = string.Empty;

        public Regex LineCommentRegex = null;

        public Regex BlockCommentRegex = null;

        public void GenerateRegex()
        {
            if (LineComment != string.Empty)
                LineCommentRegex = new Regex(@"[ \t\v]*" + LineComment + @".*", RegexOptions.Compiled);
            if (BlockCommentStart != string.Empty && BlockCommentEnd != string.Empty)
                BlockCommentRegex = new Regex(BlockCommentStart + @".*" + BlockCommentEnd,
                    RegexOptions.Compiled | RegexOptions.Singleline);
        }
    }
}
