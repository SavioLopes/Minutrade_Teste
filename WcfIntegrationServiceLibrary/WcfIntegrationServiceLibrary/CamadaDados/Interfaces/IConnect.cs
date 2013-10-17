using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados.Interfaces
{
    public interface IConnect
    {
        bool conectar();
        bool desconectar();
        DataTable retornarTabela(string p_strSql, List<SqlParameter> p_obParams,
        string p_strNmTabelaRetorno);
        bool executarComando(string p_strSql, List<SqlParameter> p_obParams);
    }
}