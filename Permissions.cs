using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCBS.HT.RollCall
{
    class Permissions
    {
        public static string 導師點名設定 { get { return "4B8472C6-F30D-463C-95EF-6E3DB24EFAE9"; } }
        public static bool 導師點名設定權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[導師點名設定].Executable;
            }
        }
    }
}
