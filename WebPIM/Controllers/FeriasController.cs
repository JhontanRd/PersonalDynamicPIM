using Microsoft.AspNetCore.Mvc;
using WebPIM.Models;
using System.Data.SqlClient;
using System.Data;
using BaseDeDados;

namespace WebPIM.Controllers
{
    public class FeriasController : Controller
    {

        servidoresBancoDados _servidoresBancoDados = new servidoresBancoDados();


        public IActionResult Ferias()
        {
            try
            {
                List<FeriasModel> ferias = ObterListaFerias();

                if (ferias.Count > 0)
                {
                    ViewBag.StatusFerias = CalcularStatusFerias(ferias);
                    return View(ferias);
                }
                else
                {
                    ViewBag.StatusFerias = "Férias não agendada";
                    ViewBag.ErrorMessage = "Não há dados de férias disponíveis.";
                    return View(new List<FeriasModel>());
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Erro ao obter dados de férias: {ex.Message}"; // Adicionei ":" para separar a mensagem de erro
                return View(new List<FeriasModel>());
            }
        }

        private string CalcularStatusFerias(List<FeriasModel> ferias)
        {
            bool todasLiberadas = ferias.All(f => f.ObterStatusFerias() == "Liberada");
            bool todasNaoAgendadas = ferias.All(f => f.ObterStatusFerias() == "Não Agendada");

            if (todasLiberadas)
            {
                return "Férias liberada";
            }
            else if (todasNaoAgendadas)
            {
                return "Férias não agendada";
            }
            else
            {
                return "Suas férias não está liberada ou agendada";
            }
        }

        public List<FeriasModel> ObterListaFerias()
        {
            List<FeriasModel> lista = new List<FeriasModel>();

            SqlConnection conexaoDB = new SqlConnection(_servidoresBancoDados.servidor);
            {
                var id_funcionario_logado = HttpContext.Session.GetInt32("id_funcionario");

                conexaoDB.Open();

                string query = $"SELECT Ferias.*, " +
                            $"Funcionarios.Nome AS nome, Funcionarios.Sobrenome AS sobrenome, Funcionarios.Registro AS registro " +
                            $"FROM Ferias " +
                            $"INNER JOIN Funcionarios ON Ferias.Id_funcionarios = Funcionarios.Id_funcionario " + // Adicionei um espaço aqui
                            $"WHERE Ferias.Id_funcionarios = '{id_funcionario_logado}'";


                using (SqlCommand command = new SqlCommand(query, conexaoDB)) // ACHO Q ESSE VAI DAR ERRO QUANDO COMPILAR
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FeriasModel ferias = new FeriasModel();

                            ferias.Dias_gozados = reader.GetInt32(1);
                            ferias.Saida = reader.GetDateTime(2);
                            ferias.Retorno = reader.GetDateTime(3);
                            ferias.Nome = reader.GetString(reader.GetOrdinal("nome"));
                            ferias.Sobrenome = reader.GetString(reader.GetOrdinal("sobrenome"));
                            ferias.Registro = reader.GetInt32(reader.GetOrdinal("registro"));

                            lista.Add(ferias);
                        }
                        return lista;
                    }
                }
            }
        }
    }
}
