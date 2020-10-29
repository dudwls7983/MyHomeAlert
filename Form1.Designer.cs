namespace MyHomeAlert
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.loginButton = new System.Windows.Forms.Button();
            this.buyCheck = new System.Windows.Forms.RadioButton();
            this.sellCheck = new System.Windows.Forms.RadioButton();
            this.keywordBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.refreshCheck = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.postList = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.intervalSlider = new System.Windows.Forms.TrackBar();
            this.intervalTime = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.topMostCheck = new System.Windows.Forms.CheckBox();
            this.alertCheck = new System.Windows.Forms.CheckBox();
            this.browserPanel = new System.Windows.Forms.Panel();
            this.clearCookieButton = new System.Windows.Forms.Button();
            this.autoJoin = new System.Windows.Forms.CheckBox();
            this.notepad = new System.Windows.Forms.RichTextBox();
            this.shareAlert = new System.Windows.Forms.CheckBox();
            this.shareAllow = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.quizAllow = new System.Windows.Forms.CheckBox();
            this.quizAlert = new System.Windows.Forms.CheckBox();
            this.shareJoin = new System.Windows.Forms.CheckBox();
            this.quizJoin = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalSlider)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(6, 6);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(102, 21);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "로그인 체크하기";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // buyCheck
            // 
            this.buyCheck.AutoSize = true;
            this.buyCheck.Checked = true;
            this.buyCheck.Location = new System.Drawing.Point(0, 4);
            this.buyCheck.Name = "buyCheck";
            this.buyCheck.Size = new System.Drawing.Size(47, 16);
            this.buyCheck.TabIndex = 0;
            this.buyCheck.TabStop = true;
            this.buyCheck.Text = "사요";
            this.buyCheck.UseVisualStyleBackColor = true;
            this.buyCheck.CheckedChanged += new System.EventHandler(this.buyCheck_CheckedChanged);
            // 
            // sellCheck
            // 
            this.sellCheck.AutoSize = true;
            this.sellCheck.Location = new System.Drawing.Point(53, 4);
            this.sellCheck.Name = "sellCheck";
            this.sellCheck.Size = new System.Drawing.Size(59, 16);
            this.sellCheck.TabIndex = 0;
            this.sellCheck.Text = "팔아요";
            this.sellCheck.UseVisualStyleBackColor = true;
            // 
            // keywordBox
            // 
            this.keywordBox.Location = new System.Drawing.Point(177, 12);
            this.keywordBox.Name = "keywordBox";
            this.keywordBox.Size = new System.Drawing.Size(172, 21);
            this.keywordBox.TabIndex = 11;
            this.keywordBox.TextChanged += new System.EventHandler(this.keywordBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "키워드";
            // 
            // refreshCheck
            // 
            this.refreshCheck.AutoCheck = false;
            this.refreshCheck.AutoSize = true;
            this.refreshCheck.Location = new System.Drawing.Point(6, 109);
            this.refreshCheck.Name = "refreshCheck";
            this.refreshCheck.Size = new System.Drawing.Size(71, 16);
            this.refreshCheck.TabIndex = 17;
            this.refreshCheck.Text = "자동갱신";
            this.refreshCheck.UseVisualStyleBackColor = true;
            this.refreshCheck.CheckedChanged += new System.EventHandler(this.refreshCheck_CheckedChanged);
            this.refreshCheck.Click += new System.EventHandler(this.radioButton3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "초";
            // 
            // postList
            // 
            this.postList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.postList.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.postList.FormattingEnabled = true;
            this.postList.ItemHeight = 23;
            this.postList.Location = new System.Drawing.Point(12, 42);
            this.postList.Name = "postList";
            this.postList.Size = new System.Drawing.Size(391, 395);
            this.postList.TabIndex = 21;
            this.postList.TabStop = false;
            this.postList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.postList_DrawItem);
            this.postList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.postList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.postList_MouseDown);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(355, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(48, 21);
            this.button5.TabIndex = 22;
            this.button5.TabStop = false;
            this.button5.Text = "갱신";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sellCheck);
            this.groupBox1.Controls.Add(this.buyCheck);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 18);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // intervalSlider
            // 
            this.intervalSlider.AutoSize = false;
            this.intervalSlider.Location = new System.Drawing.Point(6, 131);
            this.intervalSlider.Maximum = 30;
            this.intervalSlider.Minimum = 3;
            this.intervalSlider.Name = "intervalSlider";
            this.intervalSlider.Size = new System.Drawing.Size(360, 33);
            this.intervalSlider.TabIndex = 24;
            this.intervalSlider.TabStop = false;
            this.intervalSlider.Value = 5;
            this.intervalSlider.Scroll += new System.EventHandler(this.intervalSlider_Scroll);
            // 
            // intervalTime
            // 
            this.intervalTime.Location = new System.Drawing.Point(83, 109);
            this.intervalTime.Name = "intervalTime";
            this.intervalTime.Size = new System.Drawing.Size(23, 16);
            this.intervalTime.TabIndex = 25;
            this.intervalTime.Text = "5";
            this.intervalTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 3000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // topMostCheck
            // 
            this.topMostCheck.AutoSize = true;
            this.topMostCheck.Location = new System.Drawing.Point(6, 6);
            this.topMostCheck.Name = "topMostCheck";
            this.topMostCheck.Size = new System.Drawing.Size(72, 16);
            this.topMostCheck.TabIndex = 26;
            this.topMostCheck.Text = "상단고정";
            this.topMostCheck.UseVisualStyleBackColor = true;
            this.topMostCheck.CheckedChanged += new System.EventHandler(this.topMostCheck_CheckedChanged);
            // 
            // alertCheck
            // 
            this.alertCheck.AutoSize = true;
            this.alertCheck.Location = new System.Drawing.Point(128, 6);
            this.alertCheck.Name = "alertCheck";
            this.alertCheck.Size = new System.Drawing.Size(116, 16);
            this.alertCheck.TabIndex = 27;
            this.alertCheck.Text = "키워드 소리 알림";
            this.alertCheck.UseVisualStyleBackColor = true;
            this.alertCheck.CheckedChanged += new System.EventHandler(this.alertCheck_CheckedChanged);
            // 
            // browserPanel
            // 
            this.browserPanel.Location = new System.Drawing.Point(6, 33);
            this.browserPanel.Name = "browserPanel";
            this.browserPanel.Size = new System.Drawing.Size(360, 358);
            this.browserPanel.TabIndex = 30;
            // 
            // clearCookieButton
            // 
            this.clearCookieButton.Location = new System.Drawing.Point(114, 6);
            this.clearCookieButton.Name = "clearCookieButton";
            this.clearCookieButton.Size = new System.Drawing.Size(66, 21);
            this.clearCookieButton.TabIndex = 31;
            this.clearCookieButton.Text = "쿠키 제거";
            this.clearCookieButton.UseVisualStyleBackColor = true;
            this.clearCookieButton.Click += new System.EventHandler(this.clearCookieButton_Click);
            // 
            // autoJoin
            // 
            this.autoJoin.AutoSize = true;
            this.autoJoin.Location = new System.Drawing.Point(250, 6);
            this.autoJoin.Name = "autoJoin";
            this.autoJoin.Size = new System.Drawing.Size(116, 16);
            this.autoJoin.TabIndex = 32;
            this.autoJoin.Text = "키워드 자동 입장";
            this.autoJoin.UseVisualStyleBackColor = true;
            this.autoJoin.CheckedChanged += new System.EventHandler(this.autoJoin_CheckedChanged);
            // 
            // notepad
            // 
            this.notepad.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.notepad.Location = new System.Drawing.Point(836, 12);
            this.notepad.Name = "notepad";
            this.notepad.Size = new System.Drawing.Size(752, 426);
            this.notepad.TabIndex = 33;
            this.notepad.Text = "메모장";
            this.notepad.TextChanged += new System.EventHandler(this.notepad_TextChanged);
            // 
            // shareAlert
            // 
            this.shareAlert.AutoSize = true;
            this.shareAlert.Location = new System.Drawing.Point(128, 28);
            this.shareAlert.Name = "shareAlert";
            this.shareAlert.Size = new System.Drawing.Size(116, 16);
            this.shareAlert.TabIndex = 34;
            this.shareAlert.Text = "나눔글 소리 알림";
            this.shareAlert.UseVisualStyleBackColor = true;
            this.shareAlert.CheckedChanged += new System.EventHandler(this.shareAlert_CheckedChanged);
            // 
            // shareAllow
            // 
            this.shareAllow.AutoSize = true;
            this.shareAllow.Location = new System.Drawing.Point(6, 28);
            this.shareAllow.Name = "shareAllow";
            this.shareAllow.Size = new System.Drawing.Size(88, 16);
            this.shareAllow.TabIndex = 35;
            this.shareAllow.Text = "나눔글 보기";
            this.shareAllow.UseVisualStyleBackColor = true;
            this.shareAllow.CheckedChanged += new System.EventHandler(this.shareJoin_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(409, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(380, 423);
            this.tabControl1.TabIndex = 36;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.loginButton);
            this.tabPage1.Controls.Add(this.clearCookieButton);
            this.tabPage1.Controls.Add(this.browserPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(372, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "브라우저";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.quizJoin);
            this.tabPage2.Controls.Add(this.shareJoin);
            this.tabPage2.Controls.Add(this.intervalTime);
            this.tabPage2.Controls.Add(this.quizAlert);
            this.tabPage2.Controls.Add(this.intervalSlider);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.quizAllow);
            this.tabPage2.Controls.Add(this.shareAlert);
            this.tabPage2.Controls.Add(this.shareAllow);
            this.tabPage2.Controls.Add(this.autoJoin);
            this.tabPage2.Controls.Add(this.alertCheck);
            this.tabPage2.Controls.Add(this.refreshCheck);
            this.tabPage2.Controls.Add(this.topMostCheck);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(372, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "설정";
            // 
            // quizAllow
            // 
            this.quizAllow.AutoSize = true;
            this.quizAllow.Location = new System.Drawing.Point(6, 50);
            this.quizAllow.Name = "quizAllow";
            this.quizAllow.Size = new System.Drawing.Size(88, 16);
            this.quizAllow.TabIndex = 36;
            this.quizAllow.Text = "퀴즈글 보기";
            this.quizAllow.UseVisualStyleBackColor = true;
            this.quizAllow.CheckedChanged += new System.EventHandler(this.quizAllow_CheckedChanged);
            // 
            // quizAlert
            // 
            this.quizAlert.AutoSize = true;
            this.quizAlert.Location = new System.Drawing.Point(128, 50);
            this.quizAlert.Name = "quizAlert";
            this.quizAlert.Size = new System.Drawing.Size(116, 16);
            this.quizAlert.TabIndex = 37;
            this.quizAlert.Text = "퀴즈글 소리 알림";
            this.quizAlert.UseVisualStyleBackColor = true;
            this.quizAlert.CheckedChanged += new System.EventHandler(this.quizAlert_CheckedChanged);
            // 
            // shareJoin
            // 
            this.shareJoin.AutoSize = true;
            this.shareJoin.Location = new System.Drawing.Point(250, 28);
            this.shareJoin.Name = "shareJoin";
            this.shareJoin.Size = new System.Drawing.Size(116, 16);
            this.shareJoin.TabIndex = 38;
            this.shareJoin.Text = "나눔글 자동 입장";
            this.shareJoin.UseVisualStyleBackColor = true;
            this.shareJoin.CheckedChanged += new System.EventHandler(this.shareJoin_CheckedChanged_1);
            // 
            // quizJoin
            // 
            this.quizJoin.AutoSize = true;
            this.quizJoin.Location = new System.Drawing.Point(250, 50);
            this.quizJoin.Name = "quizJoin";
            this.quizJoin.Size = new System.Drawing.Size(116, 16);
            this.quizJoin.TabIndex = 39;
            this.quizJoin.Text = "퀴즈글 자동 입장";
            this.quizJoin.UseVisualStyleBackColor = true;
            this.quizJoin.CheckedChanged += new System.EventHandler(this.quizJoin_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.notepad);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.postList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.keywordBox);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1616, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "솜을 팔아서 큰돈을 벌거야";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalSlider)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.RadioButton buyCheck;
        private System.Windows.Forms.RadioButton sellCheck;
        private System.Windows.Forms.TextBox keywordBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox postList;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton refreshCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar intervalSlider;
        private System.Windows.Forms.Label intervalTime;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.CheckBox topMostCheck;
        private System.Windows.Forms.CheckBox alertCheck;
        private System.Windows.Forms.Panel browserPanel;
        private System.Windows.Forms.Button clearCookieButton;
        private System.Windows.Forms.CheckBox autoJoin;
        private System.Windows.Forms.RichTextBox notepad;
        private System.Windows.Forms.CheckBox shareAlert;
        private System.Windows.Forms.CheckBox shareAllow;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox quizAlert;
        private System.Windows.Forms.CheckBox quizAllow;
        private System.Windows.Forms.CheckBox quizJoin;
        private System.Windows.Forms.CheckBox shareJoin;
    }
}

