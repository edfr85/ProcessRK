using processKR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRM.UC
{
    #region delegate 선언
    public delegate void RefreshListEvent();
    public delegate void delRefreshListEvent(int delcount);
    public delegate void ucTimerEvent();
    public delegate void SendPathEvent(string sPath);
    public delegate void SendSecondEvent();


    #endregion

    public partial class ucCon : UserControl
    {
        #region 선언부
        public RefreshListEvent RefreshList;
        public delRefreshListEvent delRefreshList;
        public ucTimerEvent ucTimerMain;
        public SendPathEvent sendPath;
        public SendSecondEvent sendSecond;



        Timer m_tmrCount;
        fmList frmlistInUc;
        FrMain frmMainInUc;
        FrmUpdate frmUpdateInUc;

        ProcessStartInfo psi = new ProcessStartInfo(); //프로세스 시작 정보
        Process Process_ = new Process(); // 프로세스

        string sLogPro = ""; // 로그로 보낼 내용
        string sProcessName = "";
        int nKSelectrow; //킬리스트 선택 시 서브아이템 담을 변수 선언
        int nRSelectrow; //런리스트 선택 시 서브아이템 담을 변수 선언
        int nKItemAllCount; //리스트 서브아이템 개수 변수 선언
        int nRItemAllCount; //리스트 서브아이템 개수 변수 선언
        int nClosenum = 0; // 프로그램 종료 카운트 3 되면 종료 4 까지만 증가
        int nCnum; //
        int nShowCnt = 0; 

        string sKListPath = Environment.CurrentDirectory + @"\KList.ini"; //킬리스트 경로 (없으면 생성)
        string sRListPath = Environment.CurrentDirectory + @"\RList.ini"; //경로 (없으면 생성)
        #endregion

        public ucCon()
        {
            InitializeComponent();

            m_tmrCount = new Timer();
            m_tmrCount.Interval = 2000;  //5초로 설정~~

            m_tmrCount.Tick += new EventHandler(m_tmrCount_KR); //이벤트 실행
        }

        #region 폼로딩
        private void ucCon_Load(object sender, EventArgs e) // 로딩 시
        {
            LogLv.Sorting = SortOrder.Descending; //로그리스트 최신이 제일 위로
            frmlistInUc = new fmList();
            frmMainInUc = new FrMain();
            frmUpdateInUc = new FrmUpdate();
            
            //frmMainInUc.Update = this.RunProcessKill;
            frmMainInUc.PrmIcon.Visible = false; //아이콘 중복 비활성
            frmMainInUc.Close(); //중복 실행 방지
            frmlistInUc.DataSendE += new AddKillProcessOkEvent(this.dataget);
            frmUpdateInUc.upTimer += this.StopTimer;
            frmUpdateInUc.updateClick += this.RunProcessKill;
            frmUpdateInUc.updateLog += this.UpdateLog;

            m_tmrCount.Start(); //카운트 시작
        }
        #endregion

        #region 메인 연계 함수
        public void dataget(string sData) // 리스트 변경시 새로고침
        {

            if (sData == "")
            {
                RefreshList();
            }
            else
            {
                KillLogWrite(sData);
                RefreshList();
            }
        }

        public void StopTimer() //메인에서 중지 클릭 시.
        {
            KillTitmer();
        }
        #endregion

        #region 로그 작성
        public void RunLogWrite(string rundata)// Run 로그 작성
        {
            string sFilePath = Environment.CurrentDirectory + @"\Log\";
            string sDirPath = Environment.CurrentDirectory + @"\Log\" + DateTime.Today.ToString("yyyy_MM");
            string sTemp;
            StringBuilder Pathbuilder = new StringBuilder();
            Pathbuilder.Append(sFilePath).Append(DateTime.Today.ToString("yyyy_MM")).Append("\\").Append(DateTime.Today.ToString("yyyyMMdd")).Append("_Log_Run").Append(".log");

            DirectoryInfo di = new DirectoryInfo(sDirPath);
            FileInfo fi = new FileInfo(Pathbuilder.ToString());

            try
            {
                if (!di.Exists) Directory.CreateDirectory(sDirPath);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(Pathbuilder.ToString()))
                    {
                        sTemp = string.Format("[{0}] {1}", DateTime.Now, rundata);
                        sw.WriteLine(sTemp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(Pathbuilder.ToString()))
                    {
                        sTemp = string.Format("[{0}] {1}", DateTime.Now, rundata);
                        sw.WriteLine(sTemp);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            AddListToLog(rundata);
        }

        public void KillLogWrite(string Killdata) //Kill 로그 작성
        {
            string sFilePath = Environment.CurrentDirectory + @"\Log\";
            string sDirPath = Environment.CurrentDirectory + @"\Log\" + DateTime.Today.ToString("yyyy_MM");
            //string DirPath = Environment.CurrentDirectory + @"\Log\" + DateTime.Today.ToString("yyyy_MM") + "\\Kill";
            string stemp;
            StringBuilder Pathbuilder = new StringBuilder();
            Pathbuilder.Append(sFilePath).Append(DateTime.Today.ToString("yyyy_MM")).Append("\\").Append(DateTime.Today.ToString("yyyyMMdd")).Append("_Log_KIll").Append(".log");
            //Pathbuilder.Append(FilePath).Append(DateTime.Today.ToString("yyyy_MM")).Append("\\Kill").Append("\\Log_Kill_").Append(DateTime.Today.ToString("yyyyMMdd")).Append(".log");

            DirectoryInfo di = new DirectoryInfo(sDirPath);
            FileInfo fi = new FileInfo(Pathbuilder.ToString());

            try
            {
                if (!di.Exists) Directory.CreateDirectory(sDirPath);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(Pathbuilder.ToString()))
                    {
                        stemp = string.Format("[{0}] {1}", DateTime.Now, Killdata);
                        sw.WriteLine(stemp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(Pathbuilder.ToString()))
                    {
                        stemp = string.Format("[{0}] {1}", DateTime.Now, Killdata);
                        sw.WriteLine(stemp);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            AddListToLog(Killdata);
        }

        public void TimerLog(string Timerdata) //타이머 작동 로그 작성
        {
            string FilePath = Environment.CurrentDirectory + @"\Log\";
            string DirPath = Environment.CurrentDirectory + @"\Log\" + DateTime.Today.ToString("yyyy_MM");
            string temp;
            StringBuilder Pathbuilder = new StringBuilder();
            Pathbuilder.Append(FilePath).Append(DateTime.Today.ToString("yyyy_MM")).Append("\\").Append(DateTime.Today.ToString("yyyyMMdd")).Append("_Log_Timer").Append(".log");

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(Pathbuilder.ToString());

            try
            {
                if (!di.Exists) Directory.CreateDirectory(DirPath);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(Pathbuilder.ToString()))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, Timerdata);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(Pathbuilder.ToString()))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, Timerdata);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            AddListToLog(Timerdata);
        }

        public void UpdateLog(string UpdateData) //타이머 작동 로그 작성
        {
            string FilePath = Environment.CurrentDirectory + @"\Log\";
            string DirPath = Environment.CurrentDirectory + @"\Log\" + DateTime.Today.ToString("yyyy_MM");
            string temp;
            StringBuilder Pathbuilder = new StringBuilder();
            Pathbuilder.Append(FilePath).Append(DateTime.Today.ToString("yyyy_MM")).Append("\\").Append(DateTime.Today.ToString("yyyyMMdd")).Append("_Log_Update").Append(".log");

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(Pathbuilder.ToString());

            try
            {
                if (!di.Exists) Directory.CreateDirectory(DirPath);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(Pathbuilder.ToString()))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, UpdateData);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(Pathbuilder.ToString()))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, UpdateData);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            if (UpdateData == "Update")
            {
                AddListToLog(UpdateData);
            }
        }
        #endregion

        #region 타이머, 연계 함수 ex(tmrCount_Kill)
        void m_tmrCount_KR(object sender, EventArgs e) // 타이머 연계 함수
        {
            m_tmrCount_Kill();
            m_tmrCount_Run();
            

            if (!File.Exists(sKListPath)) //킬리스트 파일 존재하지 않음면
            {
                delRefreshList(1);
            }

            if (!File.Exists(sRListPath)) // 런리스트 파일 존재하지 않으면
            {
                delRefreshList(2);
            }
            if (nClosenum < 4)
            {
                nClosenum += 1;

            }
            if (nClosenum == 3) //6초지나면 알아서 종료
            {
                delRefreshList(3);

            }


        }
        void m_tmrCount_Kill() //지정된 시간 마다 함수 실행 
        {

            int nCnt = CIni.Load("PROCESS", "CNT", 0, sKListPath); //카운트 
            if (nCnt > 0)
            {
                for (int i = 0; i < nCnt; ++i) //카운트 수만큼 반복
                {
                    sProcessName = CIni.Load("PROCESS", (i + 1).ToString(), "", sKListPath); //프로세스명 출력
                    ProcessKill(sProcessName); //출력된 프로세스명 킬
                }
            }
        }

        private void ProcessKill(string sProcessName) //프로세스 잡는 함수
        {
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName(sProcessName);

            foreach (System.Diagnostics.Process p in process)
            {
                if (!string.IsNullOrEmpty(p.ProcessName))
                {
                    try
                    {
                        p.Kill();
                        //loglabel.Text += p.ProcessName + " Kill \n";
                        KillLogWrite(p.ProcessName + " Kill");
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("Process Kill Failed(" + sProcessName + "): " + e.Message);
                    }
                }
            }
        }

        public void RunProcessKill() //업데이트 시 런프로그램 종료
        {
            
            int nCnt = CIni.Load("PROCESS", "CNT", 0, sRListPath); //카운트 
            Console.WriteLine(nCnt);
            UpdateLog("Update");
            if (nCnt > 0)
            {
                for (int i = 0; i < nCnt; ++i) //카운트 수만큼 반복
                {

                    sProcessName = CIni.Load("PROCESS", (i + 1).ToString(), "", sRListPath);
                    Console.WriteLine(sProcessName);
                    
                    frmUpdateInUc.RcvFile(sProcessName);
                    PKbeforeUpdate(sProcessName); //출력된 프로세스명 킬
                }
            }

            PKUpdate();

        }
        private void PKbeforeUpdate(string sProcessName) //업데이트전 프로세스 킬
        {
            string shortname = sProcessName.Substring(sProcessName.LastIndexOf("\\") + 1);
            string foldername = sProcessName.Substring(0, (sProcessName.LastIndexOf("\\") + 1));
            int nCnt = CIni.Load("PROCESS", "CNT", 0, sRListPath);

            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName(shortname.Substring(0, shortname.LastIndexOf(".")));

            foreach (System.Diagnostics.Process p in process)
            {
                if (!string.IsNullOrEmpty(p.ProcessName))
                {
                    try
                    {
                        p.Kill();
                        //loglabel.Text += p.ProcessName + " Kill \n";
                        KillLogWrite(p.ProcessName + " Kill");
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("Process Kill Failed(" + sProcessName + "): " + e.Message);
                    }
                }
            }
        }

        private void PKUpdate() //업데이트폼 show
        {
            //int nCnt = CIni.Load("PROCESS", "CNT", 0, sRListPath); //카운트 
            if(nShowCnt == 0)
            {
                frmUpdateInUc.Show();
            }

            frmUpdateInUc.RcvSecond();

            //frmUpdateInUc.RcvnCnt(nCnt);
            //sendSecond();
        }

        void m_tmrCount_Run() //지정된 시간 마다 실행 함수 온 
        {

            int nCnt = CIni.Load("PROCESS", "CNT", 0, sRListPath); //카운트 

            if (nCnt > 0)
            {
                for (int i = 0; i < nCnt; ++i) //카운트 수만큼 반복
                {

                    sProcessName = CIni.Load("PROCESS", (i + 1).ToString(), "", sRListPath);

                    ProcessRun(sProcessName); //출력된 프로세스명 런
                        


                }
            }
        }

        private void ProcessRun(string rProcessName) //연계
        {
            string shortname = rProcessName.Substring(rProcessName.LastIndexOf("\\") + 1);
            string foldername = rProcessName.Substring(0, (rProcessName.LastIndexOf("\\") + 1));

            psi.WorkingDirectory = foldername;
            psi.FileName = rProcessName;

            Process_.StartInfo = psi;

            Process[] is_run = Process.GetProcessesByName(shortname.Substring(0, shortname.LastIndexOf(".")));

            IntPtr handle = IntPtr.Zero;

            FileInfo fi = new FileInfo(rProcessName);
            Console.WriteLine(rProcessName + "run");
            if (fi.Exists == true)
            {

                if (is_run.Length == 0)
                {
                    try
                    {

                        Process_.Start();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }

                    try
                    {
                        handle = Process_.Handle;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }

                    Debug.WriteLine("execption");
                    RunLogWrite(shortname.Substring(0, shortname.LastIndexOf(".")) + " Run");
                }
            }
        }

        public void AddListToLog(string name) //로그 리스트 확인 버튼
        {
            LogLv.Items.Add(DateTime.Now.ToString("[hh:mm:ss]") + " " + name); //[00:00:00] ~~ ; 
        }
        #endregion

        #region 타이머 제어 ex(중지와 시작)
        public void KillTitmerBtn_Click(object sender, EventArgs e) // 프로그램 중지 와 시작 버튼 클릭 이벤
        {
            KillTitmer();
            //if(KillTitmerBtn.Text == "프로그램 중지")
            //{
            //    m_tmrCount.Stop();
            //    KillTitmerBtn.Text = "프로그램 시작";
            //    fMan.StopStripMenu.Text = "시작";
            //    TimerLog("프로그램 중지");
            //}
            //else
            //{
            //    m_tmrCount.Start();
            //    KillTitmerBtn.Text = "프로그램 중지";
            //    fMan.StopStripMenu.Text = "중지";
            //    TimerLog("프로그램 시작");
            //}
        }
        public void KillTitmer() // 프로그램 중지 와 시작 버튼
        {

            if (KillTitmerBtn.Text == "프로그램 중지")
            {
                m_tmrCount.Stop();
                KillTitmerBtn.Text = "프로그램 시작";
                ucTimerMain();
                TimerLog("프로그램 중지");
                
            }
            else
            {
                m_tmrCount.Start();
                KillTitmerBtn.Text = "프로그램 중지";
                ucTimerMain();
                TimerLog("프로그램 시작");
            }
        }
        #endregion


        #region 리스트 추가, 삭제
        private void AddKillListBtn_Click(object sender, EventArgs e) //킬리스트 추가 버튼
        {
            try
            {
                frmlistInUc.FrmList_Load_Process();
                frmlistInUc.Show();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            

        }

        private void DelKillListBtn_Click(object sender, EventArgs e) // 킬 리스트 삭제 버튼
        {

            int sDataCount = 0;
            int sDataCountImport = 0;
            int nCnt = CIni.Load("PROCESS", "CNT", 0, sKListPath); //카운트 

            if (nCnt > 0)
            {

                int sProcess;
                string[] Processesb = new string[50]; //귀찮아서 50개 정해줌

                for (int a = 1; a <= nCnt; a++)
                {

                    sProcess = CIni.Load("PROCESS", "", a, sKListPath); //번호 출력 -> 비교
                    if (nKItemAllCount > 0) // 갯수가 0개 초과라면
                    {

                        if (nKSelectrow == sProcess)
                        {
                            nCnum = a;
                            sLogPro = CIni.Load("PROCESS", (nKSelectrow).ToString(), "", sKListPath);
                            CIni.Save("PROCESS", "CNT", (nCnt - 1).ToString(), sKListPath);
                            for (int i = a; i <= nCnt; i++)
                            {
                                if (i == nCnum)
                                {
                                    for (int z = nCnum; z <= nCnt; z++)
                                    {
                                        Processesb[sDataCount] = CIni.Load("PROCESS", (z).ToString(), "", sKListPath);
                                        CIni.Save("PROCESS", (z).ToString(), null, sKListPath);

                                        sDataCount++;

                                    }
                                    sDataCountImport++;
                                }
                                else
                                {

                                    CIni.Save("PROCESS", (i - 1).ToString(), Processesb[sDataCountImport], sKListPath);
                                    sDataCountImport++;
                                }

                            }
                        }




                    }
                    else
                    {
                        return;
                    }
                }
                RefreshList();
                KillLogWrite(sLogPro + " 삭제");
                nKItemAllCount = 0;
            }


        }

        private void AddRunListBtn_Click(object sender, EventArgs e) // 런 리스트 추가 버튼
        {
            string sNowdata = "";
            int nDnum = 0;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "파일 오픈 예제창";
            ofd.FileName = "test";
            ofd.Filter = "모든 파일 (*.*) | *.*";

            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                //파일
                string sFileName = ofd.SafeFileName;

                //File명을 모두 가지고 온다.
                string sFileFullName = ofd.FileName;

                //File경로만 가지고 온다.
                string sFilePath = sFileFullName.Replace(sFileName, "");

                string sPrcoessCheck = sFileName.Substring(sFileName.LastIndexOf(".") + 1);




                int nCnt = CIni.Load("PROCESS", "CNT", 0, sRListPath); //카운트 
                if (sPrcoessCheck != null) // 파일 존재 시 추가
                {
                    if (nCnt > 0)
                    {

                        int i = 0;
                        string sProcess = "";
                        for (int a = i; a < nCnt; ++a) //카운트 수만큼 반복
                        {
                            sNowdata = CIni.Load("PROCESS", (a + 1).ToString(), "", sRListPath);
                            i = a;
                            if (sFileName == sNowdata.Substring(sNowdata.LastIndexOf("\\") + 1)) //프로그램을 리스트에 중복 추가하는걸 방지
                            {
                                nDnum = 1;
                                continue;
                            }
                        }
                        if (nDnum == 0)
                        {
                            sLogPro = sFileName;
                            CIni.Save("PROCESS", "CNT", (i + 2).ToString(), sRListPath);
                            sProcess = CIni.Load("PROCESS", (i + 2).ToString(), "", sRListPath);
                            CIni.Save("PROCESS", (i + 2).ToString(), sFileFullName, sRListPath); //프로세스명 출력
                        }
                    }
                    else
                    {

                        string sProcess = "";
                        sLogPro = sFileName;
                        CIni.Save("PROCESS", "CNT", (1).ToString(), sRListPath);
                        sProcess = CIni.Load("PROCESS", (1).ToString(), "", sRListPath);
                        CIni.Save("PROCESS", (1).ToString(), sFileFullName, sRListPath); //프로세스명 출력

                    }
                }
                if (sLogPro != "")
                {
                    RefreshList();
                    RunLogWrite(sLogPro + " 추가");
                }

            }
            //취소버튼 클릭시 또는 ESC키로 파일창을 종료 했을경우
            else if (dr == DialogResult.Cancel)
            {
            }
        }

        private void DelRunListBtn_Click(object sender, EventArgs e) // 런 리스트 삭제 버튼 클릭 이벤(완)
        {
            int sProcessNum;

            int cnum;
            int dataCount = 0;
            int dataCountImport = 0;

            int nCnt = CIni.Load("PROCESS", "CNT", 0, sRListPath); //카운트 

            if (nCnt > 0) // 낮은 순번 삭제 시 높은 순번을 삭제하고 다시 정의해야한다.
            {



                string[] Processesb = new string[50];
                if (nRItemAllCount > 0)
                {
                    for (int a = 1; a <= nCnt; a++)
                    {
                        sProcessNum = CIni.Load("PROCESS", "", a, sRListPath); //프로세스번호 출력
                        if (nRSelectrow == sProcessNum)
                        {
                            cnum = a;
                            sLogPro = CIni.Load("PROCESS", (nRSelectrow).ToString(), "", sRListPath);
                            CIni.Save("PROCESS", "CNT", (nCnt - 1).ToString(), sRListPath);
                            for (int i = a; i <= nCnt; i++)
                            {
                                if (i == cnum)
                                {
                                    for (int z = cnum; z <= nCnt; z++)
                                    {
                                        Processesb[dataCount] = CIni.Load("PROCESS", (z).ToString(), "", sRListPath);
                                        CIni.Save("PROCESS", (z).ToString(), null, sRListPath);
                                        dataCount++;
                                    }
                                    dataCountImport++;
                                }
                                else
                                {

                                    CIni.Save("PROCESS", (i - 1).ToString(), Processesb[dataCountImport], sRListPath);
                                    dataCountImport++;
                                }

                            }
                        }

                    }

                }
                else
                {
                    return;
                }
                nRItemAllCount = 0;
                RefreshList();
                RunLogWrite(sLogPro.Substring(sLogPro.LastIndexOf("\\") + 1) + " 삭제");
            }
        }
        #endregion

        #region 리시브 데이터
        public void rcDataK(int rcount) //킬리스트뷰에서 서브아이템 클릭시 리시브
        {
            nKSelectrow = rcount + 1;
        }
        public void rcDataR(int rcount)//런리스트뷰에서 서브아이템 클릭시 리시브
        {
            nRSelectrow = rcount + 1;
        }
        public void rcDataKC(int count) //킬, 런 리스트뷰의 서브아이템 개수 끌어옴
        {
            nKItemAllCount = count;
        }
        public void rcDataRC(int count) //킬, 런 리스트뷰의 서브아이템 개수 끌어옴
        {
            nRItemAllCount = count;
        }
        #endregion
    }
}
