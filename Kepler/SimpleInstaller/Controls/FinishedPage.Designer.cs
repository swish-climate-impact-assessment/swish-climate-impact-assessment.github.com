namespace Swish.SimpleInstaller.Controls
{
	partial class FinishedPage
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
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.PendingBox = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ExitButton = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 37);
			this.label3.TabIndex = 7;
			this.label3.Text = "Finished";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(0, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 29);
			this.label2.TabIndex = 8;
			// 
			// PendingBox
			// 
			this.PendingBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PendingBox.Location = new System.Drawing.Point(0, 66);
			this.PendingBox.Multiline = true;
			this.PendingBox.Name = "PendingBox";
			this.PendingBox.ReadOnly = true;
			this.PendingBox.Size = new System.Drawing.Size(425, 228);
			this.PendingBox.TabIndex = 9;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ExitButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 294);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(425, 23);
			this.panel1.TabIndex = 10;
			// 
			// ExitButton
			// 
			this.ExitButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.ExitButton.Location = new System.Drawing.Point(350, 0);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(75, 23);
			this.ExitButton.TabIndex = 1;
			this.ExitButton.Text = "Exit";
			this.ExitButton.UseVisualStyleBackColor = true;
			this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
			// 
			// FinishedPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.PendingBox);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Name = "FinishedPage";
			this.Size = new System.Drawing.Size(425, 317);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox PendingBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button ExitButton;
	}
}
