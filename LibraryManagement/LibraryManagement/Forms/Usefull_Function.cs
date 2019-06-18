using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Forms
{
    public class Usefull_Function
    {
        public static bool Find(string strSearch, ref DataGridView _Datagridview, List<int> _listColumnFind = null)
        {
            bool bResult = false;
            strSearch = strSearch.ToUpper();
            List<int> lAllowList = new List<int>();
            for (int j = 0; j < _Datagridview.Columns.Count; ++j)
            {
                // nếu _listColumn khác tập rỗng và không chứa cột đang xét -> bỏ qua
                if (_listColumnFind != null && !_listColumnFind.Exists(m => m == j))
                {
                    continue;
                }
                int i = 0;
                // tìm trong tất cả các dòng
                for (i = _Datagridview.Rows.Count - 1; i >= 0; --i)
                {
                    if (!lAllowList.Exists(x => x == i))
                    {
                        if (_Datagridview.Rows[i].Cells[j].Value != null )
                        {
                            string strA = _Datagridview.Rows[i].Cells[j].Value.ToString();
                            strA = strA.ToUpper();

                            if (string.Equals(strSearch, strA) | strA.IndexOf(strSearch, 0) >= 0)
                            {
                                bResult = true;
                                lAllowList.Add(i);
                            }
                        }
                        else
                            bResult = false;
                    }
                }
            }
            lAllowList.Sort((x, y) => x.CompareTo(y.CompareTo(y)));
            for (int i = _Datagridview.Rows.Count - 1; i >= 0 ; i--)
            {
                try
                {
                    if (!lAllowList.Exists(m => m == i))
                        _Datagridview.Rows.RemoveAt(i);
                }
                catch
                {
                    continue;
                }
            }
            _Datagridview.Refresh();

            return bResult;
        }
    }
}
