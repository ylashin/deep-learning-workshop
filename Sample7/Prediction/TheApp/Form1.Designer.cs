namespace TheApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtData = new System.Windows.Forms.TextBox();
            this.btnOptionA = new System.Windows.Forms.Button();
            this.btnOptionB = new System.Windows.Forms.Button();
            this.btnOptionC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(44, 64);
            this.txtData.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(971, 254);
            this.txtData.TabIndex = 0;
            this.txtData.Text = resources.GetString("txtData.Text");
            this.txtData.TextChanged += new System.EventHandler(this.txtData_TextChanged);
            // 
            // btnOptionA
            // 
            this.btnOptionA.Location = new System.Drawing.Point(44, 386);
            this.btnOptionA.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnOptionA.Name = "btnOptionA";
            this.btnOptionA.Size = new System.Drawing.Size(289, 107);
            this.btnOptionA.TabIndex = 1;
            this.btnOptionA.UseVisualStyleBackColor = true;
            this.btnOptionA.Click += new System.EventHandler(this.btnOptionA_Click);
            // 
            // btnOptionB
            // 
            this.btnOptionB.Location = new System.Drawing.Point(367, 386);
            this.btnOptionB.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnOptionB.Name = "btnOptionB";
            this.btnOptionB.Size = new System.Drawing.Size(302, 107);
            this.btnOptionB.TabIndex = 2;
            this.btnOptionB.UseVisualStyleBackColor = true;
            this.btnOptionB.Click += new System.EventHandler(this.btnOptionB_Click);
            // 
            // btnOptionC
            // 
            this.btnOptionC.Location = new System.Drawing.Point(701, 386);
            this.btnOptionC.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnOptionC.Name = "btnOptionC";
            this.btnOptionC.Size = new System.Drawing.Size(314, 107);
            this.btnOptionC.TabIndex = 3;
            this.btnOptionC.UseVisualStyleBackColor = true;
            this.btnOptionC.Click += new System.EventHandler(this.btnOptionC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input Text:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Next word prediction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 513);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Option A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 513);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Option B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(799, 513);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Option C";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 572);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOptionC);
            this.Controls.Add(this.btnOptionB);
            this.Controls.Add(this.btnOptionA);
            this.Controls.Add(this.txtData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Button btnOptionA;
        private System.Windows.Forms.Button btnOptionB;
        private System.Windows.Forms.Button btnOptionC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

