namespace PropertyGridTest.Editors
{
   partial class ForeignLangsControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
         this.btnOK = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // checkedListBox1
         // 
         this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.checkedListBox1.BackColor = System.Drawing.Color.AntiqueWhite;
         this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.checkedListBox1.Font = new System.Drawing.Font("Tahoma", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.checkedListBox1.FormattingEnabled = true;
         this.checkedListBox1.Items.AddRange(new object[] {
            "Английский",
            "Немецкий",
            "Французский",
            "Японский",
            "Китайский",
            "Албанский"});
         this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
         this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.checkedListBox1.Name = "checkedListBox1";
         this.checkedListBox1.Size = new System.Drawing.Size(135, 108);
         this.checkedListBox1.TabIndex = 0;
         // 
         // btnOK
         // 
         this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOK.BackColor = System.Drawing.SystemColors.ButtonFace;
         this.btnOK.Location = new System.Drawing.Point(76, 117);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(54, 23);
         this.btnOK.TabIndex = 1;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = false;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // ForeignLangsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.AntiqueWhite;
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.checkedListBox1);
         this.Font = new System.Drawing.Font("Tahoma", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.Name = "ForeignLangsControl";
         this.Size = new System.Drawing.Size(135, 145);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.CheckedListBox checkedListBox1;
      private System.Windows.Forms.Button btnOK;
   }
}
