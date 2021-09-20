using Domain.Model.Abstractions;
using Infra.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class ClienteService
    {
        readonly IClienteRepository ClienteRepository;
        public ClienteService() 
        {
            ClienteRepository = new ClienteRepository();
        }
        public bool RegistrarCliente(string DNI, string nombres, string apellidos, string direccion, string gmail, string celular, string contrasena)
        {
            return ClienteRepository.RegistrarCliente(DNI,nombres,apellidos,direccion,gmail,celular,contrasena);
        }
        public DataTable BuscarCliente(String buscar) 
        {
            return ClienteRepository.ListarCliente(buscar);
        }
        public bool ActualizarCliente(int ID_CLIENTE, string gmail, string celular) 
        {
            return ClienteRepository.ActualizarCliente(ID_CLIENTE, gmail, celular);
        }
    }
}
