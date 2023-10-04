using System.Drawing;
using System.Windows.Forms;

namespace PasteToMarkdownTable
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            m_BoxMain = new TextBox();
            SuspendLayout();
            // 
            // m_BoxMain
            // 
            m_BoxMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            m_BoxMain.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            m_BoxMain.Location = new Point(12, 12);
            m_BoxMain.MaxLength = 0;
            m_BoxMain.Multiline = true;
            m_BoxMain.Name = "m_BoxMain";
            m_BoxMain.ScrollBars = ScrollBars.Both;
            m_BoxMain.Size = new Size(776, 426);
            m_BoxMain.TabIndex = 0;
            m_BoxMain.WordWrap = false;
            m_BoxMain.KeyDown += BoxMain_KeyDown;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(m_BoxMain);
            Name = "FormMain";
            Text = "Paste to Markdown Table";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox m_BoxMain;
    }
}