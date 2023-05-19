namespace Gomoku
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
			this.restartButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// restartButton
			// 
			this.restartButton.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.restartButton.Location = new System.Drawing.Point(73, 12);
			this.restartButton.Name = "restartButton";
			this.restartButton.Size = new System.Drawing.Size(194, 59);
			this.restartButton.TabIndex = 0;
			this.restartButton.Text = "重新開始遊戲";
			this.restartButton.UseVisualStyleBackColor = true;
			this.restartButton.Visible = false;
			this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Gomoku.Properties.Resources.board;
			this.ClientSize = new System.Drawing.Size(751, 742);
			this.Controls.Add(this.restartButton);
			this.Name = "Form1";
			this.Text = "五子棋";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button restartButton;
	}
}

