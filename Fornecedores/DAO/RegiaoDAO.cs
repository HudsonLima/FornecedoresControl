using DAL;
using Fornecedores.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;


namespace Fornecedores.DAO
{
    public class RegiaoDAO
    {
        // string de conexao
        // string conexao = WebConfigurationManager.ConnectionStrings["FornecedoresContext"].ConnectionString;

        public List<RegiaoEstado> ListaRegioesEstado(long? IdFornecedor, int opcao)
        {
            if (!IdFornecedor.HasValue)
            {
                IdFornecedor = 0;
            }

            string sql = " Select RegiaoSet.IdRegiao, RegiaoSet.Descricao as DescricaoRegiao, RegiaoSet.Ativo, ";
            sql += "EstadoSet.IdEstado, EstadoSet.Descricao as DescricaoEstado ";
            sql += "from RegiaoSet inner join EstadoSet on RegiaoSet.IdEstado = EstadoSet.IdEstado ";
            sql += " ORDER BY RegiaoSet.Descricao ";

            using (var conn = new SqlConnection(Constantes.sqlCon))
            {
                var cmd = new SqlCommand(sql, conn);
                List<RegiaoEstado> regioesEstados = new List<RegiaoEstado>();
                RegiaoEstado regiaoEstado = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            if (opcao == 1)
                            {
                                regiaoEstado = new RegiaoEstado();
                                regiaoEstado.IdRegiao = (long)reader["IdRegiao"];
                                regiaoEstado.IdEstado = (int)reader["IdEstado"];
                                regiaoEstado.IdFornecedorFormulario = (long)IdFornecedor;
                                regiaoEstado.relacionadoComFornecedor = IdFornecedor == 0 ? false : VerificaRelacionamento(regiaoEstado.IdRegiao, IdFornecedor);
                                regiaoEstado.DescricaoRegiao = reader["DescricaoRegiao"].ToString();
                                regiaoEstado.DescricaoEstado = reader["DescricaoEstado"].ToString();
                                regiaoEstado.Ativo = (byte)reader["Ativo"];
                                regioesEstados.Add(regiaoEstado);
                            }
                            else
                            {
                                regiaoEstado = new RegiaoEstado();
                                regiaoEstado.IdRegiao = (long)reader["IdRegiao"];
                                regiaoEstado.IdEstado = (int)reader["IdEstado"];
                                regiaoEstado.DescricaoRegiao = reader["DescricaoRegiao"].ToString();
                                regiaoEstado.DescricaoEstado = reader["DescricaoEstado"].ToString();
                                regiaoEstado.Ativo = (byte)reader["Ativo"];
                                regioesEstados.Add(regiaoEstado);

                            }

                        }
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                finally
                {
                    conn.Close();
                }
                return regioesEstados;
            }
        }

