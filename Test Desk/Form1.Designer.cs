namespace Test_Desk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btn_1 = new System.Windows.Forms.Button();
            btn_2 = new System.Windows.Forms.Button();
            rtx = new System.Windows.Forms.RichTextBox();
            tb = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // btn_1
            // 
            btn_1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            btn_1.BackgroundImage = (System.Drawing.Image)resources.GetObject("btn_1.BackgroundImage");
            btn_1.Location = new System.Drawing.Point(345, 409);
            btn_1.Name = "btn_1";
            btn_1.Size = new System.Drawing.Size(94, 29);
            btn_1.TabIndex = 0;
            btn_1.Text = "button1";
            btn_1.UseVisualStyleBackColor = false;
            btn_1.Click += btn_1_Click;
            // 
            // btn_2
            // 
            btn_2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_2.Location = new System.Drawing.Point(12, 409);
            btn_2.Name = "btn_2";
            btn_2.Size = new System.Drawing.Size(94, 29);
            btn_2.TabIndex = 1;
            btn_2.Text = "button2";
            btn_2.UseVisualStyleBackColor = true;
            btn_2.Click += btn_2_Click;
            // 
            // rtx
            // 
            rtx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            rtx.Location = new System.Drawing.Point(12, 12);
            rtx.Name = "rtx";
            rtx.Size = new System.Drawing.Size(427, 319);
            rtx.TabIndex = 2;
            rtx.Text = "";
            // 
            // tb
            // 
            tb.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb.Location = new System.Drawing.Point(12, 348);
            tb.Name = "tb";
            tb.Size = new System.Drawing.Size(425, 27);
            tb.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(449, 450);
            Controls.Add(tb);
            Controls.Add(rtx);
            Controls.Add(btn_2);
            Controls.Add(btn_1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btn_1;
        private System.Windows.Forms.Button btn_2;
        private System.Windows.Forms.RichTextBox rtx;
        private System.Windows.Forms.TextBox tb;
    }
}
