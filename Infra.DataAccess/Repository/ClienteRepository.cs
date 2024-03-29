﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Abstractions;
using Domain.Model.Entities;

namespace Infra.DataAccess.Repository
{
    public class ClienteRepository : ConectionSql, IClienteRepository
    {
        public bool ActualizarCliente(int ID_CLIENTE, string gmail, string celular)
        {
            bool retornar = false;
            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("C_ACTUALIZAR", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PID_CLIENTE", SqlDbType.Int).Value = ID_CLIENTE;
                command.Parameters.Add("@PEMAIL", SqlDbType.VarChar).Value = gmail;
                command.Parameters.Add("@PCELULAR", SqlDbType.VarChar).Value = celular;

                cnx.Open();
                retornar = command.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (Exception EX)
            {
                throw EX;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
            return retornar;
        }

        public DataTable ListarCliente(string Busqueda)
        {
            SqlDataReader DR;
            DataTable TABLE = new DataTable();
            SqlConnection SQLCNX = new SqlConnection();
            try
            {
                SQLCNX = ConectionSql.Objet().Connection();
                SqlCommand COMMAND = new SqlCommand("C_BUSCAR", SQLCNX);
                COMMAND.CommandType = CommandType.StoredProcedure;
                COMMAND.Parameters.Add("@PBUSCAR", SqlDbType.VarChar).Value = Busqueda;
                SQLCNX.Open();
                DR = COMMAND.ExecuteReader();
                TABLE.Load(DR);
                return TABLE;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            finally
            {
                if (SQLCNX.State == ConnectionState.Open)
                    SQLCNX.Close();
            }
        }

        public bool RegistrarCliente(int ID_Usuario)
        {
            bool retornar = false;
            SqlConnection cnx = new SqlConnection();
            try
            {
                cnx = ConectionSql.Objet().Connection();
                SqlCommand command = new SqlCommand("C_INSERT", cnx);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PIDUSUARIO", SqlDbType.VarChar).Value = ID_Usuario;
                cnx.Open();
                retornar = command.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (Exception EX)
            {
                throw EX;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
            return retornar;
        }

    }
}
