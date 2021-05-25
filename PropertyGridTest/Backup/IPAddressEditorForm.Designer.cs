namespace PropertyGridTest
{
   partial class IPAddressEditorForm
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
         this.btnOK = new System.Windows.Forms.Button();
         this.IPmaskedTextBox = new System.Windows.Forms.MaskedTextBox();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(101, 46);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 2;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         // 
         // IPmaskedTextBox
         // 
         this.IPmaskedTextBox.BeepOnError = true;
         this.IPmaskedTextBox.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.IPmaskedTextBox.Location = new System.Drawing.Point(13, 11);
         this.IPmaskedTextBox.Mask = "099\\.099\\.099\\.099";
         this.IPmaskedTextBox.Name = "IPmaskedTextBox";
         this.IPmaskedTextBox.Size = new System.Drawing.Size(163, 29);
         this.IPmaskedTextBox.TabIndex = 1;
         this.IPmaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // IPAddressEditorForm
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(188, 74);
         this.Controls.Add(this.IPmaskedTextBox);
         this.Controls.Add(this.btnOK);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "IPAddressEditorForm";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "IP адрес";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.MaskedTextBox IPmaskedTextBox;
   }
}