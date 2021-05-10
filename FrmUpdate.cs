using PRM.UC;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PRM
{

    public delegate void upTimerEvent();
    public delegate void UpdateClickEvent();
    public delegate void UpdateLogEvent(string UpDateD);

    public partial class FrmUpdate : Form
    {
        //FrMain frmMainInUc;
        //FrMain frMain;
        public upTimerEvent upTimer;
        public UpdateClickEvent updateClick;
        public UpdateLogEvent updateLog;

        ucCon ucConInUp; //ucCon

        string FileName = ""; //파일명
        string FileFullName = ""; //파일폴더 + 명
        string sOriginalFile = ""; //파일명 + 확장자
        string sOriginalPath = ""; //파일폴더 + 명
        string sOriginalNewName = ""; // 파일명만
        string sOriginalNewType = ""; // 확장자만
        string sUpdatePath = ""; //루트
        string sNowDir = System.Environment.CurrentDirectory + "\\update\\"; //업데이트 폴더
        private Timer m_tmrCount;
        //int nDelCnt = 0;


        public FrmUpdate()
        {
            InitializeComponent();
            m_tmrCount = new Timer();
            m_tmrCount.Interval = 500;
            m_tmrCount.Tick += new EventHandler(setUpdatelist); //이벤트 실행
        }

        public void RcvSecond() //폼 열리면 타이머 시작
        {

            m_tmrCount.Start();

        }

        public void RcvFile(string sPath) //실행 파일명 업데이트 연계
        {
            sOriginalPath = sPath;
            sOriginalFile = sPath.Substring(sPath.LastIndexOf("\\") + 1);
            sOriginalNewName = sOriginalFile.Substring(0, sOriginalFile.LastIndexOf("."));
            sOriginalNewType = sOriginalFile.Substring(sOriginalFile.LastIndexOf(".") + 1);

            //Console.WriteLine("oF : " + sOriginalNewName + "oT : " + sOriginalNewType);
            
            Update();
        }

        private new void Update() // 디렉토리 생성, 열기 or 파일 카피 (백업 파일 생성)
        {
            DirectoryInfo di = new DirectoryInfo(sNowDir);
            if(di.Exists == false)
            {
                di.Create();
            }
            Process.Start(di.ToString());
            foreach (var item in di.GetFiles())
            {
                if (item.Name == sOriginalFile)
                {


                    FileName = item.FullName.Substring(item.FullName.LastIndexOf("\\") + 1);
                    FileFullName = item.FullName;
                    string pathString = sOriginalPath.Substring(0, sOriginalPath.LastIndexOf("\\")) + "\\";
                    string pathSeString = pathString;


                    pathString = System.IO.Path.Combine(pathString, FileName);




                    //있는 파일에 카피
                        string sNewFile = pathSeString + sOriginalNewName + DateTime.Today.ToString("_MMdd.") + sOriginalNewType;
                    string sNewThirFile = pathSeString + sOriginalNewName + DateTime.Today.ToString("_MMdd_hhmm.") + sOriginalNewType;
                    FileInfo fi = new FileInfo(sNewFile);
                        FileInfo Fisec = new FileInfo(sOriginalPath);
                    FileInfo FiThir = new FileInfo(sNewThirFile);


                    //Process[] processes = Process.GetProcesses(); // 모든 프로세스 추출
                    //foreach (Process process in processes)
                    //{ // foreach 루프 수행
                    //    if(process.ProcessName == sOriginalNewName)
                    //    {
                    //        process.Kill();
                    //    }
                    //}
                    try
                    {


                        if (Fisec.Exists == true)
                        {
                            if (fi.Exists == true)
                            {
                                fi.Delete();
                            }

                            File.Copy(sOriginalPath, sNewFile);
                            File.Delete(sOriginalPath);
                            File.Copy(item.FullName, sOriginalPath);  


                        }
                        else
                        {
                            File.Copy(item.FullName, sOriginalPath);  
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine(ex);
                        MessageBox.Show(sOriginalNewName + "프로세스 실행중이므로 종료합니다. 다시 업데이트 버튼을 눌러주세요");
                        System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName(sOriginalNewName);

                        foreach (System.Diagnostics.Process p in process)
                        {
                            if (!string.IsNullOrEmpty(p.ProcessName))
                            {
                                try
                                {
                                    p.Kill();
                                }
                                catch (Exception e)
                                {
                                    System.Diagnostics.Debug.WriteLine("Process Kill Failed(" + sOriginalNewName + "): " + e.Message);
                                }
                            }
                        }

                    }

                    //File.Copy(item.FullName, sOriginalPath);  //여기가 err부분
                    


                    
                }
            }
            //setOriginallist();
            setOriginallist();
            txtState.Text = "업데이트 완료";
        }

        private void setOriginallist() //왼쪽 칸에 업데이트 된 파일 로그 생성
        {
            Console.WriteLine(FileFullName);
            if (sOriginalFile == FileName)
            {
                    lsbOriginal.Items.Add(DateTime.Today.ToString("[MM.dd hh:mm]") + sOriginalPath.Substring(0, sOriginalPath.LastIndexOf("\\")) + "\\");
                lsbOriginal.Items.Add(sOriginalFile + "완료");
                updateLog(sOriginalPath.ToString() + " Update");
            }
            //DataTable dt = new DataTable();
            //dt.Columns.Add("FileName", typeof(string));
            //dt.Columns.Add("FullName", typeof(string));
            //DataRow ds = null;
            //    ds = dt.NewRow();
            //    ds["FileName"] = sOriginalPath.Substring(0, sOriginalPath.Length);
            //    //Console.WriteLine(ds["FullName"].ToString().Substring(ds["FullName"].ToString().LastIndexOf(".") + 1) + "123");
            //if (ds["FileName"].ToString().Substring(ds["FName"].ToString().LastIndexOf(".") + 1) == "exe")
            //{
            //    dt.Rows.Add(ds);
            //}
            //lsbOriginal.DataSource = dt;
            //lsbOriginal.ValueMember = "FullName";
            //lsbOriginal.DisplayMember = "FileName";

            //Console.WriteLine(sOriginalPath);
            //txtPaths.Text = sOriginalPath;
            //this.lsbOriginal.Refresh();
            //DirectoryInfo di = new DirectoryInfo(sOriginalPath);
            //if (di.Exists == true)
            //{
            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("FileName", typeof(string));
            //    dt.Columns.Add("FullName", typeof(string));
            //    DataRow ds = null;
            //    foreach (FileInfo file in di.GetFiles())
            //    {
            //        ds = dt.NewRow();
            //        ds["FileName"] = file.Name.Substring(0, file.Name.Length);
            //        ds["FullName"] = file.FullName;
            //        Console.WriteLine(ds["FullName"].ToString().Substring(ds["FullName"].ToString().LastIndexOf(".") + 1) + "123");
            //        if (ds["FullName"].ToString().Substring(ds["FullName"].ToString().LastIndexOf(".") + 1) == "exe")
            //        {
            //            dt.Rows.Add(ds);
            //        }

            //    }
            //        lsbOriginal.DataSource = dt;
            //        lsbOriginal.ValueMember = "FullName";
            //        lsbOriginal.DisplayMember = "FileName";
            //}


        }
        public void setUpdatelist(object sender, EventArgs e) //오른쪽 칸 업데이트 폴더 내 파일 보여줌
        {
            //"D:\\DH\\Update";
            sUpdatePath = System.Environment.CurrentDirectory + "\\Update\\";
            this.lsbUpdate.Refresh();
            DirectoryInfo di = new DirectoryInfo(sUpdatePath);
            if (di.Exists != true)
            {
                di.Create();
            }
                DataTable dt = new DataTable();
                dt.Columns.Add("FileName", typeof(string));
                dt.Columns.Add("FullName", typeof(string));
                DataRow ds = null;

                foreach (FileInfo file in di.GetFiles())
                {

                if (dt.Rows.ToString() != file.Name.Substring(0, file.Name.Length))
                {
                    ds = dt.NewRow();
                    ds["FileName"] = file.Name.Substring(0, file.Name.Length);
                    ds["FullName"] = file.FullName;
                    dt.Rows.Add(ds);
                    
                    //Console.WriteLine(dt.Rows.ToString() + "123" + file.Name.Substring(file.Name.LastIndexOf(".") + 1));

                }
                }
                lsbUpdate.DataSource = dt;
                lsbUpdate.ValueMember = "FullName";
            lsbUpdate.DisplayMember = "FileName";
        }

        
        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            ucConInUp = new ucCon();

            //frmMainInUc = new FrMain();
            ////frmMainInUc.Update = this.RunProcessKill;
            //frmMainInUc.PrmIcon.Visible = false; //아이콘 중복 비활성
            
            ucConInUp.sendPath = new SendPathEvent(this.RcvFile);
            ucConInUp.sendSecond = new SendSecondEvent(this.RcvSecond);
        }


        private void btnCloseU_Click(object sender, EventArgs e)
        {
            
            Hide();

            upTimer();

            m_tmrCount.Stop();
        }

        private void FrmUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_tmrCount.Stop();
        }
        //public void UpdateClick()
        //{
        //    btnUpdate.PerformClick();
        //}

        public void btnUpdate_Click(object sender, EventArgs e) // 업데이트 클릭
        {
            m_tmrCount.Stop();
            updateClick();
            
        }

        private void btnOpenPath_Click(object sender, EventArgs e) //폴더열기
        {
            Process.Start(sNowDir);
        } 
    }
}
