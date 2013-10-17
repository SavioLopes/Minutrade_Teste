using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados.Interfaces;

namespace CamadaDados
{
    public class ConnectionManager : IConnect
    {
        private string strConnStr = @"Data Source=EGONTECH-06\TESTE;Initial Catalog=Savio;Integrated Security=True;Pooling=False";
        SqlConnection objConn = null;
        public bool conectar()
        {
            objConn = new SqlConnection(strConnStr);
            try
            {
                objConn.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool desconectar()
        {
            try
            {
                if (objConn.State != ConnectionState.Closed)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public DataTable retornarTabela(string p_strSql, List<SqlParameter>
        p_obParams, string p_strNmTabelaRetorno)
        {
            if (!this.conectar())
            {
                return null;
            }
            SqlCommand objCmd = new SqlCommand(p_strSql, objConn);
            foreach (SqlParameter param in p_obParams)
            {
                objCmd.Parameters.Add(param);
            }
            SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);
            DataSet ds = new DataSet();
            try
            {
                objAdp.Fill(ds, p_strNmTabelaRetorno);
            }
            catch
            {
                return null;
            }
            this.desconectar();
            return ds.Tables[p_strNmTabelaRetorno];
        }
        public bool executarComando(string p_strSql, List<SqlParameter> p_obParams)
        {
            bool blnResult = false;
            if (!this.conectar())
            {
                return false;
            }
            SqlCommand objCmd = new SqlCommand(p_strSql, objConn);
            foreach (SqlParameter param in p_obParams)
            {
                objCmd.Parameters.Add(param);
            }
            try
            {
                blnResult = (objCmd.ExecuteNonQuery() > 0 ? true : false);
            }
            catch (Exception)
            {
                blnResult = false;
            }
            this.desconectar();
            return blnResult;
        }
    }
}