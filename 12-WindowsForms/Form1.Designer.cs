namespace _12_WindowsForms
{
    partial class Form1
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
            this.clickMeButton = new System.Windows.Forms.Button();
            this.clickMeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clickMeButton
            // 
            this.clickMeButton.Location = new System.Drawing.Point(328, 205);
            this.clickMeButton.Name = "clickMeButton";
            this.clickMeButton.Size = new System.Drawing.Size(117, 38);
            this.clickMeButton.TabIndex = 0;
            this.clickMeButton.Text = "Click me!";
            this.clickMeButton.UseVisualStyleBackColor = true;
            this.clickMeButton.Click += new System.EventHandler(this.clickMeButton_Click);
            // 
            // clickMeLabel
            // 
            this.clickMeLabel.AutoSize = true;
            this.clickMeLabel.Location = new System.Drawing.Point(287, 133);
            this.clickMeLabel.MinimumSize = new System.Drawing.Size(200, 20);
            this.clickMeLabel.Name = "clickMeLabel";
            this.clickMeLabel.Size = new System.Drawing.Size(200, 20);
            this.clickMeLabel.TabIndex = 1;
            this.clickMeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clickMeLabel);
            this.Controls.Add(this.clickMeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button clickMeButton;
        private Label clickMeLabel;
    }
}