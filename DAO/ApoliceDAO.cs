using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ApoliceDAO
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDev"].ConnectionString;
        private IDbConnection conexao;

        public ApoliceDAO()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        public List<ApoliceDTO> PesquisarApolice(ApoliceDTO apolice)
        {
            var apolices = new List<ApoliceDTO>();

            try
            {
                IDbCommand comando = conexao.CreateCommand();

                comando.CommandText = $"SELECT ID, NUMERO_APOLICE, CPF_CNPJ, PLACA_VEICULO, VALOR_PREMIO" +
                    $" FROM APOLICE WHERE NUMERO_APOLICE = {apolice.NumeroApolice}";

                IDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    apolice = new ApoliceDTO();
                    apolice.ID = Convert.ToInt32(resultado["ID"]);
                    apolice.NumeroApolice = Convert.ToInt32(resultado["NUMERO_APOLICE"]);
                    if (DBNull.Value == resultado["CPF_CNPJ"])
                    {
                        apolice.CpfCnpj = 0;
                    }
                    else
                    {
                        apolice.CpfCnpj = Convert.ToInt64(resultado["CPF_CNPJ"]);
                    }
                    apolice.PlacaVeiculo = Convert.ToString(resultado["PLACA_VEICULO"]);
                    if (resultado["VALOR_PREMIO"] == DBNull.Value)
                        apolice.ValorPremio = 0.0;
                    else
                        apolice.ValorPremio = Convert.ToDouble(resultado["VALOR_PREMIO"]);

                    apolices.Add(apolice);
                }

                return apolices;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public List<ApoliceDTO> PesquisarApolicePorID(ApoliceDTO apolice)
        {
            var apolices = new List<ApoliceDTO>();

            try
            {
                IDbCommand comando = conexao.CreateCommand();

                comando.CommandText = $"SELECT ID, NUMERO_APOLICE, CPF_CNPJ, PLACA_VEICULO, VALOR_PREMIO" +
                    $" FROM APOLICE WHERE ID = {apolice.ID}";

                IDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    apolice = new ApoliceDTO();
                    apolice.ID = Convert.ToInt32(resultado["ID"]);
                    apolice.NumeroApolice = Convert.ToInt32(resultado["NUMERO_APOLICE"]);
                    if (DBNull.Value == resultado["CPF_CNPJ"])
                    {
                        apolice.CpfCnpj = 0;
                    }
                    else
                    {
                        apolice.CpfCnpj = Convert.ToInt64(resultado["CPF_CNPJ"]);
                    }
                    apolice.PlacaVeiculo = Convert.ToString(resultado["PLACA_VEICULO"]);
                    if (resultado["VALOR_PREMIO"] == DBNull.Value)
                        apolice.ValorPremio = 0.0;
                    else
                        apolice.ValorPremio = Convert.ToDouble(resultado["VALOR_PREMIO"]);

                    apolices.Add(apolice);
                }

                return apolices;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public List<ApoliceDTO> PesquisarApoliceTodas()
        {
            var apolices = new List<ApoliceDTO>();

            try
            {
                IDbCommand comando = conexao.CreateCommand();

                comando.CommandText = "SELECT ID, NUMERO_APOLICE, CPF_CNPJ, PLACA_VEICULO, VALOR_PREMIO FROM APOLICE";

                IDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {

                    var apolice = new ApoliceDTO();
                    apolice.ID = Convert.ToInt32(resultado["ID"]);
                    apolice.NumeroApolice = Convert.ToInt32(resultado["NUMERO_APOLICE"]);
                    if (DBNull.Value == resultado["CPF_CNPJ"])
                    {
                        apolice.CpfCnpj = 0;
                    }
                    else
                    { 
                        apolice.CpfCnpj = Convert.ToInt64(resultado["CPF_CNPJ"]);
                    }
                    apolice.PlacaVeiculo = Convert.ToString(resultado["PLACA_VEICULO"]);
                    if (resultado["VALOR_PREMIO"] == DBNull.Value)
                        apolice.ValorPremio = 0.0;
                    else
                        apolice.ValorPremio = Convert.ToDouble(resultado["VALOR_PREMIO"]);

                    apolices.Add(apolice);
                }

                return apolices;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void CriarApolice(ref ApoliceDTO apolice)
        {
            try
            {
                IDbCommand comando = conexao.CreateCommand();
                comando.CommandText = "INSERT INTO APOLICE (NUMERO_APOLICE, CPF_CNPJ, PLACA_VEICULO, VALOR_PREMIO)" +
                    " VALUES (@NUMERO_APOLICE, @CPF_CNPJ, @PLACA_VEICULO, @VALOR_PREMIO)";

                IDbDataParameter numeroApolice = new SqlParameter("NUMERO_APOLICE", apolice.NumeroApolice);
                comando.Parameters.Add(numeroApolice);
                IDbDataParameter CpfCnpf = new SqlParameter("CPF_CNPJ", apolice.CpfCnpj);
                comando.Parameters.Add(CpfCnpf);
                IDbDataParameter placaVeiculo = new SqlParameter("PLACA_VEICULO", apolice.PlacaVeiculo);
                comando.Parameters.Add(placaVeiculo);
                IDbDataParameter valorPremio = new SqlParameter("VALOR_PREMIO", apolice.ValorPremio);
                comando.Parameters.Add(valorPremio);


                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void AlterarApolice(ref ApoliceDTO apolice)
        {
            try
            {
                IDbCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE APOLICE SET NUMERO_APOLICE = @NUMERO_APOLICE " +
                    ", CPF_CNPJ = @CPF_CNPJ, PLACA_VEICULO = @PLACA_VEICULO, VALOR_PREMIO = @VALOR_PREMIO" +
                    " WHERE ID = @ID";

                IDbDataParameter numeroApolice = new SqlParameter("NUMERO_APOLICE", apolice.NumeroApolice);
                comando.Parameters.Add(numeroApolice);
                IDbDataParameter CpfCnpf = new SqlParameter("CPF_CNPJ", apolice.CpfCnpj);
                comando.Parameters.Add(CpfCnpf);
                IDbDataParameter placaVeiculo = new SqlParameter("PLACA_VEICULO", apolice.PlacaVeiculo);
                comando.Parameters.Add(placaVeiculo);
                IDbDataParameter valorPremio = new SqlParameter("VALOR_PREMIO", apolice.ValorPremio);
                comando.Parameters.Add(valorPremio);

                IDbDataParameter id = new SqlParameter("ID", apolice.ID);
                comando.Parameters.Add(id);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void ExcluirApolice(ref ApoliceDTO apolice)
        {
            try
            {
                IDbCommand comando = conexao.CreateCommand();
                comando.CommandText = "DELETE FROM APOLICE WHERE NUMERO_APOLICE = @NUMERO_APOLICE";

                IDbDataParameter paramID = new SqlParameter("NUMERO_APOLICE", apolice.NumeroApolice);
                comando.Parameters.Add(paramID);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
