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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblKiwiPropability = new System.Windows.Forms.Label();
            this.lblAussiePropability = new System.Windows.Forms.Label();
            this.txtAttribute2 = new System.Windows.Forms.TextBox();
            this.txtAttribute1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetectIdentity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TheApp.Properties.Resources.aussie_vs__kiwi_by_kirasaintclair_d5xpudb;
            this.pictureBox1.Location = new System.Drawing.Point(55, 264);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1051, 572);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // lblKiwiPropability
            // 
            this.lblKiwiPropability.AutoSize = true;
            this.lblKiwiPropability.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKiwiPropability.Location = new System.Drawing.Point(133, 194);
            this.lblKiwiPropability.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblKiwiPropability.Name = "lblKiwiPropability";
            this.lblKiwiPropability.Size = new System.Drawing.Size(106, 51);
            this.lblKiwiPropability.TabIndex = 22;
            this.lblKiwiPropability.Text = "Kiwi";
            // 
            // lblAussiePropability
            // 
            this.lblAussiePropability.AutoSize = true;
            this.lblAussiePropability.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAussiePropability.Location = new System.Drawing.Point(830, 194);
            this.lblAussiePropability.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAussiePropability.Name = "lblAussiePropability";
            this.lblAussiePropability.Size = new System.Drawing.Size(159, 51);
            this.lblAussiePropability.TabIndex = 21;
            this.lblAussiePropability.Text = "Aussie";
            // 
            // txtAttribute2
            // 
            this.txtAttribute2.Location = new System.Drawing.Point(250, 84);
            this.txtAttribute2.Margin = new System.Windows.Forms.Padding(5);
            this.txtAttribute2.Name = "txtAttribute2";
            this.txtAttribute2.Size = new System.Drawing.Size(313, 31);
            this.txtAttribute2.TabIndex = 20;
            // 
            // txtAttribute1
            // 
            this.txtAttribute1.Location = new System.Drawing.Point(250, 9);
            this.txtAttribute1.Margin = new System.Windows.Forms.Padding(5);
            this.txtAttribute1.Name = "txtAttribute1";
            this.txtAttribute1.Size = new System.Drawing.Size(313, 31);
            this.txtAttribute1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Attribute2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Attribute1";
            // 
            // btnDetectIdentity
            // 
            this.btnDetectIdentity.Location = new System.Drawing.Point(642, 51);
            this.btnDetectIdentity.Margin = new System.Windows.Forms.Padding(5);
            this.btnDetectIdentity.Name = "btnDetectIdentity";
            this.btnDetectIdentity.Size = new System.Drawing.Size(377, 70);
            this.btnDetectIdentity.TabIndex = 16;
            this.btnDetectIdentity.Text = "Detect my identity";
            this.btnDetectIdentity.UseVisualStyleBackColor = true;
            this.btnDetectIdentity.Click += new System.EventHandler(this.btnDetectIdentity_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 866);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblKiwiPropability);
            this.Controls.Add(this.lblAussiePropability);
            this.Controls.Add(this.txtAttribute2);
            this.Controls.Add(this.txtAttribute1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDetectIdentity);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblKiwiPropability;
        private System.Windows.Forms.Label lblAussiePropability;
        private System.Windows.Forms.TextBox txtAttribute2;
        private System.Windows.Forms.TextBox txtAttribute1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetectIdentity;
    }
}

