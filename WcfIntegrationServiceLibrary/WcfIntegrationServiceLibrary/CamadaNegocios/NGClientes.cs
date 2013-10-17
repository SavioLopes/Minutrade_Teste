using CamadaDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfIntegrationServiceLibrary;

namespace CamadaNegocios
{
    public class NGClientes
    {
        public bool incluir(Cliente p_objCliente)
        {
            DBTbCliente objDados = new DBTbCliente();
            return objDados.incluir(p_objCliente);
        }
        public List<Cliente> consultar(string p_stringNome)
        {
            DBTbCliente objDados = new DBTbCliente();
            return objDados.consultar(p_stringNome);
        }
        /// <summary>
        /// <para> dfsfsd</para>
        /// </summary>
        /// <returns></returns>
        public List<Cliente> retornarClientes()
        {
            DBTbCliente objDados = new DBTbCliente();
            return objDados.retornarClientes();
        }

        public void atualizarCliente(string nome, DateTime dataNascimento, string numeroCelular)
        {
            DBTbCliente objDados = new DBTbCliente();
            objDados.atualizarCliente(nome, dataNascimento, numeroCelular);
        }
    }
}