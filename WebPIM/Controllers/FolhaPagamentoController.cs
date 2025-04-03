using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebPIM.Models;
using BaseDeDados;

namespace WebPIM.Controllers
{
    public class FolhaPagamentoController : Controller
    {
        servidoresBancoDados _servidoresBancoDados = new servidoresBancoDados();

        public IActionResult FolhaPagamento()
        {
            List<FolhaPagModel> listaFolhaPag = listaFolhaPagamento();
            return View(listaFolhaPag);
        }
        public List<FolhaPagModel> listaFolhaPagamento()
        {
            List<FolhaPagModel> lista = new List<FolhaPagModel>();

            using (SqlConnection conexaoDB = new SqlConnection(_servidoresBancoDados.servidor))
            {
                var id_funcionario_logado = HttpContext.Session.GetInt32("id_funcionario");

                conexaoDB.Open();

                string query = $"SELECT Folha_pagamento.*, " +
                        $"Funcionarios.Cargo AS cargo, Funcionarios.Registro AS registro, " +
                        $"Funcionarios.Nome AS nome, " +
                        $"Empresas.Nome_fantasia AS nome_fantasia, Empresas.Cnpj AS cnpj, " +
                        $"Decimo_terceiro_salario.Salario_base_decimo AS decimo_salario " +
                        $"FROM Folha_pagamento " +
                        $"INNER JOIN Funcionarios ON Folha_pagamento.Id_funcionarios = Funcionarios.Id_funcionario " +
                        $"INNER JOIN Empresas ON Folha_pagamento.Id_empresas = Empresas.Id_empresa " +
                        $"INNER JOIN Decimo_terceiro_salario ON Folha_pagamento.Id_Decimo_terceiro = Decimo_terceiro_salario.Id_decimo " +
                        $"WHERE Folha_pagamento.Id_funcionarios = '{id_funcionario_logado}'";


                using (SqlCommand command = new SqlCommand(query, conexaoDB))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FolhaPagModel folha = new FolhaPagModel();

                        folha.Salario_base = (float)reader.GetDouble(1);
                        folha.VL_transporte = (float)reader.GetDouble(2);
                        folha.VL_alimentacao = (float)reader.GetDouble(3);
                        folha.Adiantamento = (float)reader.GetDouble(4);
                        folha.Horas_trabalhadas = reader.GetInt32(5);
                        folha.Horas_extras = (float)reader.GetDouble(6);
                        folha.Adicional_not = (float)reader.GetDouble(7);
                        folha.Periculosidade = (float)reader.GetDouble(8);
                        folha.Insalubridade = (float)reader.GetDouble(9);
                        folha.Id_planos_saude = reader.GetInt32(10);
                        folha.Id_planos_odontologicos = reader.GetInt32(11);
                        folha.Dependentes = (float)reader.GetDouble(12);
                        folha.Pensao = (float)reader.GetDouble(13);
                        folha.Atrasos = (float)reader.GetDouble(14);
                        folha.Faltas = (float)reader.GetDouble(15);
                        folha.Inss = (float)reader.GetDouble(16);
                        folha.Irrf = (float)reader.GetDouble(17);
                        folha.Id_Decimo_terceiro = reader.GetInt32(18);
                        folha.Fgts = (float)reader.GetDouble(19);
                        folha.Vencimentos =  (float)reader.GetDouble(20);
                        folha.Descontos = (float)reader.GetDouble(21);
                        folha.Salario_liquido = (float)reader.GetDouble(22);
                        folha.Id_funcionarios = reader.GetInt32(23);
                        folha.Id_empresas = reader.GetInt32(24);
                        folha.Nome_fantasia = reader.GetString(reader.GetOrdinal("nome_fantasia"));
                        folha.Cnpj = reader.GetString(reader.GetOrdinal("cnpj"));
                        folha.Cargo = reader.GetString(reader.GetOrdinal("cargo"));
                        folha.Nome = reader.GetString(reader.GetOrdinal("nome"));
                        folha.Registro = reader.GetInt32(reader.GetOrdinal("registro"));


                        lista.Add(folha);
                    }
                    return lista;
                }
            }
        }
    }
}


