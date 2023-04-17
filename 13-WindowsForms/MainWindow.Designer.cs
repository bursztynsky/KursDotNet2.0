namespace _13_WindowsForms
{
    partial class MainWindow
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
            selectFileButton = new Button();
            dataView = new DataGridView();
            CarName = new DataGridViewTextBoxColumn();
            CarModel = new DataGridViewTextBoxColumn();
            CarYear = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataView).BeginInit();
            SuspendLayout();
            // 
            // selectFileButton
            // 
            selectFileButton.Location = new Point(350, 45);
            selectFileButton.Name = "selectFileButton";
            selectFileButton.Size = new Size(100, 50);
            selectFileButton.TabIndex = 0;
            selectFileButton.Text = "Select file to load data";
            selectFileButton.UseVisualStyleBackColor = true;
            selectFileButton.Click += selectFileButton_Click;
            // 
            // dataView
            // 
            dataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView.Columns.AddRange(new DataGridViewColumn[] { CarName, CarModel, CarYear });
            dataView.Location = new Point(130, 139);
            dataView.Name = "dataView";
            dataView.RowTemplate.Height = 25;
            dataView.Size = new Size(553, 254);
            dataView.TabIndex = 1;
            // 
            // CarName
            // 
            CarName.HeaderText = "CarName";
            CarName.Name = "CarName";
            // 
            // CarModel
            // 
            CarModel.HeaderText = "CarModel";
            CarModel.Name = "CarModel";
            // 
            // CarYear
            // 
            CarYear.HeaderText = "CarYear";
            CarYear.Name = "CarYear";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataView);
            Controls.Add(selectFileButton);
            Name = "MainWindow";
            Text = "Moje glowne okienko";
            FormClosed += MainWindow_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button selectFileButton;
        private DataGridView dataView;
        private DataGridViewTextBoxColumn CarName;
        private DataGridViewTextBoxColumn CarModel;
        private DataGridViewTextBoxColumn CarYear;
    }
}