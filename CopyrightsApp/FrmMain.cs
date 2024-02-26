using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyrightsApp
{
    public partial class FrmMain : Form
    {
        private static readonly string MessageBoxCaption = "提示";
        private static readonly string FinishedMessage = "处理成功。";
        private static readonly string SourceDirNotSelectedWarning = "源代码目录还未选择，不能开始处理。请先选择源代码目录。";
        private static readonly string RuleNotSelectedWarning = "规则文件还未选择，不能开始处理。请先选择规则文件。";
        private static readonly string OutputNotSelectedWarning = "生成文件还未设置，不能开始处理。请先设置生成文件。";
        private static readonly string NameAndVersionNotEnteredWarning = "软件名称和版本还未输入，不能开始处理。请先输入软件名称和版本。";
        private static readonly string FileInUseError = "有正在运行的程序占用了生成文件，不能开始处理。请关闭相关程序并重试。";
        public FrmMain()
        {
            InitializeComponent();

            string programTitle = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
            string programVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString().Substring(0, 3);
            this.Text = string.Format("{0} V{1}", programTitle, programVersion);

            tbOutput.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            cbRule.SelectedIndex = 0;
        }

        private void BtnStartParsing_Click(object sender, EventArgs e)
        {
            if (ReadyForParsing())
            {
                FileStream fileDocx;
                try
                {
                    string path = Path.Combine(tbOutput.Text, tbName.Text + ".docx");
                    fileDocx = new FileStream(path, FileMode.Create, FileAccess.Write);
                }
                catch (IOException)
                {
                    MessageBox.Show(FileInUseError, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int index = cbRule.SelectedIndex;
                Task task = new Task(() =>
                {
                    RuleImporter.ImportRules(index);
                    Parser.TraverseSourceForParse(textBoxSourceDir.Text);

                    Output.OutputDocx(fileDocx);
                    fileDocx.Close();

                    if (InvokeRequired)
                        Invoke((Action<bool>)Finished, true);
                    else
                        Finished(true);
                });
                task.Start();
            }
            else
                Finished(false);
        }

        private bool ReadyForParsing()
        {
            if (textBoxSourceDir.Text == string.Empty)
            {
                MessageBox.Show(SourceDirNotSelectedWarning, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cbRule.SelectedIndex == -1)
            {
                MessageBox.Show(RuleNotSelectedWarning, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbOutput.Text == string.Empty)
            {
                MessageBox.Show(OutputNotSelectedWarning, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbName.Text == string.Empty)
            {
                MessageBox.Show(NameAndVersionNotEnteredWarning, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            btnOutput.Enabled = false;
            btnSourceDir.Enabled = false;
            buttonStartParsing.Enabled = false;
            tbName.ReadOnly = true;

            ProgressInfo.AppendListBoxProgress = ShowProgress;
            Output.NameAndVersion = tbName.Text;

            listBoxProgress.Items.Clear();

            return true;
        }

        private void BtnSourceDir_Click(object sender, EventArgs e)
        {
            if (fbdDir.ShowDialog() == DialogResult.OK)
                textBoxSourceDir.Text = fbdDir.SelectedPath;
        }

        private void BtnOutput_Click(object sender, EventArgs e)
        {
            if (fbdDir.ShowDialog() == DialogResult.OK)
                tbOutput.Text= fbdDir.SelectedPath;
            //saveFileDialogOutput.ShowDialog();
            //tbOutput.Text = saveFileDialogOutput.FileName;
        }

        private void ShowProgress(string progressInfo)
        {
            if (InvokeRequired)
            {
                Invoke((Action)delegate ()
               {
                   listBoxProgress.Items.Add(progressInfo);
                   listBoxProgress.SelectedIndex = listBoxProgress.Items.Count - 1;
               });
            }
            else
            {
                listBoxProgress.Items.Add(progressInfo);
                listBoxProgress.SelectedIndex = listBoxProgress.Items.Count - 1;
            }
        }

        private void Finished(bool isSuccessful)
        {
            btnSourceDir.Enabled = true;
            btnOutput.Enabled = true;
            buttonStartParsing.Enabled = true;
            tbName.ReadOnly = false;

            if (isSuccessful)
                MessageBox.Show(FinishedMessage, MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
