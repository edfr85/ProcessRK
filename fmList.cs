using processKR;
using PRM.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRM
{
    #region delegate 선언
    public delegate void AddKillProcessOkEvent(string data);
    #endregion

    public partial class fmList : Form
    {
        #region 선언부
        public AddKillProcessOkEvent DataSendE;
        ucCon ucList;
        FrMain frmMainInList;
        string slogPro = "";
        string sProcessName = "";
        string sListPath = Environment.CurrentDirectory + @"\KList.ini";
        #endregion

        public fmList()
        {
           
            InitializeComponent();
        }

        #region 폼로딩
        private void FrmList_Load(object sender, EventArgs e)
        {
            ucList = new ucCon();
            frmMainInList = new FrMain();

            frmMainInList.PrmIcon.Visible = false; //아이콘 중복 비활성
            frmMainInList.Close(); //중복 실행 방지


            FrmList_Load_Process();
        }

        public void FrmList_Load_Process()
        {

                AddKListChBox.Items.Clear();

                Process[] processes = Process.GetProcesses(); // 모든 프로세스 추출

                foreach (Process process in processes)
                { // foreach 루프 수행
                    AddKListChBox.Items.Add(process.ProcessName + "\n");
                }
        }
        #endregion

        

        #region 버튼 클릭
        private void AddKBtn_Click(object sender, EventArgs e) // 추가버튼 클릭
        {
            

            int nCnt = CIni.Load("PROCESS", "CNT", 0, sListPath); //카운트

            if (nCnt > 0)
            {

                int nColnum = nCnt;
                foreach (string obj in AddKListChBox.CheckedItems)
                {
                    int nCount = 1;


                    for (int i = 1; i <= nCnt; i++)
                    {
                        sProcessName = CIni.Load("PROCESS", (i).ToString(), "", sListPath);
                        try
                        {
                            if (sProcessName == obj.Substring(0, obj.LastIndexOf("")))
                            {
                                nCount = 2;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }

                    }
                    if (nCount == 1)
                    {
                        CIni.Save("PROCESS", "CNT", (nColnum + 1).ToString(), sListPath);


                        CIni.Save("PROCESS", (nColnum + 1).ToString(), obj.ToString(), sListPath);
                        slogPro = CIni.Load("PROCESS", (nColnum + 1).ToString(), "", sListPath);
                        try
                        {
                            if (slogPro != "")
                            {

                                DataSendE(slogPro + " 추가");

                            }
                            else DataSendE("");

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }
                        nColnum++;
                    }


                }
            }
            else
            {

                int nCount = 1;
                foreach (string obj in AddKListChBox.CheckedItems)
                {
                    CIni.Save("PROCESS", "CNT", (nCount).ToString(), sListPath);
                    sProcessName = CIni.Load("PROCESS", (nCount).ToString(), "", sListPath);

                    CIni.Save("PROCESS", (nCount).ToString(), obj.ToString(), sListPath);
                    slogPro = CIni.Load("PROCESS", (nCount).ToString(), "", sListPath);

                    try
                    {
                        if (slogPro != "")
                        {

                            DataSendE(slogPro + " 추가");

                        }
                        else DataSendE("");

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                    nCount++;
                }

            }
            for(int i = 1; i < AddKListChBox.Items.Count; i++)
            {
                AddKListChBox.SetItemChecked(i, false);
            }    
                Hide();
        }

        private void CancelKBtn_Click(object sender, EventArgs e) //취소 버튼 클릭
        {
            Hide();
        }
        #endregion
    }
}
