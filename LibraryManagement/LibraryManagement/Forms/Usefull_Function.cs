using System;
using System.Collections.Generic;
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
            for (int j = 0; j < _Datagridview.ColumnCount; ++j)
            {
                // nếu _listColumn khác tập rỗng và không chứa cột đang xét -> bỏ qua
                if (_listColumnFind != null && !_listColumnFind.Exists(m => m == j))
                {
                    continue;
                }
                // tìm trong tất cả các dòng
                for (int i = 0; i < _Datagridview.RowCount; ++i)
                {
                    try
                    {
                        if (_Datagridview.Rows[i].Cells[j].Value.ToString() == strSearch)
                        {
                            _Datagridview.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            bResult = true;
                        }
                    }
                    catch
                    {
                        continue;
                    }

                }
            }
            return bResult;
        }
    }
}
