namespace ElepaniStage
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OutputText = new System.Windows.Forms.TextBox();
            this.StageViewer = new System.Windows.Forms.PictureBox();
            this.ButtonPlayer = new System.Windows.Forms.Button();
            this.ButtonEnemy = new System.Windows.Forms.Button();
            this.ButtonBlock = new System.Windows.Forms.Button();
            this.ButtonElectric = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.MapDistanse = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mousePositionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BlockLimit = new System.Windows.Forms.NumericUpDown();
            this.ElectricLimit = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.StageViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapDistanse)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlockLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElectricLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // OutputText
            // 
            this.OutputText.Location = new System.Drawing.Point(12, 12);
            this.OutputText.Name = "OutputText";
            this.OutputText.Size = new System.Drawing.Size(687, 25);
            this.OutputText.TabIndex = 0;
            // 
            // StageViewer
            // 
            this.StageViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StageViewer.Location = new System.Drawing.Point(143, 98);
            this.StageViewer.Name = "StageViewer";
            this.StageViewer.Size = new System.Drawing.Size(823, 500);
            this.StageViewer.TabIndex = 1;
            this.StageViewer.TabStop = false;
            this.StageViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StageViewer_MouseDown);
            this.StageViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StageViewer_MouseMove);
            this.StageViewer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StageViewer_MouseUp);
            // 
            // ButtonPlayer
            // 
            this.ButtonPlayer.Location = new System.Drawing.Point(12, 44);
            this.ButtonPlayer.Name = "ButtonPlayer";
            this.ButtonPlayer.Size = new System.Drawing.Size(127, 86);
            this.ButtonPlayer.TabIndex = 2;
            this.ButtonPlayer.Text = "プレイヤー";
            this.ButtonPlayer.UseVisualStyleBackColor = true;
            this.ButtonPlayer.Click += new System.EventHandler(this.ButtonPlayer_Click);
            // 
            // ButtonEnemy
            // 
            this.ButtonEnemy.Location = new System.Drawing.Point(12, 135);
            this.ButtonEnemy.Name = "ButtonEnemy";
            this.ButtonEnemy.Size = new System.Drawing.Size(127, 86);
            this.ButtonEnemy.TabIndex = 3;
            this.ButtonEnemy.Text = "敵";
            this.ButtonEnemy.UseVisualStyleBackColor = true;
            this.ButtonEnemy.Click += new System.EventHandler(this.ButtonEnemy_Click);
            // 
            // ButtonBlock
            // 
            this.ButtonBlock.Location = new System.Drawing.Point(12, 226);
            this.ButtonBlock.Name = "ButtonBlock";
            this.ButtonBlock.Size = new System.Drawing.Size(127, 86);
            this.ButtonBlock.TabIndex = 4;
            this.ButtonBlock.Text = "ブロック";
            this.ButtonBlock.UseVisualStyleBackColor = true;
            this.ButtonBlock.Click += new System.EventHandler(this.ButtonBlock_Click);
            // 
            // ButtonElectric
            // 
            this.ButtonElectric.Location = new System.Drawing.Point(12, 316);
            this.ButtonElectric.Name = "ButtonElectric";
            this.ButtonElectric.Size = new System.Drawing.Size(127, 86);
            this.ButtonElectric.TabIndex = 5;
            this.ButtonElectric.Text = "電流置く";
            this.ButtonElectric.UseVisualStyleBackColor = true;
            this.ButtonElectric.Click += new System.EventHandler(this.ButtonElectric_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 408);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(127, 86);
            this.button5.TabIndex = 6;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 500);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(127, 86);
            this.button6.TabIndex = 7;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.Location = new System.Drawing.Point(143, 601);
            this.hScrollBar1.Maximum = 30;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(823, 26);
            this.hScrollBar1.TabIndex = 8;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "マップの長さ";
            // 
            // MapDistanse
            // 
            this.MapDistanse.Location = new System.Drawing.Point(148, 66);
            this.MapDistanse.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.MapDistanse.Name = "MapDistanse";
            this.MapDistanse.Size = new System.Drawing.Size(88, 25);
            this.MapDistanse.TabIndex = 10;
            this.MapDistanse.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.MapDistanse.ValueChanged += new System.EventHandler(this.MapDistanse_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(708, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 48);
            this.button1.TabIndex = 11;
            this.button1.Text = "クリップにコピー";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "PlsyerPic.png");
            this.imageList1.Images.SetKeyName(1, "EnemyPic.png");
            this.imageList1.Images.SetKeyName(2, "BLOCK.png");
            this.imageList1.Images.SetKeyName(3, "ELECTRIC.png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mousePositionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 625);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(978, 30);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mousePositionStatus
            // 
            this.mousePositionStatus.Name = "mousePositionStatus";
            this.mousePositionStatus.Size = new System.Drawing.Size(179, 25);
            this.mousePositionStatus.Text = "mousePositionStatus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "ブロックの数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "電流置くの数";
            // 
            // BlockLimit
            // 
            this.BlockLimit.Location = new System.Drawing.Point(309, 66);
            this.BlockLimit.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.BlockLimit.Name = "BlockLimit";
            this.BlockLimit.Size = new System.Drawing.Size(88, 25);
            this.BlockLimit.TabIndex = 15;
            this.BlockLimit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ElectricLimit
            // 
            this.ElectricLimit.Location = new System.Drawing.Point(423, 67);
            this.ElectricLimit.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ElectricLimit.Name = "ElectricLimit";
            this.ElectricLimit.Size = new System.Drawing.Size(88, 25);
            this.ElectricLimit.TabIndex = 16;
            this.ElectricLimit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(978, 655);
            this.Controls.Add(this.ElectricLimit);
            this.Controls.Add(this.BlockLimit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MapDistanse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.ButtonElectric);
            this.Controls.Add(this.ButtonBlock);
            this.Controls.Add(this.ButtonEnemy);
            this.Controls.Add(this.ButtonPlayer);
            this.Controls.Add(this.StageViewer);
            this.Controls.Add(this.OutputText);
            this.Name = "Form1";
            this.Text = "エレパニステージ";
            ((System.ComponentModel.ISupportInitialize)(this.StageViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapDistanse)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlockLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElectricLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OutputText;
        private System.Windows.Forms.PictureBox StageViewer;
        private System.Windows.Forms.Button ButtonPlayer;
        private System.Windows.Forms.Button ButtonEnemy;
        private System.Windows.Forms.Button ButtonBlock;
        private System.Windows.Forms.Button ButtonElectric;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown MapDistanse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel mousePositionStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown BlockLimit;
        private System.Windows.Forms.NumericUpDown ElectricLimit;
    }
}

