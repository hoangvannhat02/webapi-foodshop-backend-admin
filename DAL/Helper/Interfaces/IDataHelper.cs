using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper.Interfaces
{
    public interface IDataHelper
    {
        void OpenConnection();
        void CloseConnection();
        void ExecuteProcedure(string nameprocedure, params object[] param);
        DataTable ExcuteProcedureReturnDatatable(string nameprocedure, params object[] param);
    }
}
