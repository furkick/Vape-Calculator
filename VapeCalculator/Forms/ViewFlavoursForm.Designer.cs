namespace VapeCalculator.Forms
{
    partial class ViewFlavoursForm
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
            this.lstFlavours = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNewFlavour = new System.Windows.Forms.Button();
            this.txtFlavourName = new System.Windows.Forms.TextBox();
            this.lblFlavourName = new System.Windows.Forms.Label();
            this.lblFlavourWeight = new System.Windows.Forms.Label();
            this.txtFlavourWeight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstFlavours
            // 
            this.lstFlavours.FormattingEnabled = true;
            this.lstFlavours.Location = new System.Drawing.Point(12, 40);
            this.lstFlavours.Name = "lstFlavours";
            this.lstFlavours.Size = new System.Drawing.Size(138, 329);
            this.lstFlavours.TabIndex = 0;
            this.lstFlavours.SelectedIndexChanged += new System.EventHandler(this.lstFlavours_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 376);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseCompatibleTextRendering = true;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(96, 376);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(54, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseCompatibleTextRendering = true;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNewFlavour
            // 
            this.btnNewFlavour.Location = new System.Drawing.Point(12, 11);
            this.btnNewFlavour.Name = "btnNewFlavour";
            this.btnNewFlavour.Size = new System.Drawing.Size(75, 23);
            this.btnNewFlavour.TabIndex = 3;
            this.btnNewFlavour.Text = "New Flavour";
            this.btnNewFlavour.UseVisualStyleBackColor = true;
            this.btnNewFlavour.Click += new System.EventHandler(this.btnNewFlavour_Click);
            // 
            // txtFlavourName
            // 
            this.txtFlavourName.Location = new System.Drawing.Point(176, 58);
            this.txtFlavourName.Name = "txtFlavourName";
            this.txtFlavourName.Size = new System.Drawing.Size(100, 20);
            this.txtFlavourName.TabIndex = 4;
            // 
            // lblFlavourName
            // 
            this.lblFlavourName.AutoSize = true;
            this.lblFlavourName.Location = new System.Drawing.Point(176, 39);
            this.lblFlavourName.Name = "lblFlavourName";
            this.lblFlavourName.Size = new System.Drawing.Size(73, 13);
            this.lblFlavourName.TabIndex = 5;
            this.lblFlavourName.Text = "Flavour Name";
            // 
            // lblFlavourWeight
            // 
            this.lblFlavourWeight.AutoSize = true;
            this.lblFlavourWeight.Location = new System.Drawing.Point(176, 94);
            this.lblFlavourWeight.Name = "lblFlavourWeight";
            this.lblFlavourWeight.Size = new System.Drawing.Size(79, 13);
            this.lblFlavourWeight.TabIndex = 7;
            this.lblFlavourWeight.Text = "Flavour Weight";
            // 
            // txtFlavourWeight
            // 
            this.txtFlavourWeight.Location = new System.Drawing.Point(176, 113);
            this.txtFlavourWeight.Name = "txtFlavourWeight";
            this.txtFlavourWeight.Size = new System.Drawing.Size(100, 20);
            this.txtFlavourWeight.TabIndex = 6;
            // 
            // ViewFlavoursForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 405);
            this.Controls.Add(this.lblFlavourWeight);
            this.Controls.Add(this.txtFlavourWeight);
            this.Controls.Add(this.lblFlavourName);
            this.Controls.Add(this.txtFlavourName);
            this.Controls.Add(this.btnNewFlavour);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstFlavours);
            this.Name = "ViewFlavoursForm";
            this.Text = "ViewFlavoursForm";
            this.Load += new System.EventHandler(this.ViewFlavoursForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFlavours;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNewFlavour;
        private System.Windows.Forms.TextBox txtFlavourName;
        private System.Windows.Forms.Label lblFlavourName;
        private System.Windows.Forms.Label lblFlavourWeight;
        private System.Windows.Forms.TextBox txtFlavourWeight;
    }
}