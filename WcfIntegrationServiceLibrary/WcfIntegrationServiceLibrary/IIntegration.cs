using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfIntegrationServiceLibrary
{
    [ServiceContract] //System.ServiceModel
    public interface IIntegration
    {
        [OperationContract]
        Cliente buscarCliente(string nome);

        [OperationContract]
        int atualizarCliente(string nome, DateTime dataNascimento, string numeroCelular);

        [OperationContract]
        List<Cliente> retornaClientes();
    }

    // Use a data contract
    [DataContract]
    public class Cliente
    {
        private string nome;
        private string telefoneResidencial;
        private string endereco;
        private DateTime dataNascimento;
        private string numeroCelular;

        public Cliente()
        {
            this.nome = string.Empty;
            this.telefoneResidencial = string.Empty;
            this.endereco = string.Empty;
            this.dataNascimento = DateTime.MinValue;
            this.numeroCelular = string.Empty;
        }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string TelefoneResidencial { get; set; }

        [DataMember]
        public string Endereco { get; set; }

        [DataMember]
        public DateTime DataNascimento { get; set; }

        [DataMember]
        public string NumeroCelular { get; set; }
    }
}
