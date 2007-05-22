namespace BarcodeRender
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.label1 = new System.Windows.Forms.Label ();
			this.barcodeText = new System.Windows.Forms.TextBox ();
			this.refreshButton = new System.Windows.Forms.Button ();
			this.barcodePanel = new System.Windows.Forms.Panel ();
			this.label2 = new System.Windows.Forms.Label ();
			this.minWidth = new System.Windows.Forms.NumericUpDown ();
			this.label3 = new System.Windows.Forms.Label ();
			this.maxWidth = new System.Windows.Forms.NumericUpDown ();
			this.label4 = new System.Windows.Forms.Label ();
			this.minHeight = new System.Windows.Forms.NumericUpDown ();
			this.label5 = new System.Windows.Forms.Label ();
			this.symbology = new System.Windows.Forms.ComboBox ();
			this.maxHeight = new System.Windows.Forms.NumericUpDown ();
			this.label6 = new System.Windows.Forms.Label ();
			((System.ComponentModel.ISupportInitialize) (this.minWidth)).BeginInit ();
			((System.ComponentModel.ISupportInitialize) (this.maxWidth)).BeginInit ();
			((System.ComponentModel.ISupportInitialize) (this.minHeight)).BeginInit ();
			((System.ComponentModel.ISupportInitialize) (this.maxHeight)).BeginInit ();
			this.SuspendLayout ();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point (13, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (31, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Text:";
			// 
			// barcodeText
			// 
			this.barcodeText.Location = new System.Drawing.Point (51, 48);
			this.barcodeText.Name = "barcodeText";
			this.barcodeText.Size = new System.Drawing.Size (213, 20);
			this.barcodeText.TabIndex = 1;
			// 
			// refreshButton
			// 
			this.refreshButton.Location = new System.Drawing.Point (270, 47);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size (32, 23);
			this.refreshButton.TabIndex = 2;
			this.refreshButton.Text = "...";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler (this.refreshButton_Click);
			// 
			// barcodePanel
			// 
			this.barcodePanel.Location = new System.Drawing.Point (16, 87);
			this.barcodePanel.Name = "barcodePanel";
			this.barcodePanel.Size = new System.Drawing.Size (286, 59);
			this.barcodePanel.TabIndex = 3;
			this.barcodePanel.Paint += new System.Windows.Forms.PaintEventHandler (this.barcodePanel_Paint);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point (19, 155);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size (58, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Min Width:";
			// 
			// minWidth
			// 
			this.minWidth.Location = new System.Drawing.Point (80, 153);
			this.minWidth.Minimum = new decimal (new int[] {
            1,
            0,
            0,
            0});
			this.minWidth.Name = "minWidth";
			this.minWidth.Size = new System.Drawing.Size (68, 20);
			this.minWidth.TabIndex = 5;
			this.minWidth.Value = new decimal (new int[] {
            2,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point (167, 155);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size (61, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Max Width:";
			// 
			// maxWidth
			// 
			this.maxWidth.Location = new System.Drawing.Point (234, 153);
			this.maxWidth.Minimum = new decimal (new int[] {
            1,
            0,
            0,
            0});
			this.maxWidth.Name = "maxWidth";
			this.maxWidth.Size = new System.Drawing.Size (68, 20);
			this.maxWidth.TabIndex = 5;
			this.maxWidth.Value = new decimal (new int[] {
            2,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point (16, 185);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size (61, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Min Height:";
			// 
			// minHeight
			// 
			this.minHeight.Location = new System.Drawing.Point (81, 183);
			this.minHeight.Minimum = new decimal (new int[] {
            10,
            0,
            0,
            0});
			this.minHeight.Name = "minHeight";
			this.minHeight.Size = new System.Drawing.Size (68, 20);
			this.minHeight.TabIndex = 5;
			this.minHeight.Value = new decimal (new int[] {
            30,
            0,
            0,
            0});
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point (13, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size (61, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Symbology:";
			// 
			// symbology
			// 
			this.symbology.FormattingEnabled = true;
			this.symbology.Items.AddRange (new object[] {
            "Code 39 (No Checksum)",
            "Code 39 (With Checksum)",
            "Code 93 (With Checksum)",
            "Code 128 (With Checksum)",
            "Code 11 (No Checksum)",
            "Code 11 (With Checksum)",
            "Code EAN-13 (With Checksum)",
            "Code EAN-8 (With Checksum)"});
			this.symbology.Location = new System.Drawing.Point (81, 14);
			this.symbology.Name = "symbology";
			this.symbology.Size = new System.Drawing.Size (221, 21);
			this.symbology.TabIndex = 8;
			// 
			// maxHeight
			// 
			this.maxHeight.Location = new System.Drawing.Point (234, 183);
			this.maxHeight.Minimum = new decimal (new int[] {
            10,
            0,
            0,
            0});
			this.maxHeight.Name = "maxHeight";
			this.maxHeight.Size = new System.Drawing.Size (68, 20);
			this.maxHeight.TabIndex = 5;
			this.maxHeight.Value = new decimal (new int[] {
            30,
            0,
            0,
            0});
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point (164, 185);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size (64, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Max Height:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (314, 219);
			this.Controls.Add (this.symbology);
			this.Controls.Add (this.label5);
			this.Controls.Add (this.label6);
			this.Controls.Add (this.label4);
			this.Controls.Add (this.label3);
			this.Controls.Add (this.maxHeight);
			this.Controls.Add (this.minHeight);
			this.Controls.Add (this.maxWidth);
			this.Controls.Add (this.minWidth);
			this.Controls.Add (this.label2);
			this.Controls.Add (this.barcodePanel);
			this.Controls.Add (this.refreshButton);
			this.Controls.Add (this.barcodeText);
			this.Controls.Add (this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MainForm";
			this.Text = "Barcode Test";
			this.Load += new System.EventHandler (this.Form1_Load);
			((System.ComponentModel.ISupportInitialize) (this.minWidth)).EndInit ();
			((System.ComponentModel.ISupportInitialize) (this.maxWidth)).EndInit ();
			((System.ComponentModel.ISupportInitialize) (this.minHeight)).EndInit ();
			((System.ComponentModel.ISupportInitialize) (this.maxHeight)).EndInit ();
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox barcodeText;
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.Panel barcodePanel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown minWidth;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown maxWidth;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown minHeight;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox symbology;
		private System.Windows.Forms.NumericUpDown maxHeight;
		private System.Windows.Forms.Label label6;
	}
}

