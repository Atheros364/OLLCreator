namespace OLLcreator
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
            this.label_Instructions = new System.Windows.Forms.Label();
            this.label_Source = new System.Windows.Forms.Label();
            this.textBox_Source = new System.Windows.Forms.TextBox();
            this.button_Source = new System.Windows.Forms.Button();
            this.button_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Instructions
            // 
            this.label_Instructions.AutoSize = true;
            this.label_Instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Instructions.Location = new System.Drawing.Point(12, 9);
            this.label_Instructions.MaximumSize = new System.Drawing.Size(300, 100);
            this.label_Instructions.Name = "label_Instructions";
            this.label_Instructions.Size = new System.Drawing.Size(298, 100);
            this.label_Instructions.TabIndex = 0;
            this.label_Instructions.Text = "This tool will create on .oll load file from documents in a folder that uses the " +
    "page name from the pdf as the Page ID in TrialDirector. The .oll will be placed " +
    "next to the folder of documents.";
            // 
            // label_Source
            // 
            this.label_Source.AutoSize = true;
            this.label_Source.Location = new System.Drawing.Point(13, 143);
            this.label_Source.Name = "label_Source";
            this.label_Source.Size = new System.Drawing.Size(218, 13);
            this.label_Source.TabIndex = 1;
            this.label_Source.Text = "Choose the folder containing the documents.";
            // 
            // textBox_Source
            // 
            this.textBox_Source.Location = new System.Drawing.Point(16, 178);
            this.textBox_Source.Name = "textBox_Source";
            this.textBox_Source.Size = new System.Drawing.Size(215, 20);
            this.textBox_Source.TabIndex = 3;
            // 
            // button_Source
            // 
            this.button_Source.Location = new System.Drawing.Point(237, 176);
            this.button_Source.Name = "button_Source";
            this.button_Source.Size = new System.Drawing.Size(75, 23);
            this.button_Source.TabIndex = 4;
            this.button_Source.Text = "Browse";
            this.button_Source.UseVisualStyleBackColor = true;
            this.button_Source.Click += new System.EventHandler(this.button_Source_Click);
            // 
            // button_Create
            // 
            this.button_Create.Location = new System.Drawing.Point(123, 231);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(75, 23);
            this.button_Create.TabIndex = 7;
            this.button_Create.Text = "Create .OLL";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 286);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.button_Source);
            this.Controls.Add(this.textBox_Source);
            this.Controls.Add(this.label_Source);
            this.Controls.Add(this.label_Instructions);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Instructions;
        private System.Windows.Forms.Label label_Source;
        private System.Windows.Forms.TextBox textBox_Source;
        private System.Windows.Forms.Button button_Source;
        private System.Windows.Forms.Button button_Create;
        private string sourceFolderText = "";
    }
}

