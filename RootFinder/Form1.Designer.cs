namespace RootFinder
{
    partial class RootFinder
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RootFinder));
            this.BtnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFunction = new System.Windows.Forms.TextBox();
            this.TxtRoots = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BarRange = new System.Windows.Forms.TrackBar();
            this.LblRange = new System.Windows.Forms.Label();
            this.BarSpeed = new System.Windows.Forms.TrackBar();
            this.LblSpeed = new System.Windows.Forms.Label();
            this.BarAccuracy = new System.Windows.Forms.TrackBar();
            this.LblAccuracy = new System.Windows.Forms.Label();
            this.BarYSqueeze = new System.Windows.Forms.TrackBar();
            this.LblYSqueeze = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BarRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarAccuracy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarYSqueeze)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(12, 241);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(259, 23);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Start Calculation!";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "f(x) =";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtFunction
            // 
            this.TxtFunction.Location = new System.Drawing.Point(54, 9);
            this.TxtFunction.Name = "TxtFunction";
            this.TxtFunction.Size = new System.Drawing.Size(218, 21);
            this.TxtFunction.TabIndex = 2;
            // 
            // TxtRoots
            // 
            this.TxtRoots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtRoots.Location = new System.Drawing.Point(12, 178);
            this.TxtRoots.Multiline = true;
            this.TxtRoots.Name = "TxtRoots";
            this.TxtRoots.ReadOnly = true;
            this.TxtRoots.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtRoots.Size = new System.Drawing.Size(259, 57);
            this.TxtRoots.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Roots";
            // 
            // BarRange
            // 
            this.BarRange.Location = new System.Drawing.Point(13, 52);
            this.BarRange.Maximum = 500;
            this.BarRange.Minimum = 1;
            this.BarRange.Name = "BarRange";
            this.BarRange.Size = new System.Drawing.Size(127, 45);
            this.BarRange.TabIndex = 5;
            this.BarRange.TickFrequency = 50;
            this.BarRange.Value = 50;
            this.BarRange.Scroll += new System.EventHandler(this.BarRange_Scroll);
            // 
            // LblRange
            // 
            this.LblRange.AutoSize = true;
            this.LblRange.Location = new System.Drawing.Point(13, 37);
            this.LblRange.Name = "LblRange";
            this.LblRange.Size = new System.Drawing.Size(55, 12);
            this.LblRange.TabIndex = 6;
            this.LblRange.Text = "Range: 5";
            // 
            // BarSpeed
            // 
            this.BarSpeed.Location = new System.Drawing.Point(145, 52);
            this.BarSpeed.Maximum = 500;
            this.BarSpeed.Minimum = 1;
            this.BarSpeed.Name = "BarSpeed";
            this.BarSpeed.Size = new System.Drawing.Size(127, 45);
            this.BarSpeed.TabIndex = 7;
            this.BarSpeed.TickFrequency = 50;
            this.BarSpeed.Value = 50;
            this.BarSpeed.Scroll += new System.EventHandler(this.BarSpeed_Scroll);
            // 
            // LblSpeed
            // 
            this.LblSpeed.AutoSize = true;
            this.LblSpeed.Location = new System.Drawing.Point(145, 37);
            this.LblSpeed.Name = "LblSpeed";
            this.LblSpeed.Size = new System.Drawing.Size(87, 12);
            this.LblSpeed.TabIndex = 8;
            this.LblSpeed.Text = "Speed(Xps): 5";
            // 
            // BarAccuracy
            // 
            this.BarAccuracy.Location = new System.Drawing.Point(12, 115);
            this.BarAccuracy.Maximum = 5;
            this.BarAccuracy.Minimum = 1;
            this.BarAccuracy.Name = "BarAccuracy";
            this.BarAccuracy.Size = new System.Drawing.Size(127, 45);
            this.BarAccuracy.TabIndex = 9;
            this.BarAccuracy.Value = 3;
            this.BarAccuracy.Scroll += new System.EventHandler(this.BarAccuracy_Scroll);
            // 
            // LblAccuracy
            // 
            this.LblAccuracy.AutoSize = true;
            this.LblAccuracy.Location = new System.Drawing.Point(13, 100);
            this.LblAccuracy.Name = "LblAccuracy";
            this.LblAccuracy.Size = new System.Drawing.Size(73, 12);
            this.LblAccuracy.TabIndex = 10;
            this.LblAccuracy.Text = "Accuracy: 3";
            // 
            // BarYSqueeze
            // 
            this.BarYSqueeze.Location = new System.Drawing.Point(145, 115);
            this.BarYSqueeze.Maximum = 100;
            this.BarYSqueeze.Minimum = 1;
            this.BarYSqueeze.Name = "BarYSqueeze";
            this.BarYSqueeze.Size = new System.Drawing.Size(126, 45);
            this.BarYSqueeze.TabIndex = 11;
            this.BarYSqueeze.TickFrequency = 10;
            this.BarYSqueeze.Value = 50;
            this.BarYSqueeze.Scroll += new System.EventHandler(this.BarYSqueeze_Scroll);
            // 
            // LblYSqueeze
            // 
            this.LblYSqueeze.AutoSize = true;
            this.LblYSqueeze.Location = new System.Drawing.Point(145, 100);
            this.LblYSqueeze.Name = "LblYSqueeze";
            this.LblYSqueeze.Size = new System.Drawing.Size(81, 12);
            this.LblYSqueeze.TabIndex = 12;
            this.LblYSqueeze.Text = "Y Squeeze: 5";
            // 
            // RootFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 273);
            this.Controls.Add(this.LblYSqueeze);
            this.Controls.Add(this.BarYSqueeze);
            this.Controls.Add(this.LblAccuracy);
            this.Controls.Add(this.BarAccuracy);
            this.Controls.Add(this.LblSpeed);
            this.Controls.Add(this.BarSpeed);
            this.Controls.Add(this.LblRange);
            this.Controls.Add(this.BarRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtRoots);
            this.Controls.Add(this.TxtFunction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RootFinder";
            this.Text = "Root Finder";
            ((System.ComponentModel.ISupportInitialize)(this.BarRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarAccuracy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarYSqueeze)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFunction;
        private System.Windows.Forms.TextBox TxtRoots;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar BarRange;
        private System.Windows.Forms.Label LblRange;
        private System.Windows.Forms.TrackBar BarSpeed;
        private System.Windows.Forms.Label LblSpeed;
        private System.Windows.Forms.TrackBar BarAccuracy;
        private System.Windows.Forms.Label LblAccuracy;
        private System.Windows.Forms.TrackBar BarYSqueeze;
        private System.Windows.Forms.Label LblYSqueeze;
    }
}

