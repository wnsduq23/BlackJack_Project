namespace blackjack_windform
{
    partial class StartPage
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("돋움", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(222, 25);
            label1.Name = "label1";
            label1.Size = new Size(370, 40);
            label1.TabIndex = 0;
            label1.Text = "B L A C K J A C K";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.카드이미지;
            pictureBox1.Location = new Point(300, 91);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(197, 120);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.a스페이스카드;
            pictureBox2.Location = new Point(75, 241);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(114, 149);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(274, 242);
            button1.Name = "button1";
            button1.Size = new Size(255, 63);
            button1.TabIndex = 3;
            button1.Text = "PLAY";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(274, 327);
            button2.Name = "button2";
            button2.Size = new Size(255, 63);
            button2.TabIndex = 4;
            button2.Text = "EXIT";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Start Page";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button1;
        private Button button2;
    }
}