        public void atualizaRegiao(RegiaoView regiaoView)
        {
            using (var conn = new SqlConnection(Constantes.sqlCon))
            {
                string sql = "UPDATE RegiaoSet SET Descricao=@descricao, IdEstado=@IdEstado,Ativo=@ativo  Where IdRegiao=@IdRegiao";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@descricao", regiaoView.Descricao);
                cmd.Parameters.AddWithValue("@IdEstado", regiaoView.IdEstado);
                cmd.Parameters.AddWithValue("@Ativo", regiaoView.Ativo);
                cmd.Parameters.AddWithValue("@IdRegiao", regiaoView.IdRegiao);
                
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
            }

            public RegiaoView GetRegiaoById(int? IdRegiao)
        {     
            string sql = " Select RegiaoSet.IdRegiao, RegiaoSet.Descricao as DescricaoRegiao, RegiaoSet.Ativo, ";
            sql += "EstadoSet.IdEstado, EstadoSet.Descricao as DescricaoEstado ";
            sql += "from RegiaoSet inner join EstadoSet on RegiaoSet.IdEstado = EstadoSet.IdEstado ";
            sql += " where RegiaoSet.IdRegiao = @cod1 ";
            sql += " ORDER BY RegiaoSet.Descricao ";
                        
            using (var conn = new SqlConnection(Constantes.sqlCon))
            {
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod1", IdRegiao);
                
                RegiaoView regiaoView = null;               
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if(reader.HasRows)
                        {
                            if (reader.Read())
                            {

                                regiaoView = new RegiaoView();
                                regiaoView.IdEstado = (int)reader["IdEstado"];
                                regiaoView.Descricao = reader["DescricaoRegiao"].ToString();
                                regiaoView.Ativo = (byte)reader["Ativo"];
                                regiaoView.IdRegiao = (long)reader["IdRegiao"];
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                finally
                {
                    conn.Close();
                }
                return regiaoView;
            }
        }

        public void AtivarRegiao(int? idRegiao)
        {
            using (var conn = new SqlConnection(Constantes.sqlCon))
            {
                string sql = "UPDATE RegiaoSet SET Ativo=@ativo Where IdRegiao=@IdRegiao";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ativo", 1);
                cmd.Parameters.AddWithValue("@IdRegiao", idRegiao);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw e;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

            public void InativarRegiao(int? idRegiao)
            {
                using (var conn = new SqlConnection(Constantes.sqlCon))
                {
                    string sql = "UPDATE RegiaoSet SET Ativo=@ativo Where IdRegiao=@IdRegiao";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ativo", 0);
                    cmd.Parameters.AddWithValue("@IdRegiao", idRegiao);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
       

        public void Adiciona(IndexRegiao indexRegiao)
            {

            if (verificaSePodeAdicionar(indexRegiao.DescricaoRegiao, indexRegiao.IdEstado) == true)
            {

                using (var conn = new SqlConnection(Constantes.sqlCon))
                {
                    string sql = "INSERT INTO RegiaoSet  VALUES (@descricaoRegiao, @ativo, @IdEstado)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@descricaoRegiao", indexRegiao.DescricaoRegiao);
                    cmd.Parameters.AddWithValue("@ativo", 1);
                    cmd.Parameters.AddWithValue("@IdEstado", indexRegiao.IdEstado);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            else
            {                
            }
        }

        private bool verificaSePodeAdicionar(string DescricaoRegiao, int IdEstado)
        {
            using (var conn = new SqlConnection(Constantes.sqlCon))
            {
                string sql = " select * from RegiaoSet where IdEstado = @cod1 and Descricao = @cod2";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod1", IdEstado);
                cmd.Parameters.AddWithValue("@cod2", DescricaoRegiao);

                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            return false; ;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                finally
                {
                    conn.Close();
                }

            }
           
        }

        private bool VerificaRelacionamento(long idRegiao, long? idFornecedor)
            {

                using (var conn = new SqlConnection(Constantes.sqlCon))
                {
                    string sql = " select * from FornecedorRegiaoSet where idRegiao = @cod1 and idFornecedor = @cod2";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@cod1", idRegiao);
                    cmd.Parameters.AddWithValue("@cod2", idFornecedor);

                    try
                    {
                        conn.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (reader.HasRows)
                            {
                                return true; ;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        conn.Close();
                    }

                }


            }


            public List<RegiaoEstado> ListaRegioesEstado()
            {

                string sql = "select regiaoset.Descricao as DescricaoRegiao,regiaoset.Ativo, EstadoSet.Descricao as DescricaoEstado ";
                sql += " from regiaoset inner join EstadoSet on RegiaoSet.IdRegiao = EstadoSet.IdEstado ";
                sql += " order by estadoset.Descricao, regiaoset.Descricao ";

                using (var conn = new SqlConnection(Constantes.sqlCon))
                {
                    var cmd = new SqlCommand(sql, conn);
                    List<RegiaoEstado> regioesEstados = new List<RegiaoEstado>();
                    RegiaoEstado regiaoEstado = null;
                    try
                    {
                        conn.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (reader.Read())
                            {
                                regiaoEstado = new RegiaoEstado();
                                regiaoEstado.IdRegiao = (long)reader["IdRegiao"];
                                regiaoEstado.IdEstado = (int)reader["IdEstado"];
                                regiaoEstado.DescricaoRegiao = reader["DescricaoRegiao"].ToString();
                                regiaoEstado.DescricaoEstado = reader["DescricaoEstado"].ToString();
                                regiaoEstado.Ativo = (byte)reader["Ativo"];
                                regioesEstados.Add(regiaoEstado);

                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return regioesEstados;
                }
            }
        }
    }
