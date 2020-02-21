using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using K12.Data.Configuration;
using System.Xml.Linq;
using FISCA.Data;
using K12.Data;
using FISCA.LogAgent;

namespace KCBS.HT.RollCall
{
    public partial class frmRollCallConfig : BaseForm
    {
        private string _configName = "班導師點名設定";
        private string _initContent = "";
        private QueryHelper _qh = new QueryHelper();
        private UpdateHelper _up = new UpdateHelper();
        private string _defaultPeriodListString = "";
        private StringBuilder _sbLogBefore = new StringBuilder();
        private StringBuilder _snLogBefore = new StringBuilder();
        private StringBuilder _sbLogAfter = new StringBuilder();
        private StringBuilder _snLogAfter = new StringBuilder();
        private List<XElement> listAbsenceBf = new List<XElement>();
        public frmRollCallConfig()
        {
            InitializeComponent();
        }

        private void frmRollCallConfig_Load(object sender, EventArgs e)
        {
            #region 取得假別對照表
            List<XElement> listAbsence = new List<XElement>();
            {
                //ConfigData cdType = K12.Data.School.Configuration["假別對照表"];
                //XDocument docType = XDocument.Parse(cdType.PreviousData.OuterXml);
                //List<XElement> listAbsence = docType.Element("AbsenceList").Elements("Absence").ToList();
                string sql = "SELECT * FROM list WHERE name = '假別對照表'";
                DataTable dt = this._qh.Select(sql);
                XDocument doc = XDocument.Parse("" + dt.Rows[0]["content"]);
                listAbsence = doc.Element("AbsenceList").Elements("Absence").ToList();
                listAbsenceBf = listAbsence;
            }
            #endregion

            #region 取得節次對照表
            List<XElement> sessionList = new List<XElement>();
            {
                string findSessionSql = @"
SELECT 
    *
FROM 
    list
WHERE
    name = '節次對照表'";
                DataTable dt = this._qh.Select(findSessionSql);
                XDocument xdoc = XDocument.Parse("" + dt.Rows[0]["content"]);
                sessionList = xdoc.Element("Periods").Elements("Period").ToList();
            }
            #endregion

            #region 初始化班導師點名設定
            {
                List<string> listSetting = new List<string>();
                foreach (XElement absence in listAbsence)
                {
                    string data = string.Format(@"<Absence Name=""{0}"">false</Absence>", absence.Attribute("Name").Value);
                    listSetting.Add(data);
                }

                this._initContent = string.Format(@"<AbsenceList CrossDate = ""false"">{0}</AbsenceList>", string.Join("", listSetting));

                listSetting = new List<string>();
                foreach (XElement session in sessionList)
                {
                    string data = string.Format(@"<Period Name=""{0}"" >一般</Period>", session.Attribute("Name").Value);
                    listSetting.Add(data);
                }
                this._initContent += string.Format(@"<PeriodList>{0}</PeriodList>", string.Join("", listSetting));
            }
            #endregion

            #region 取得班導師可點假別設定
            Dictionary<string, bool> dicSetting = new Dictionary<string, bool>();
            bool crossDate;
            {
                XDocument docRollCall = new XDocument();
                DataTable dt = GetConfig();
                if (dt.Rows.Count > 0)
                {
                    //2019/4/3 俊緯更新 為符合新的content的格式，所以手動加上<root>
                    docRollCall = XDocument.Parse("<root>" + dt.Rows[0]["content"] + "</root>");
                }
                else
                {
                    dt = insertConfig();
                    docRollCall = XDocument.Parse("<root>" + dt.Rows[0]["content"] + "</root>");
                }
                crossDate = bool.Parse(docRollCall.Element("root").Element("AbsenceList").Attribute("CrossDate").Value);
                List<XElement> listSetting = docRollCall.Element("root").Element("AbsenceList").Elements("Absence").ToList();
                foreach (XElement data in listSetting)
                {
                    dicSetting.Add(data.Attribute("Name").Value, bool.Parse(data.Value));
                }
            }
            #endregion

            #region 取得班導師節次設定
            Dictionary<string, string> sessionSetDic = new Dictionary<string, string>();
            {
                XDocument sessionDoc = new XDocument();
                DataTable dt = GetConfig();
                if (dt.Rows.Count > 0)
                {
                    sessionDoc = XDocument.Parse("<root>" + dt.Rows[0]["content"] + "</root>");
                    //當班導師點名設定 沒有periodList 的Element 的時候 要將 default periodList 設定加進去
                    if (sessionDoc.Element("root").Element("PeriodList") == null)
                    {
                        List<string> listSetting = new List<string>();
                        foreach (XElement session in sessionList)
                        {
                            string data = string.Format(@"<Period Name=""{0}"" >一般</Period>", session.Attribute("Name").Value);
                            listSetting.Add(data);
                        }
                        this._defaultPeriodListString = string.Format(@"<PeriodList>{0}</PeriodList>", string.Join("", listSetting));
                        sessionDoc = XDocument.Parse("<root>" + dt.Rows[0]["content"]+this._defaultPeriodListString + "</root>");
                    }
                }
                else
                {
                    dt = insertConfig();
                    sessionDoc = XDocument.Parse("<root>" + dt.Rows[0]["content"] + "</root>");
                }
                
                List<XElement> settingList = sessionDoc.Element("root").Element("PeriodList").Elements("Period").ToList();
                foreach (XElement xElement in settingList)
                {
                    sessionSetDic.Add("" + xElement.Attribute("Name").Value, "" + xElement.Value);
                }
               
            }
            #endregion

            // Init CheckBox
            ckbxCrossDate.Checked = crossDate;

            #region 填資料進dataGridView
            // Init DataGridView
            // Absence
            foreach (XElement absence in listAbsence)
            {
                DataGridViewRow dgvrow = new DataGridViewRow();
                dgvrow.CreateCells(dgvSetLeaveCategory);

                int col = 0;
                dgvrow.Cells[col++].Value = absence.Attribute("Name").Value;
                dgvrow.Cells[col++].Value = dicSetting.ContainsKey(absence.Attribute("Name").Value) ? dicSetting[absence.Attribute("Name").Value] : false;

                dgvSetLeaveCategory.Rows.Add(dgvrow);
                
                _sbLogBefore.Append("缺曠類別「" + absence.Attribute("Name").Value + "」，" + "導師是否可以點名「");
                if (dicSetting.ContainsKey(absence.Attribute("Name").Value))
                {
                    _sbLogBefore.Append(dicSetting[absence.Attribute("Name").Value] ? "是" : "否" );
                }
                else
                {
                    _sbLogBefore.Append("否");
                }
                _sbLogBefore.AppendLine("」。");  //導師原本能點的缺曠類別

            
            }
            // Session
            List<string> sessionSetCategoryList = new List<string>()
            {
                 "一般"
                ,"手動"
                ,"唯讀"
                ,"隱藏"
            };
            foreach (XElement session in sessionList)
            {
                DataGridViewRow dgvRow = new DataGridViewRow();
                dgvRow.CreateCells(dgvSetSession);

                int col = 0;
                dgvRow.Cells[col++].Value = session.Attribute("Name").Value;
                string sessionSetCategory = sessionSetDic.ContainsKey(session.Attribute("Name").Value) ? sessionSetDic[session.Attribute("Name").Value] : "";
                foreach (string category in sessionSetCategoryList)
                {
                    ((DataGridViewComboBoxCell)dgvRow.Cells[col]).Items.Add(category);
                }

                ((DataGridViewComboBoxCell)dgvRow.Cells[col]).Style.NullValue = sessionSetCategory;

                dgvSetSession.Rows.Add(dgvRow);

                _snLogBefore.AppendLine("原先導師第「" + session.Attribute("Name").Value + "」幾節可點狀態「" + sessionSetDic[session.Attribute("Name").Value] + "」。");
  //導師原本能點的缺曠類別

            }
            #endregion



        }



