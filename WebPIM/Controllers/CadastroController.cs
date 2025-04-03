using BaseDeDados;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebPIM.Models;


namespace WebPIM.Controllers
{
    public class CadastroController : Controller
    {
       servidoresBancoDados _servidoresBancoDados = new servidoresBancoDados();

            public IActionResult NovoCadastro()
            {
                return View();
            }

            public IActionResult CadastrandoFuncionario(CadastroModel cadastro)
            {
                if (CamposEstaoVazios(cadastro))
                {
                    TempData["MensagemErro"] = "Todos os campos são obrigatórios. Preencha todos os campos antes de cadastrar.";
                    return View("NovoCadastro");
                }
            if (CadastraFuncionario(cadastro))
                {
                    TempData["MensagemSucesso"] = "Cadastro concluido com sucesso, acesse o sistema";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    TempData["MensagemErro"] = "Falha no cadastro, verifique seus dados e tente novamente";
                    return View("NovoCadastro");
                }
            }
            

        private bool CamposEstaoVazios(CadastroModel cadastro)
            {
                return string.IsNullOrEmpty(cadastro.Nome) ||
                       string.IsNullOrEmpty(cadastro.Sobrenome) ||
                       string.IsNullOrEmpty(cadastro.Email) ||
                       string.IsNullOrEmpty(cadastro.Senha) ||
                       string.IsNullOrEmpty(cadastro.Confirmacao_senha) ||
                       string.IsNullOrEmpty(cadastro.Empregador) ||
                       string.IsNullOrEmpty(cadastro.Cargo);
            }

        protected bool CadastraFuncionario(CadastroModel cadastro)
            {
                SqlConnection conexaoDB = new SqlConnection(_servidoresBancoDados.servidor);

            try
            {
                var Nid = HttpContext.Session.GetInt32("Id_funcionario");

                conexaoDB.Open();

                string query = $"INSERT INTO Cadastro (Nome, Sobrenome, Idade, Email,Email_secundario,Senha, Confirmacao_senha, Empregador, Cargo, Id_funcionario) " +
                        "VALUES (@nome,@sobrenome, @idade, @email, @email_secundario, @senha, @confirmacao_senha, @empregador, @cargo, @id)";
                SqlCommand command = new SqlCommand(query, conexaoDB);

                command.Parameters.AddWithValue("@nome", cadastro.Nome);
                command.Parameters.AddWithValue("@sobrenome", cadastro.Sobrenome);
                command.Parameters.AddWithValue("@idade", cadastro.Idade);
                command.Parameters.AddWithValue("@email", cadastro.Email);
                command.Parameters.AddWithValue("@email_secundario", cadastro.Email_Secundario);
                command.Parameters.AddWithValue("@senha", cadastro.Senha);
                command.Parameters.AddWithValue("@confirmacao_senha", cadastro.Confirmacao_senha);
                command.Parameters.AddWithValue("@empregador", cadastro.Empregador);
                command.Parameters.AddWithValue("@cargo", cadastro.Cargo);
                command.Parameters.AddWithValue("@id", cadastro.Id_funcionario);


                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    TempData["MensagemSucesso"] = "Cadastro concluído com sucesso, acesse o sistema";
                    return true;
                }
            }
                catch (Exception ex)
                {
                    TempData["MensagemErro"] = $"Falha no cadastro, verifique seus dados e tente novamente: {ex.Message}";
                    throw;
                }

                TempData["MensagemErro"] = "Falha no cadastro, verifique seus dados e tente novamente";
                return false;
        }

    }
}
