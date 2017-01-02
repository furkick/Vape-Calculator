namespace VapeCalculator.Forms
{
    partial class NewFlavourForm
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
            this.lblFlavourName = new System.Windows.Forms.Label();
            this.lblFlavourWeight = new System.Windows.Forms.Label();
            this.txtFlavourName = new System.Windows.Forms.TextBox();
            this.txtFlavourWeight = new System.Windows.Forms.TextBox();
            this.btnAddFlavour = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFlavourName
            // 
            this.lblFlavourName.AutoSize = true;
            this.lblFlavourName.Location = new System.Drawing.Point(13, 13);
            this.lblFlavourName.Name = "lblFlavourName";
            this.lblFlavourName.Size = new System.Drawing.Size(73, 13);
            this.lblFlavourName.TabIndex = 0;
            this.lblFlavourName.Text = "Flavour Name";
            // 
            // lblFlavourWeight
            // 
            this.lblFlavourWeight.AutoSize = true;
            this.lblFlavourWeight.Location = new System.Drawing.Point(127, 13);
            this.lblFlavourWeight.Name = "lblFlavourWeight";
            this.lblFlavourWeight.Size = new System.Drawing.Size(41, 13);
            this.lblFlavourWeight.TabIndex = 1;
            this.lblFlavourWeight.Text = "Weight";
            // 
            // txtFlavourName
            // 
            this.txtFlavourName.Location = new System.Drawing.Point(13, 30);
            this.txtFlavourName.Name = "txtFlavourName";
            this.txtFlavourName.Size = new System.Drawing.Size(100, 20);
            this.txtFlavourName.TabIndex = 2;
            // 
            // txtFlavourWeight
            // 
            this.txtFlavourWeight.Location = new System.Drawing.Point(130, 30);
            this.txtFlavourWeight.Name = "txtFlavourWeight";
            this.txtFlavourWeight.Size = new System.Drawing.Size(100, 20);
            this.txtFlavourWeight.TabIndex = 3;
            // 
            // btnAddFlavour
            // 
            this.btnAddFlavour.Location = new System.Drawing.Point(84, 57);
            this.btnAddFlavour.Name = "btnAddFlavour";
            this.btnAddFlavour.Size = new System.Drawing.Size(75, 23);
            this.btnAddFlavour.TabIndex = 4;
            this.btnAddFlavour.Text = "Add";
            this.btnAddFlavour.UseVisualStyleBackColor = true;
            this.btnAddFlavour.Click += new System.EventHandler(this.btnAddFlavour_Click);
            // 
            // NewFlavourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 92);
            this.Controls.Add(this.btnAddFlavour);
            this.Controls.Add(this.txtFlavourWeight);
            this.Controls.Add(this.txtFlavourName);
            this.Controls.Add(this.lblFlavourWeight);
            this.Controls.Add(this.lblFlavourName);
            this.Name = "NewFlavourForm";
            this.Text = "New Flavour";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFlavourName;
        private System.Windows.Forms.Label lblFlavourWeight;
        private System.Windows.Forms.TextBox txtFlavourName;
        private System.Windows.Forms.TextBox txtFlavourWeight;
        private System.Windows.Forms.Button btnAddFlavour;
    }
}