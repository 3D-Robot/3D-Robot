namespace _3dr_scripting_utility
{
    partial class ForLoop
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
            this.okbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dimensiontext = new System.Windows.Forms.TextBox();
            this.dimensionokbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(507, 482);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(75, 23);
            this.okbutton.TabIndex = 0;
            this.okbutton.Text = "OK";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "dimension of loop";
            // 
            // dimensiontext
            // 
            this.dimensiontext.Location = new System.Drawing.Point(12, 29);
            this.dimensiontext.Name = "dimensiontext";
            this.dimensiontext.Size = new System.Drawing.Size(100, 22);
            this.dimensiontext.TabIndex = 3;
            // 
            // dimensionokbutton
            // 
            this.dimensionokbutton.Location = new System.Drawing.Point(118, 29);
            this.dimensionokbutton.Name = "dimensionokbutton";
            this.dimensionokbutton.Size = new System.Drawing.Size(45, 23);
            this.dimensionokbutton.TabIndex = 5;
            this.dimensionokbutton.Text = "OK";
            this.dimensionokbutton.UseVisualStyleBackColor = true;
            this.dimensionokbutton.Click += new System.EventHandler(this.dimensionokbutton_Click);
            // 
            // ForLoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 517);
            this.Controls.Add(this.dimensionokbutton);
            this.Controls.Add(this.dimensiontext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okbutton);
            this.Name = "ForLoop";
            this.Text = "ForLoop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dimensiontext;
        private System.Windows.Forms.Button dimensionokbutton;
    }
}