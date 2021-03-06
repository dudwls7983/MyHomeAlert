﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 파싱용 임포트
using agi = HtmlAgilityPack;
using System.Net;
using System.Web;

// 크롬용 임포트
using CefSharp;
using CefSharp.WinForms;

namespace MyHomeAlert
{
    public partial class Form1 : Form
    {
        public class BoardData : IComparable<BoardData>
        {
            public int id;
            public string title;
            public bool showContent;

            public BoardData(int _id, string _title, bool _showContent)
            {
                id = _id;
                title = _title;
                showContent = _showContent;
            }

            public int CompareTo(BoardData compareData)
            {
                if (compareData == null)
                    return 1;
                else
                    return compareData.id.CompareTo(id);
            }
        }

        List<BoardData> boardDataList;
        ChromiumWebBrowser browser;
        WMPLib.WindowsMediaPlayer alertSound;
        int lastIndex;

        public Form1()
        {
            InitializeComponent();
            boardDataList = new List<BoardData>();
            lastIndex = 0;
            alertSound = new WMPLib.WindowsMediaPlayer();
            alertSound.URL = System.IO.Path.Combine(Application.StartupPath, "Sound", "Alert.mp3");
            alertSound.controls.stop();
        }

        private void RefreshBoard(bool init = false)
        {
            postList.Items.Clear();
            boardDataList.Clear();
            using (WebClient client = new WebClient())
            {
                // clubid 28622252(놀러와 마이홈 공식카페) menuid 20(의뢰게시판)
                string html = client.DownloadString("https://cafe.naver.com/ArticleList.nhn?search.clubid=28622252&search.menuid=20&userDisplay=50");
                GetPostFromHTML(html, init);

                // clubid 28622252(놀러와 마이홈 공식카페) menuid 43(광장에서 만나요)
                html = client.DownloadString("https://cafe.naver.com/ArticleList.nhn?search.clubid=28622252&search.menuid=43&userDisplay=50");
                GetPostFromHTML(html, init);

                if(shareAllow.Checked || quizAllow.Checked)
                {
                    // clubid 28622252(놀러와 마이홈 공식카페) (전체글보기)
                    html = client.DownloadString("https://cafe.naver.com/ArticleList.nhn?search.clubid=28622252&userDisplay=50");
                    GetPostFromHTML(html, init);
                }
                
                boardDataList.Sort();
                for (int i = 0; i < boardDataList.Count; i++)
                {
                    var boardData = boardDataList[i];

                    postList.Items.Add(boardData.title);
                }
                foreach (var boardData in boardDataList)
                {
                }
            }
        }

