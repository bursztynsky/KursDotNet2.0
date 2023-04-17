namespace _13_WindowsForms
{
    partial class FilePathWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            selectFileButton = new Button();
            saveButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(181, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(432, 23);
            textBox1.TabIndex = 0;
            // 
            // selectFileButton
            // 
            selectFileButton.Location = new Point(181, 26);
            selectFileButton.Name = "selectFileButton";
            selectFileButton.Size = new Size(432, 70);
            selectFileButton.TabIndex = 1;
            selectFileButton.Text = "Select file";
            selectFileButton.UseVisualStyleBackColor = true;
            selectFileButton.Click += buttonFileButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(181, 149);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(432, 38);
            saveButton.TabIndex = 2;
            saveButton.Text = "SAVE";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // FilePathWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 199);
            Controls.Add(saveButton);
            Controls.Add(selectFileButton);
            Controls.Add(textBox1);
            Name = "FilePathWindow";
            Text = "Select file";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button selectFileButton;
        private Button saveButton;
    }
}