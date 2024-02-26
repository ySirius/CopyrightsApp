using System.IO;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace CopyrightsApp
{
    public static class Output
    {
        private static readonly double StandardFontSize = 10.0;
        private static readonly double FirstPageFontSize = 72.0;
        public static string NameAndVersion { get; set; } = string.Empty;

        public static void OutputDocx(FileStream docxFile)
        {
            ProgressInfo.ShowProgress("开始将处理结果输出至生成文件。", ProgressInfo.Stage.DocxOutputStarted);

            using (DocX outputDocx = DocX.Create(docxFile))
            {
                //outputDocx.AddHeaders();   //添加页眉
                outputDocx.DifferentFirstPage = true;

                //outputDocx.Sections[0].PageNumberStart = 0;
                //outputDocx.Headers.Odd.InsertParagraph(NameAndVersion + "源代码");
                //outputDocx.Headers.Odd.PageNumbers = true;
                //outputDocx.Headers.Odd.PageNumberParagraph.Alignment = Alignment.right;
                
                //Paragraph firstPage = outputDocx.InsertParagraph("\n" + NameAndVersion + "源代码");
                //firstPage.FontSize(FirstPageFontSize);
                //firstPage.Alignment = Alignment.center;
                //firstPage.InsertPageBreakAfterSelf();

                StringReader codeLines = new StringReader(Parser.ParsedLines.ToString());
                int index = 0;
                do
                {
                    Paragraph codeLine = outputDocx.InsertParagraph(codeLines.ReadLine());
                    codeLine.FontSize(StandardFontSize);
                    index++;
                } while (codeLines.Peek() != -1 && index <= 3060);

                outputDocx.Save();
            }

            ProgressInfo.ShowProgress("已将处理结果输出至生成文件。", ProgressInfo.Stage.DocxOutputFinished);
        }
    }
}
