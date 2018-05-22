namespace FifaDBtest
{
    partial class Form1
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
            this.txtPrediction2 = new System.Windows.Forms.TextBox();
            this.txtPrediction1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtATeam = new System.Windows.Forms.TextBox();
            this.txtHTeam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_HomeTeam = new System.Windows.Forms.Label();
            this.lbl_match = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAddPred = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPrediction2
            // 
            this.txtPrediction2.Location = new System.Drawing.Point(110, 125);
            this.txtPrediction2.Name = "txtPrediction2";
            this.txtPrediction2.Size = new System.Drawing.Size(45, 20);
            this.txtPrediction2.TabIndex = 27;
            // 
            // txtPrediction1
            // 
            this.txtPrediction1.Location = new System.Drawing.Point(12, 125);
            this.txtPrediction1.Name = "txtPrediction1";
            this.txtPrediction1.Size = new System.Drawing.Size(45, 20);
            this.txtPrediction1.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "prediction";
            // 
            // txtATeam
            // 
            this.txtATeam.Location = new System.Drawing.Point(110, 83);
            this.txtATeam.Name = "txtATeam";
            this.txtATeam.ReadOnly = true;
            this.txtATeam.Size = new System.Drawing.Size(88, 20);
            this.txtATeam.TabIndex = 24;
            // 
            // txtHTeam
            // 
            this.txtHTeam.Location = new System.Drawing.Point(12, 83);
            this.txtHTeam.Name = "txtHTeam";
            this.txtHTeam.ReadOnly = true;
            this.txtHTeam.Size = new System.Drawing.Size(92, 20);
            this.txtHTeam.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Away Team";
            // 
            // lbl_HomeTeam
            // 
            this.lbl_HomeTeam.AutoSize = true;
            this.lbl_HomeTeam.Location = new System.Drawing.Point(9, 67);
            this.lbl_HomeTeam.Name = "lbl_HomeTeam";
            this.lbl_HomeTeam.Size = new System.Drawing.Size(65, 13);
            this.lbl_HomeTeam.TabIndex = 21;
            this.lbl_HomeTeam.Text = "Home Team";
            // 
            // lbl_match
            // 
            this.lbl_match.AutoSize = true;
            this.lbl_match.Location = new System.Drawing.Point(9, 10);
            this.lbl_match.Name = "lbl_match";
            this.lbl_match.Size = new System.Drawing.Size(48, 13);
            this.lbl_match.TabIndex = 20;
            this.lbl_match.Text = "Matches";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(186, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnAddPred
            // 
            this.btnAddPred.Location = new System.Drawing.Point(233, 115);
            this.btnAddPred.Name = "btnAddPred";
            this.btnAddPred.Size = new System.Drawing.Size(93, 38);
            this.btnAddPred.TabIndex = 28;
            this.btnAddPred.Text = "add prediction";
            this.btnAddPred.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 164);
            this.Controls.Add(this.btnAddPred);
            this.Controls.Add(this.txtPrediction2);
            this.Controls.Add(this.txtPrediction1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtATeam);
            this.Controls.Add(this.txtHTeam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_HomeTeam);
            this.Controls.Add(this.lbl_match);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrediction2;
        private System.Windows.Forms.TextBox txtPrediction1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtATeam;
        private System.Windows.Forms.TextBox txtHTeam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_HomeTeam;
        private System.Windows.Forms.Label lbl_match;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAddPred;
    }
}

