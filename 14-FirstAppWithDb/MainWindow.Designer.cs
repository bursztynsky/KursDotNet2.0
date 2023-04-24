namespace _14_FirstAppWithDb
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
            dataView = new DataGridView();
            CarId = new DataGridViewTextBoxColumn();
            CarName = new DataGridViewTextBoxColumn();
            CarModel = new DataGridViewTextBoxColumn();
            CarYear = new DataGridViewTextBoxColumn();
            editButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataView).BeginInit();
            SuspendLayout();
            // 
            // dataView
            // 
            dataView.AllowUserToAddRows = false;
            dataView.AllowUserToDeleteRows = false;
            dataView.AllowUserToResizeRows = false;
            dataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataView.Columns.AddRange(new DataGridViewColumn[] { CarId, CarName, CarModel, CarYear });
            dataView.Location = new Point(130, 139);
            dataView.MultiSelect = false;
            dataView.Name = "dataView";
            dataView.ReadOnly = true;
            dataView.RowTemplate.Height = 25;
            dataView.Size = new Size(553, 254);
            dataView.TabIndex = 1;
            // 
            // CarId
            // 
            CarId.HeaderText = "Id";
            CarId.Name = "CarId";
            CarId.ReadOnly = true;
            // 
            // CarName
            // 
            CarName.HeaderText = "Name";
            CarName.Name = "CarName";
            CarName.ReadOnly = true;
            // 
            // CarModel
            // 
            CarModel.HeaderText = "Model";
            CarModel.Name = "CarModel";
            CarModel.ReadOnly = true;
            // 
            // CarYear
            // 
            CarYear.HeaderText = "Year";
            CarYear.Name = "CarYear";
            CarYear.ReadOnly = true;
            // 
            // edtiButton
            // 
            editButton.Location = new Point(275, 70);
            editButton.Name = "edtiButton";
            editButton.Size = new Size(75, 23);
            editButton.TabIndex = 2;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(editButton);
            Controls.Add(dataView);
            Name = "MainWindow";
            Text = "Moje glowne okienko";
            FormClosed += MainWindow_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataView;
        private DataGridViewTextBoxColumn CarName;
        private DataGridViewTextBoxColumn CarModel;
        private DataGridViewTextBoxColumn CarYear;
        private DataGridViewTextBoxColumn CarId;
        private Button editButton;
    }
}