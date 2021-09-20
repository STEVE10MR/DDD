using Domain.Model.Abstractions;
using Domain.Model.Entities;
using Infra.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class EmpleadoService
    {
        readonly IEmpleadosRepository EmpleadosRepository;
        public EmpleadoService()
        {
            EmpleadosRepository = new EmpleadoRepository();
        }
        public bool RegistrarEmpleado(string DNI, string nombres, string apellidos, string direccion, string gmail, string celular, string contrasena, string area, string cargo) 
        {
            Usuario OBJUsuario = new Usuario();
            OBJUsuario.DNI = DNI;
            OBJUsuario.Nombres = nombres;
            OBJUsuario.Apellidos = apellidos;
            OBJUsuario.Dirección = direccion;
            OBJUsuario.EMAIL = gmail;
            OBJUsuario.Celular = celular;
            OBJUsuario.Contrasena = contrasena;

            Empleado OBJEmpleado = new Empleado();
            OBJEmpleado.area = area;
            OBJEmpleado.cargo = cargo;

            return EmpleadosRepository.RegistrarEmpleado(OBJEmpleado,OBJUsuario);
        }
        public DataTable BuscarEmpleado(string Buscar) 
        {
            return EmpleadosRepository.BuscarEmpleado(Buscar);
        }
        public bool DesactivarEmpleado(int ID_Empleado)
        {
            return EmpleadosRepository.DesactivarEmpleado(ID_Empleado);
        }
        public bool ActivarEmpleado(int ID_Empleado)
        {
            return EmpleadosRepository.ActivarEmpleado(ID_Empleado);
        }
    }
}