        private DataTable GetConfig()
        {
            string sql = string.Format(@"
SELECT
    *
FROM
    list
WHERE
    name = '{0}'
            ", this._configName);

            return this._qh.Select(sql);
        }

        private DataTable insertConfig()
        {
            string sql = string.Format(@"
WITH insert_data AS(
    INSERT INTO list(
        name
        , content
    )
    VALUES(
        '{0}'
        , '{1}'
    )
    RETURNING *
)
SELECT * FROM insert_data
            ", this._configName, this._initContent);

            return this._qh.Select(sql);
        }




        private void btnSave_Click (object sender, EventArgs e) 
        {
            List<string> absenceListDataRow = new List<string>();
            List<string> sessionListDataRow = new List<string>();

            foreach (DataGridViewRow dgvrow in dgvSetLeaveCategory.Rows)
            {
                string data = string.Format(@"<Absence Name=""{0}"">{1}</Absence>", dgvrow.Cells[0].Value, dgvrow.Cells[1].Value);

                absenceListDataRow.Add(data);


                _sbLogAfter.Append("缺曠類別「" + dgvrow.Cells[0].Value + "」，" + "導師是否可以點名「");

                if ((bool)dgvrow.Cells[1].Value)
                {
                    _sbLogAfter.Append((bool)dgvrow.Cells[1].Value ? "是" : "否");
                }
                else
                {
                    _sbLogAfter.Append("否");
                };
                _sbLogAfter.AppendLine("」。");

            }

            foreach (DataGridViewRow dgvRow in dgvSetSession.Rows)
            {
                string data = string.Format(@"<Period Name=""{0}"">{1}</Period>", dgvRow.Cells[0].Value, dgvRow.Cells[1].FormattedValue);
                sessionListDataRow.Add(data);

                _snLogAfter.AppendLine("導師第「" + dgvRow.Cells[0].Value + "」幾節可點狀態「" + dgvRow.Cells[1].FormattedValue + "」。");
            }



                string content = string.Format(@"<AbsenceList CrossDate = ""{0}"">{1}</AbsenceList>", ckbxCrossDate.Checked, string.Join("", absenceListDataRow));
            content += string.Format(@"<PeriodList>{0}</PeriodList>", string.Join("", sessionListDataRow));

            string sql = string.Format(@"
                                        UPDATE list SET
                                            content = '{0}'
                                        WHERE
                                            name = '{1}'
            ", content, this._configName);

            


            try
            {
                this._up.Execute(sql);
                ApplicationLog.Log("導師課堂點名", "修改", "缺曠類別: \n"+_sbLogBefore.ToString()+"\n" 
                    + "節數: \n"+ _snLogBefore.ToString() + "========================== \n"+ "調整後缺曠類別: \n"+ _sbLogAfter.ToString() + "\n" + "調整後節數: \n" + _snLogAfter.ToString());


                MsgBox.Show("資料儲存成功!");
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
