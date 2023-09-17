using System.Text;

namespace PasteToMarkdownTable
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void BoxMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && ModifierKeys == Keys.Control)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                var clipboardText = Clipboard.GetText();
                if (string.IsNullOrEmpty(clipboardText))
                {
                    m_BoxMain.Text = string.Empty;
                    return;
                }

                var result = TabSeparatedToMarkdownTable(clipboardText);
                m_BoxMain.Text = result;
                m_BoxMain.SelectAll();
            }
        }

        private static string TabSeparatedToMarkdownTable(string input)
        {
            var lines = input.Split(Environment.NewLine);
            int lineCount = lines.Length + (lines[^1].Length == 0 ? -1 : 0);
            if (lineCount <= 0)
            {
                return string.Empty;
            }

            var splitLines = lines.Take(lineCount).Select(x => x.Split('\t')).ToArray();
            var columnCount = splitLines.Max(x => x.Length);
            var columnWidths = new int[columnCount];
            for (int col = 0; col < columnCount; col++)
            {
                var width = 0;
                foreach (var line in splitLines)
                {
                    if (line.Length > col)
                    {
                        width = Math.Max(width, line[col].Length);
                    }
                }
                columnWidths[col] = width;
            }

            var result = new StringBuilder();
            WriteMarkdownLine(result, columnWidths, splitLines[0]);
            WriteMarkdownHeaderBorder(result, columnWidths);
            foreach (var line in splitLines.Skip(1))
            {
                WriteMarkdownLine(result, columnWidths, line);
            }

            return result.ToString();
        }

        private static void WriteMarkdownLine(StringBuilder result, int[] columnWidths, string[] line)
        {
            result.Append('|');

            for (int column = 0; column < columnWidths.Length; column++)
            {
                result.Append(' ');

                string value = column < line.Length ? line[column] : string.Empty;

                result.Append(value);
                result.Append(new string(' ', columnWidths[column] - value.Length));

                result.Append(' ');
                result.Append('|');
            }

            result.AppendLine();
        }

        private static void WriteMarkdownHeaderBorder(StringBuilder result, int[] columnWidths)
        {
            result.Append('|');

            for (int column = 0; column < columnWidths.Length; column++)
            {
                result.Append(new string('-', columnWidths[column] + 2));
                result.Append('|');
            }

            result.AppendLine();
        }
    }
}