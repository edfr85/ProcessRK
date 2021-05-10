using processKR;
using PRM.UC;
using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PRM
{
    public partial class FrMain : Form
    {

        #region 선언부
        ucCon uce; //유저컨트롤 선언
        bool bExitApp = false;

        string sShortProcessName = "";
        string sKListPath; //경로 변수 설정
        string sRListPath; //경로 변수 설정
        string sProcessName; // 프로세스 명 변수 설정
        int nCnt; // 리스트 카운트 변수 설정
        #endregion

        public FrMain()
        {
            InitializeComponent();
            PrmIcon.ContextMenuStrip = PrmContextMenu;
            sKListPath = Environment.CurrentDirectory + @"\KList.ini"; //경로
            sRListPath = Environment.CurrentDirectory + @"\RList.ini"; //Run 경로



        }

        #region 폼 로딩
        private void FrMain_Load(object sender, EventArgs e) //로딩 시
        {
            uce = new ucCon();
            //frmUpdate = new FrmUpdate();
            Controls.Add(uce);
            showKillList();
            showRunList();

            uce.RefreshList += new RefreshListEvent(this.Refresh);
            uce.delRefreshList += new delRefreshListEvent(this.delRefresh);
            uce.ucTimerMain += new ucTimerEvent(this.StopStripMenu_Change);

        }
        #endregion

        #region 리스트 새로고침
        new public void Refresh() //새로고침 (리스트 추가 or 삭제시)
        { 
            showKillList();
            showRunList();

        }
        public void delRefresh(int count) // 새로고침 (리스트 파일 삭제시)
        {
            if(count == 1)
            {
                KillLv.Items.Clear();
            }
            else if(count == 2)
            {
                RunLv.Items.Clear();
            }
            else if(count == 3)
            {
                if (!bExitApp)
                {
                    activate(false);
                }
            }
        }
        #endregion

        #region 리스트
        public void showKillList() //킬리스트 출력
        {
            KillLv.Items.Clear();
            
            nCnt = CIni.Load("PROCESS", "CNT", 0, sKListPath); //카운트 


            if (nCnt > 0) //리스트 출력 
            {
                for (int i = 0; i < nCnt; ++i) //카운트 수만큼 반복
                {
                    sProcessName = CIni.Load("PROCESS", (i + 1).ToString(), "", sKListPath);
                    KillLv.Items.Add(sProcessName);

                }

            }


        }

        public void showRunList() // 런리스트 보여주는 함수
        {
            RunLv.Items.Clear();
            
            nCnt = CIni.Load("PROCESS", "CNT", 0, sRListPath); //카운트 

            if (nCnt > 0) //run 리스트 출력
            {
                
                for (int i = 0; i < nCnt; ++i) //카운트 수만큼 반복
                {
                    sProcessName = CIni.Load("PROCESS", (i + 1).ToString(), "", sRListPath);
                    sShortProcessName = sProcessName.Substring(sProcessName.LastIndexOf("\\") + 1);
                    RunLv.Items.Add(sShortProcessName);
                }
            }
        }

        private void KillLv_SelectedIndexChanged(object sender, EventArgs e) //킬 프로세스 리스트 뷰 클릭시 이벤트
        {
            try
            {
                uce.rcDataK(KillLv.SelectedItems[0].Index);
                uce.rcDataKC(KillLv.SelectedItems.Count);
            }
            catch (Exception ex)
            {
                uce.rcDataKC(0);
                Console.WriteLine(ex);
            }
        }

        private void RunLv_SelectedIndexChanged(object sender, EventArgs e) //실행 프로그램 리스트뷰 클릭시 이벤트
        {

            try
            {
                uce.rcDataR(RunLv.SelectedItems[0].Index);
                uce.rcDataRC(RunLv.SelectedItems.Count);
            }
            catch (Exception ex)
            {
                uce.rcDataRC(0);
                Console.WriteLine(ex);
            }

        }
        #endregion

        #region 트레이 아이콘
        private void activate(bool bActive) //트레이 연계
        {
            if (bActive)
            {
                this.Visible = true; //창을 보이지 않게 한다.
                this.ShowIcon = true; //작업표시줄에서 제거.
                PrmIcon.Visible = false; //트레이 아이콘을 표시한다.
                if (this.WindowState == FormWindowState.Minimized)
                    this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Visible = false; //창을 보이지 않게 한다.
                this.ShowIcon = false; //작업표시줄에서 제거.
                PrmIcon.Visible = true; //트레이 아이콘을 표시한다.
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void frmMain_Resize(object sender, EventArgs e) //폼 최소화 클릭 시 트레이
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                activate(false);
            }
        }


        private void PrmIcon_MouseDoubleClick(object sender, MouseEventArgs e) //이 밑으로 트레이 <- 여기는 아이콘 클릭시 보이는 폼 액티브
        {
            activate(true);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) //폼 닫을때 끄지말고 아이콘 비활성
        {
            if (!bExitApp)
            {
                e.Cancel = true;
                activate(false);
            }
        }

        private void PrmIcon_MouseClick(object sender, MouseEventArgs e) //일단 제외
        {
            //activate(true);
            //PrmContextMenu.Show(Control.MousePosition);
        }


        private void PrmIconOpen_Click(object sender, EventArgs e) //트레이에서 열기 클릭
        {
            activate(true);
        }

        private void PrmIconClose_Click(object sender, EventArgs e) // 트레이에서 종료 클릭
        {
            try
            {


                uce.StopTimer();
                bExitApp = true;
                PrmIcon.Visible = false;
                Application.Exit();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void StopStripMenu_Click(object sender, EventArgs e) //트레이에서 중지 클릭
        {
            if (StopStripMenu.Text == "중지")
            {
                uce.StopTimer();
                
                StopStripMenu.Text = "시작";
            }
            else
            {
                uce.StopTimer();
                StopStripMenu.Text = "중지";
            }
        }
        private void StopStripMenu_Change() //폼에서 타이머 버튼클릭 시
        {
            if (StopStripMenu.Text == "중지")
            {
                StopStripMenu.Text = "시작";
            }
            else
            {
                StopStripMenu.Text = "중지";
            }
        }
        #endregion

        private void updateStripMenu_Click(object sender, EventArgs e)
        {

                if (StopStripMenu.Text == "중지")
                {
                    uce.StopTimer();

                    StopStripMenu.Text = "시작";
                }
            uce.RunProcessKill();
            

        }


    }
}
