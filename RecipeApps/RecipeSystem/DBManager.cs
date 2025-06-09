using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUFramework;

namespace RecipeSystem
{
    public class DBManager
    {
        public static void SetConnectionString(string connectionstring)
        {
            SQLUtility.connectionstring = connectionstring;
        }
    }
}
