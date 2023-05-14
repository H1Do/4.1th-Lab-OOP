namespace OOP_Lab_4_1
{
    partial class Form1
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.isCtrlCheckBox = new System.Windows.Forms.CheckBox();
            this.isCrossSelectCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(713, 479);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // isCtrlCheckBox
            // 
            this.isCtrlCheckBox.AutoSize = true;
            this.isCtrlCheckBox.Location = new System.Drawing.Point(12, 487);
            this.isCtrlCheckBox.Name = "isCtrlCheckBox";
            this.isCtrlCheckBox.Size = new System.Drawing.Size(53, 19);
            this.isCtrlCheckBox.TabIndex = 1;
            this.isCtrlCheckBox.Text = "CTRL";
            this.isCtrlCheckBox.UseVisualStyleBackColor = true;
            // 
            // isCrossSelectCheckBox
            // 
            this.isCrossSelectCheckBox.AutoSize = true;
            this.isCrossSelectCheckBox.Location = new System.Drawing.Point(71, 487);
            this.isCrossSelectCheckBox.Name = "isCrossSelectCheckBox";
            this.isCrossSelectCheckBox.Size = new System.Drawing.Size(167, 19);
            this.isCrossSelectCheckBox.TabIndex = 2;
            this.isCrossSelectCheckBox.Text = "Перекрестное выделение";
            this.isCrossSelectCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 516);
            this.Controls.Add(this.isCrossSelectCheckBox);
            this.Controls.Add(this.isCtrlCheckBox);
            this.Controls.Add(this.pictureBox);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox;
        private CheckBox isCtrlCheckBox;
        private CheckBox isCrossSelectCheckBox;
    }
}