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

namespace KCBS.HT.RollCall
{
    public partial class frmRollCallConfig : BaseForm
    {
        private string _configName = "班導師點名設定";
        private string _initContent = "";
        private QueryHelper _qh = new QueryHelper();
        private UpdateHelper _up = new UpdateHelper();

        public frmRollCallConfig()
        {
            InitializeComponent();
        }

        private void frmRollCallConfig_Load(object sender, EventArgs e)
        {
            // 1. 取得假別對照表
            ConfigData cdType = K12.Data.School.Configuration["假別對照表"];
            XDocument docType = XDocument.Parse(cdType.PreviousData.OuterXml);
            List<XElement> listAbsence = docType.Element("AbsenceList").Elements("Absence").ToList();

            #region 初始化班導師點名設定
            {
                List<string> listSetting = new List<string>();
                foreach (XElement absence in listAbsence)
                {
                    string data = string.Format(@"<Absence Name=""{0}"">true</Absence>", absence.Attribute("Name").Value);
                    listSetting.Add(data);
                }

                this._initContent = string.Format(@"<AbsenceList CrossDate = ""true"">{0}</AbsenceList>", string.Join("", listSetting));
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
                    docRollCall = XDocument.Parse("" + dt.Rows[0]["content"]);
                }
                else
                {
                    dt = insertConfig();
                    docRollCall = XDocument.Parse("" + dt.Rows[0]["content"]);
                }
                crossDate = bool.Parse(docRollCall.Element("AbsenceList").Attribute("CrossDate").Value);
                List<XElement> listSetting = docRollCall.Element("AbsenceList").Elements("Absence").ToList();
                foreach (XElement data in listSetting)
                {
                    dicSetting.Add(data.Attribute("Name").Value, bool.Parse(data.Value));
                }
            } 
            #endregion

            // Init ComboBox
            ckbxCrossDate.Checked = crossDate;

            // Init DataGridView
            foreach (XElement absence in listAbsence)
            {
                DataGridViewRow dgvrow = new DataGridViewRow();
                dgvrow.CreateCells(dataGridViewX1);

                int col = 0;
                dgvrow.Cells[col++].Value = absence.Attribute("Name").Value;
                dgvrow.Cells[col++].Value = dicSetting[absence.Attribute("Name").Value];

                dataGridViewX1.Rows.Add(dgvrow);
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> listDataRow = new List<string>();

            foreach (DataGridViewRow dgvrow in dataGridViewX1.Rows)
            {
                string data = string.Format(@"<Absence Name=""{0}"">{1}</Absence>", dgvrow.Cells[0].Value,dgvrow.Cells[1].Value);
                listDataRow.Add(data);
            }

            string content = string.Format(@"<AbsenceList CrossDate = ""{0}"">{1}</AbsenceList>",ckbxCrossDate.Checked,string.Join("",listDataRow));

            string sql = string.Format(@"
UPDATE list SET
    content = '{0}'
WHERE
    name = '{1}'
            ",content,this._configName);

            try
            {
                this._up.Execute(sql);
                MsgBox.Show("資料儲存成功!");
            }
            catch(Exception ex)
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
