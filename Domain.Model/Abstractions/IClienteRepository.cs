using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Abstractions
{
    public interface IClienteRepository
    {
        bool RegistrarCliente(string DNI, string nombres, string apellidos, string direccion, string gmail, string celular, string contrasena);

        DataTable ListarCliente(String Busqueda);

        bool ActualizarCliente(int ID_CLIENTE, string gmail, string celular);


    }
}
