namespace EveAssetViewerHDMaxx
{
    partial class ApiSettingsPanel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbKeyID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbVcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCharID = new System.Windows.Forms.TextBox();
            this.btnSubmitApi = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbKeyID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbVcode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbCharID, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(357, 72);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "KeyID";
            // 
            // tbKeyID
            // 
            this.tbKeyID.Location = new System.Drawing.Point(181, 3);
            this.tbKeyID.Name = "tbKeyID";
            this.tbKeyID.Size = new System.Drawing.Size(173, 20);
            this.tbKeyID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "vCode";
            // 
            // tbVcode
            // 
            this.tbVcode.Location = new System.Drawing.Point(181, 27);
            this.tbVcode.Name = "tbVcode";
            this.tbVcode.Size = new System.Drawing.Size(173, 20);
            this.tbVcode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Character ID";
            // 
            // tbCharID
            // 
            this.tbCharID.Location = new System.Drawing.Point(181, 51);
            this.tbCharID.Name = "tbCharID";
            this.tbCharID.Size = new System.Drawing.Size(173, 20);
            this.tbCharID.TabIndex = 5;
            // 
            // btnSubmitApi
            // 
            this.btnSubmitApi.Location = new System.Drawing.Point(193, 93);
            this.btnSubmitApi.Name = "btnSubmitApi";
            this.btnSubmitApi.Size = new System.Drawing.Size(173, 23);
            this.btnSubmitApi.TabIndex = 1;
            this.btnSubmitApi.Text = "Save API Key";
            this.btnSubmitApi.UseVisualStyleBackColor = true;
            this.btnSubmitApi.Click += new System.EventHandler(this.btnSubmitApi_Click);
            // 
            // ApiSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 128);
            this.Controls.Add(this.btnSubmitApi);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ApiSettingsPanel";
            this.Text = "ApiSettingsPanel";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKeyID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbVcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCharID;
        private System.Windows.Forms.Button btnSubmitApi;
    }
}