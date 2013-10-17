using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaNegocios;

namespace WcfIntegrationServiceLibrary
{
    class IntegrationService : IIntegration
    {

        public Cliente buscarCliente(string nome)
        {
            NGClientes objNegocios = new NGClientes();
            Cliente objCliente = new Cliente();
            objCliente.Nome = nome;
            objCliente.Endereco = "Rua Belem 305";
            objCliente.TelefoneResidencial = "30950405";
            objCliente.DataNascimento = DateTime.Parse("11/09/1988");
            objCliente.NumeroCelular = "";
            if (objNegocios.incluir(objCliente))
                return objCliente;

            throw new NotImplementedException();
        }

        public int atualizarCliente(string nome, DateTime dataNascimento, string numeroCelular)
        {
            NGClientes objNegocios = new NGClientes();
            objNegocios.atualizarCliente(nome, dataNascimento, numeroCelular);
            return 1;
        }

        public List<Cliente> retornaClientes()
        {
            NGClientes objNegocios = new NGClientes();
            return objNegocios.retornarClientes();
        }
    }
}
