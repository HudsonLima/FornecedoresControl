using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fornecedores.DAO
{
    public class FornecedorDAO
    {

        public List<Fornecedor> ListaFornecedores()

        {            
            string sql = " Select * from fornecedorSet order by Nome ";
          
            using (var conn = new SqlConnection(Constantes.sqlCon))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Fornecedor> fornecedores = new List<Fornecedor>();
                Fornecedor fornecedor = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            fornecedor = new Fornecedor();
                            fornecedor.IdFornecedor = (long)reader["IdFornecedor"];
                            fornecedor.CNPJ = reader["CNPJ"].ToString();
                            fornecedor.Nome = reader["Nome"].ToString();
                            fornecedores.Add(fornecedor);
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
                return fornecedores;
            }
        }
    }
}