using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA;
using FISCA.Presentation;
using FISCA.Permission;

namespace KCBS.HT.RollCall
{
    public class Program
    {
        [MainMethod("康橋班導師點名模組")]
        public static void Main()
        {
            #region 導師點名設定
            {
                MotherForm.RibbonBarItems["學務作業", "基本設定"]["設定"]["導師點名設定"].Enable = Permissions.導師點名設定權限;
                MotherForm.RibbonBarItems["學務作業", "基本設定"]["設定"]["導師點名設定"].Click += delegate
                {
                    (new frmRollCallConfig()).ShowDialog();
                };

            }
            #endregion

            #region 權限管理
            {
                Catalog detail = new Catalog();
                detail = RoleAclSource.Instance["學務作業"]["功能按鈕"];
                detail.Add(new RibbonFeature(Permissions.導師點名設定, "導師點名設定"));
            }
            #endregion
        }
    }
}
