using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using WcfIntegrationServiceLibrary;
namespace CamadaDados
{
    public class DBTbCliente
    {
        private ConnectionManager objConnManager = new ConnectionManager();

        public bool incluir(Cliente p_objCliente)
        {
            bool blnRetorno = false;
            string strSql = "INSERT INTO TbCliente (nome, telefoneResidencial, endereco, dataNascimento, numeroCelular) " +
                            " VALUES (@pNome, @pTelefoneResidencial, @pEndereco, @pDataNascimento, @pNumeroCelular)";

            List<SqlParameter> objParams = new List<SqlParameter>();
            objParams.Add(new SqlParameter("@pNome", p_objCliente.Nome));
            objParams.Add(new SqlParameter("@pTelefoneResidencial", p_objCliente.TelefoneResidencial));
            objParams.Add(new SqlParameter("@pEndereco", p_objCliente.Endereco));
            objParams.Add(new SqlParameter("@pDataNascimento", p_objCliente.DataNascimento));
            objParams.Add(new SqlParameter("@pNumeroCelular", p_objCliente.NumeroCelular));
            blnRetorno = objConnManager.executarComando(strSql, objParams);
            return blnRetorno;
        }

        public List<Cliente> consultar(string p_stringNome)
        {
            string strSql = "SELECT nome, telefoneResidencial, endereco,dataNascimento,numeroCelular FROM TbCliente Where nome = @pNome";
            List<SqlParameter> objParams = new List<SqlParameter>();
            objParams.Add(new SqlParameter("@pNome", p_stringNome));
            DataTable objTbCliente = objConnManager.retornarTabela(strSql, objParams, "Cliente");

            List<Cliente> objClientes = new List<Cliente>();
            foreach (DataRow row in objTbCliente.Rows)
            {
                Cliente objCliente = new Cliente();
                objCliente.Nome = (string)row["nome"];
                objCliente.TelefoneResidencial = (string)row["telefoneResidencial"];
                objCliente.Endereco = (string)row["endereco"];
                objCliente.DataNascimento = (DateTime)row["dataNascimento"];
                objCliente.NumeroCelular = (string)row["numeroCelular"];
                objClientes.Add(objCliente);
            }
            return objClientes;
        }
        public List<Cliente> retornarClientes()
        {
            string strSql = "SELECT nome, telefoneResidencial, endereco, dataNascimento, numeroCelular FROM TbCliente where dataNascimento is null or numeroCelular is null";
            List<SqlParameter> objParams = new List<SqlParameter>();
            DataTable objTbCliente = objConnManager.retornarTabela(strSql, objParams, "Cliente");

            List<Cliente> objClientes = new List<Cliente>();
            foreach (DataRow row in objTbCliente.Rows)
            {
                Cliente objCliente = new Cliente();
                objCliente.Nome = (string)row["nome"];
                objCliente.TelefoneResidencial = (string)row["telefoneResidencial"];
                objCliente.Endereco = (string)row["endereco"];
                if (Convert.ToString(row["dataNascimento"]) != "")
                    objCliente.DataNascimento = (DateTime)row["dataNascimento"];
                if (Convert.ToString(row["numeroCelular"]) != "")
                    objCliente.NumeroCelular = (string)row["numeroCelular"];
                objClientes.Add(objCliente);
            }
            return objClientes;
        }

        public void atualizarCliente(string nome, DateTime dataNascimento, string numeroCelular)
        {
            string strSql = "UPDATE TbCliente set dataNascimento = @pDataNascimento, numeroCelular = @pNumeroCelular where nome = @pNome";

            List<SqlParameter> objParams = new List<SqlParameter>();
            objParams.Add(new SqlParameter("@pNome", nome));
            objParams.Add(new SqlParameter("@pDataNascimento", dataNascimento));
            objParams.Add(new SqlParameter("@pNumeroCelular", numeroCelular));
            objConnManager.executarComando(strSql, objParams);
            
        }

    }
}