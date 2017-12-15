using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fornecedores.DAO
{
    public class EstadoDAO
    {
        public List<Estado> ListaEstados()

        {
            string sql = " Select * from EstadoSet order by Descricao ";

            using (var conn = new SqlConnection(Constantes.sqlCon))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Estado> estados = new List<Estado>();
                Estado estado = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            estado = new Estado();
                            estado.IdEstado = (int)reader["IdEstado"];
                            estado.Descricao = reader["Descricao"].ToString();
                            estados.Add(estado);
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
                return estados;
            }
        }
    }
}