        private void GetPostFromHTML(string html, bool init)
        {
            int index = 0;

            var doc = new agi.HtmlDocument();
            doc.LoadHtml(html);
            var boardListNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'article-board m-tcol-c')][2]");
            var boardList = boardListNode.Descendants("tr");
            foreach (var board in boardList)
            {
                var innerNumber = board.Descendants().Where(n => n.HasClass("inner_number"));
                if (innerNumber.Any() == false)
                {
                    var article = board.Descendants().Where(n => n.HasClass("article"));
                    if (article.Any() == false)
                        continue;

                    var parsed = HttpUtility.ParseQueryString(article.First().Attributes["href"].Value);
                    if (int.TryParse(parsed["articleid"], out index) == false)
                        continue;
                }
                else
                {
                    var indexString = Trim(innerNumber.First().InnerText);

                    if (int.TryParse(indexString, out index) == false)
                        continue;
                }

                // 같은 보드 데이터는 다시 담을 필요가 없다.
                if (boardDataList.Exists(x => x.id == index))
                    continue;

                bool isNewPost = false;
                if (index > lastIndex)
                {
                    lastIndex = index;
                    isNewPost = true;
                }
                
                var name = Trim(board.Descendants().Where(n => n.HasClass("td_name")).First().InnerText);
                var date = Trim(board.Descendants().Where(n => n.HasClass("td_date")).First().InnerText);
                var title = Trim(board.Descendants().Where(n => n.HasClass("article")).First().InnerText);

                int typeCheck = 0;

                // 퀴즈와 나눔이 같이 들어갈 경우 나눔의 우선순위가 더 높다.
                if (quizAllow.Checked && title.Contains("퀴즈")) typeCheck = 3;
                if (shareAllow.Checked && title.Contains("나눔")) typeCheck = 2;

                if(typeCheck == 0)
                {
                    string checkTitle = title;
                    var head = board.Descendants().Where(n => n.HasClass("head"));
                    // 머리말이 있으면 머리말을 체크한다.
                    if (head.Any())
                    {
                        var type = Trim(head.First().InnerText);
                        title = title.Replace(type, ""); // 제목에는 머리말을 제거해준다.
                        checkTitle = type;
                    }
                    // 팔아요 체크일 때에는 팔/팝 들어가는지 체크
                    if (sellCheck.Checked == true && (checkTitle.Contains("팔") || checkTitle.Contains("팝")) ||
                        buyCheck.Checked == true && (checkTitle.Contains("사") || checkTitle.Contains("삽")))
                        typeCheck = 1;
                }
                

                if (typeCheck > 0)
                {
                    bool alert = false;
                    bool join = false;
                    switch (typeCheck)
                    {
                        case 1:
                            alert = alertCheck.Checked;
                            join = autoJoin.Checked;
                            break;
                        case 2:
                            alert = shareAlert.Checked;
                            join = shareJoin.Checked;
                            break;
                        case 3:
                            alert = quizAlert.Checked;
                            join = quizJoin.Checked;
                            break;
                    }

                    // 키워드 체크
                    if (typeCheck == 1 && Trim(keywordBox.Text) != string.Empty)
                    {
                        bool success = false;
                        string[] words = keywordBox.Text.Split(new char[] { ',', '+', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in words)
                        {
                            if (title.Contains(word))
                            {
                                success = true;
                                break;
                            }
                        }
                        if (success == false)
                        {
                            continue;
                        }
                    }

                    // init이 아니고 새글이면
                    if(isNewPost && !init)
                    {
                        if(alert) // 알람 체크
                        {
                            if (System.IO.File.Exists(alertSound.URL))
                            {
                                alertSound.controls.stop();
                                alertSound.controls.currentPosition = 0;
                                alertSound.controls.play();
                            }
                            else
                            {
                                System.Media.SystemSounds.Beep.Play();
                            }
                        }

                        if(join) // 자동입장 체크
                        {
                            string url = "https://m.cafe.naver.com/ca-fe/web/cafes/28622252/articles/" + index;
                            browser.Load(url);
                        }
                    }

                    // 댓글 체크
                    var reply = board.Descendants().Where(n => n.HasClass("cmt"));
                    string cmt = reply.Any() ? Trim(reply.First().InnerText) : "    ";
                    title = cmt + " " + title + " / " + name + "(" + date + ")";

                    boardDataList.Add(new BoardData(index, title, (typeCheck > 1)));
                }
            }
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            refreshCheck.Checked = !refreshCheck.Checked;
        }

        // 글자없는 공백/개행 모두 제거
        private string Trim(string text)
        {
            string retn = System.Text.RegularExpressions.Regex.Replace(text, @"(\s)\s+", "$1");
            retn = retn.Replace("\n", "");
            retn = System.Text.RegularExpressions.Regex.Replace(retn, @"&[#0-9]*;", "");
            return retn;
        }

        private void LoadSettings()
        {
            sellCheck.Checked = Properties.Settings.Default.isSell;
            alertCheck.Checked = Properties.Settings.Default.canAlert;
            topMostCheck.Checked = Properties.Settings.Default.isTopMost;
            refreshCheck.Checked = Properties.Settings.Default.autoRefresh;
            intervalSlider.Value = Properties.Settings.Default.interval;
            keywordBox.Text = Properties.Settings.Default.keyword;
            autoJoin.Checked = Properties.Settings.Default.autoJoin;
            notepad.Text = Properties.Settings.Default.notepad;
            shareAlert.Checked = Properties.Settings.Default.shareAlert;
            shareAllow.Checked = Properties.Settings.Default.shareAllow;
            shareJoin.Checked = Properties.Settings.Default.shareJoin;
            quizAllow.Checked = Properties.Settings.Default.quizAllow;
            quizAlert.Checked = Properties.Settings.Default.quizAlert;
            quizJoin.Checked = Properties.Settings.Default.quizJoin;

            intervalTime.Text = intervalSlider.Value.ToString();
            refreshTimer.Interval = intervalSlider.Value * 1000;
            refreshTimer.Enabled = refreshCheck.Checked;

            FixTitle();
        }

