using System;

namespace CopyrightsApp
{
    public static class ProgressInfo
    {
        public static Action<string> AppendListBoxProgress;
        public enum Stage
        {
            RuleImporting,
            FileParsed,
            DocxOutputStarted,
            DocxOutputFinished,
            Other
        };

        public static void ShowProgress(string info, Stage stage)
        {
            string progressInfo;
            switch (stage)
            {
                case Stage.RuleImporting:
                    progressInfo = string.Format("{0} 文件处理规则已导入", info);
                    break;
                case Stage.FileParsed:
                    progressInfo = string.Format("已处理 {0}", info);
                    break;
                default:
                    progressInfo = info;
                    break;
            }

            AppendListBoxProgress(progressInfo);
        }
    }
}