        private void FixTitle()
        {
            string keyword = Trim(keywordBox.Text);
            if (keyword == string.Empty)
                keyword = "모두 ";
            else
                keyword = "{0}.를 ".FormatK(keyword);

            Text = keyword + (sellCheck.Checked ? "사서 더 비싸게 팔거야" : "팔아서 큰돈을 벌거야");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
            RefreshBoard(true);

            // 크롬 임베디드 웹 브라우저 생성
            browser = new ChromiumWebBrowser("https://nid.naver.com/user2/help/myInfo.nhn?lang=ko_KR");
            browserPanel.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RefreshBoard();
        }

        private void intervalSlider_Scroll(object sender, EventArgs e)
        {
            intervalTime.Text = intervalSlider.Value.ToString();
            Properties.Settings.Default.interval = intervalSlider.Value;
            Properties.Settings.Default.Save();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshBoard();
        }

        private void topMostCheck_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = topMostCheck.Checked;
            Properties.Settings.Default.isTopMost = topMostCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (postList.SelectedIndex == -1)
                return;

            if (postList.SelectedIndex >= boardDataList.Count)
                return;

            var boardData = boardDataList[postList.SelectedIndex];
            string url = "https://m.cafe.naver.com/ca-fe/web/cafes/28622252/articles/" + boardData.id + "/comments";
            browser.Load(url);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            browser.Load("https://nid.naver.com/user2/help/myInfo.nhn?lang=ko_KR");
        }

        private void clearCookieButton_Click(object sender, EventArgs e)
        {
            Cef.GetGlobalCookieManager().DeleteCookies();
        }

        private void buyCheck_CheckedChanged(object sender, EventArgs e)
        {
            FixTitle();
            Properties.Settings.Default.isSell = sellCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private void keywordBox_TextChanged(object sender, EventArgs e)
        {
            FixTitle();
            Properties.Settings.Default.keyword = keywordBox.Text;
            Properties.Settings.Default.Save();
        }

        private void refreshCheck_CheckedChanged(object sender, EventArgs e)
        {
            refreshTimer.Interval = intervalSlider.Value * 1000;
            refreshTimer.Enabled = refreshCheck.Checked;

            Properties.Settings.Default.autoRefresh = refreshCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private void alertCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.canAlert = alertCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private void autoJoin_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoJoin = autoJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void notepad_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.notepad = notepad.Text;
            Properties.Settings.Default.Save();
        }

        private void shareAlert_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.shareAlert = shareAlert.Checked;
            Properties.Settings.Default.Save();
        }

        private void shareJoin_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.shareAllow = shareAllow.Checked;
            Properties.Settings.Default.Save();
        }

        private void shareJoin_CheckedChanged_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.shareJoin = shareJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void quizAllow_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.quizAllow = quizAllow.Checked;
            Properties.Settings.Default.Save();
        }

        private void quizAlert_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.quizAlert = quizAlert.Checked;
            Properties.Settings.Default.Save();
        }

        private void quizJoin_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.quizJoin = quizJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void postList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            Color selectionColor = (e.Index & 1) == 0 ? Color.FromArgb(253, 253, 200) : Color.FromArgb(200, 253, 253);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, selectionColor);

            e.DrawBackground();
            Brush brush = (e.Index & 1) == 0 ? Brushes.Red : Brushes.Blue;
            e.Graphics.DrawString(postList.Items[e.Index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void postList_MouseDown(object sender, MouseEventArgs e)
        {
            // listbox 바깥의 여백을 클릭하면 선택이 해제된다.
            if(postList.IndexFromPoint(e.Location) == ListBox.NoMatches)
            {
                postList.SelectedIndex = -1;
            }
        }
    }
}
