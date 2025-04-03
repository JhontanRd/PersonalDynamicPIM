using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebPIM.Models;
using BaseDeDados;
using EmpresasClientes;

namespace WebPIM.Controllers
{
    public class PontoController : Controller
    {
        servidoresBancoDados _servidoresBancoDados = new servidoresBancoDados();

        public int TotalHorasTrabalhadas { get; set; }
        public int HorasFaltantes { get; set; }
        public int HorasACompensar { get; set; }
        public int Id { get; set; }
        public string DataForm { get; set; }
        public string HoraForm { get; set; }
        public string idApontamento { get; set; }

        public IActionResult Index()
        {
            List<ApontamentoModel> listaPonto = ListarPontoEletronico();
            return View(listaPonto);
        }

        public List<ApontamentoModel> ListarPontoEletronico()
        {
            SqlConnection conexaoDB = new SqlConnection(_servidoresBancoDados.servidor);

            List<ApontamentoModel> lista = new List<ApontamentoModel>();

            var NRegistro = HttpContext.Session.GetInt32("id_funcionario");

            conexaoDB.Open();

            string query = $"SELECT * FROM Apontamento WHERE Id_funcionario = '{NRegistro}'";
            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ApontamentoModel ponto = new ApontamentoModel();

                ponto.Id_apontamento = reader.GetInt32(0);
                ponto.Inicio_jornada = reader.IsDBNull(1) ? DateTime.MinValue.Date : reader.GetDateTime(1);
                ponto.Saida_almoco = reader.IsDBNull(2) ? DateTime.MinValue.Date : reader.GetDateTime(2);
                ponto.Retorno_almoco = reader.IsDBNull(3) ? DateTime.MinValue.Date : reader.GetDateTime(3);
                ponto.Fim_jornada = reader.IsDBNull(4) ? DateTime.MinValue.Date : reader.GetDateTime(4);
                ponto.Somatorio_dia = reader.IsDBNull(5) ? DateTime.MinValue.Date : reader.GetDateTime(5);
                ponto.Dia = reader.GetDateTime(6);
                ponto.Id_funcionario = reader.GetInt32(7);

                lista.Add(ponto);
            }
            conexaoDB.Close();

            CalculoHoras(lista);

            return lista;
        }

        public void CalculoHoras(List<ApontamentoModel> lista)
        {
            var horasReportar = 0.0;
            var horasTotais = TimeSpan.Zero;
            var horasNoMes = 176.00;
            foreach (var item in lista)
            {
                var horasDia = TimeSpan.FromHours(item.Somatorio_dia.Hour + item.Somatorio_dia.Minute / 60.0);
                horasTotais = horasTotais.Add(horasDia);
            }
            horasReportar = horasNoMes - horasTotais.TotalHours;
            ViewBag.reportar = horasReportar.ToString("N2");
            ViewBag.data = $"{horasTotais.Hours}:{horasTotais.Minutes}";
        }

        public IActionResult BaterPonto()
        {
            SqlConnection conexaoDB = new SqlConnection(_servidoresBancoDados.servidor);
            try
            {
                ApontamentoModel ponto = new ApontamentoModel();

                List<ApontamentoModel> lista = new List<ApontamentoModel>();

                var id_funcionario_logado = HttpContext.Session.GetInt32("id_funcionario");
                DateTime dataHora = DateTime.Now;

                string HorasFormatada = dataHora.ToString("T");
                HoraForm = HorasFormatada;
                string dataFormatada = dataHora.Date.ToString("dd/MM/yyyy");//mudei aqui .Date
                DataForm = dataFormatada;

                conexaoDB.Open();

                // Agora vou criar um if para validar as possivei situações e jogar nos métodos certos.
                bool retornoConsultaRegistro = ConsultarRegistro(Convert.ToInt32(id_funcionario_logado));
                if (retornoConsultaRegistro)
                {
                    string query = "SELECT TOP 1 * FROM Apontamento WHERE Id_funcionario = @idFuncionariologado ORDER BY Id_apontamento DESC";
                    SqlCommand command = new SqlCommand(query, conexaoDB);

                    var _pmtIdFuncionarioLogado = command.CreateParameter();
                    _pmtIdFuncionarioLogado.ParameterName = "@idFuncionariologado";
                    _pmtIdFuncionarioLogado.DbType = DbType.Int32;
                    _pmtIdFuncionarioLogado.Value = id_funcionario_logado;
                    command.Parameters.Add(_pmtIdFuncionarioLogado);

                    SqlDataReader _leitor = command.ExecuteReader();

                    while (_leitor.Read()) // ELE ESTA IGNORANDO ESSE BLOCO PQ NÃO TEM NENHUM REGISTRO NA TABELA.
                    {
                        idApontamento = _leitor.GetInt32(0).ToString();
                        if (!_leitor.IsDBNull(1) && _leitor.IsDBNull(2))
                        {
                            // VOU DECLARAR A VARIAVEL AUI DENTRO E SE DER PROBLEMA DEPOIS EU MUDO.
                            bool retornoSaidaAlmoco = SaidaAlmoco();
                        }
                        else if (!_leitor.IsDBNull(1) && !_leitor.IsDBNull(2) && _leitor.IsDBNull(3))
                        {
                            bool retornoVolataAlmoco = RetornoAlmoco();
                        }
                        else if (!_leitor.IsDBNull(1) && !_leitor.IsDBNull(2) && !_leitor.IsDBNull(3) && _leitor.IsDBNull(4))
                        {
                            bool retornoFimJornada = FimJornada();

                            List<ApontamentoModel> listaDeRegistros = new List<ApontamentoModel>();
                            listaDeRegistros = CapturarRegistros(Convert.ToInt32(id_funcionario_logado), ponto);

                            var horastrabalhadas = CalcularHorasTrabalhadas(listaDeRegistros);

                            //iserirHoras(dataFormatada.ToString("dd/MM/yyyy"), horastrabalhadas);
                            iserirHoras(dataFormatada, horastrabalhadas);
                        }
                    }
                }
                else
                {
                    bool retornoPrimeiraBati = InicioJornada(Convert.ToInt32(id_funcionario_logado));
                }

                conexaoDB.Close();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                throw;
            }



        }

        // AQUI O SISTEMA CHAMA O METODO DE CALCULAR AS HORAS E GRAVA O TOTAL DAS HORAS UTILIZANDO COMO REFERENCIA O ID DO FUNCIONARIO
        public void iserirHoras(string dataFormatada, TimeSpan horasTrabalhadas)
        {

            SqlConnection conexaoDB = new SqlConnection(_servidoresBancoDados.servidor);

            conexaoDB.Open();

            var id_funcionario_logado = HttpContext.Session.GetInt32("id_funcionario");

            string query = "UPDATE Apontamento " +
                $"SET Somatorio_dia = '{horasTrabalhadas}' " + // falta arrumar essa parte e fazer a hra se juntar com a data pq ele jogou uma data nada a ver.
                $"WHERE id_funcionario = '{id_funcionario_logado}' AND dia = '{dataFormatada}'";

            SqlCommand command = new SqlCommand(query, conexaoDB);
            SqlDataReader reader = command.ExecuteReader();
        }

        private TimeSpan CalcularHorasTrabalhadas(List<ApontamentoModel> lista) // AQUI O SISTEMA CALCULAR QUANTAS HORAS FORAM TRABALHADAS PARA SOMAR O DIA TRABALHADO.
        {
            foreach (var item in lista)
            {
                var horasPrimeiroPeriodo = item.Saida_almoco - item.Inicio_jornada;
                var horasSegundoPeriodo = item.Fim_jornada - item.Retorno_almoco;
                var horaTrabalhadaTotal = horasPrimeiroPeriodo + horasSegundoPeriodo;
                return horaTrabalhadaTotal;
            }
            return TimeSpan.Zero;
        }

        private bool ConsultarRegistro(int id_funcionario_logado)
        {
            SqlConnection conexaoDB = new SqlConnection(_servidoresBancoDados.servidor);


            try
            {
                conexaoDB.Open();
                string query = "SELECT * FROM Apontamento WHERE Id_funcionario = @idFuncionariologado";
                SqlCommand command = new SqlCommand(query, conexaoDB);

                var _pmtIdFuncionarioLogado = command.CreateParameter();
                _pmtIdFuncionarioLogado.ParameterName = "@idFuncionariologado";
                _pmtIdFuncionarioLogado.DbType = DbType.Int32;
                _pmtIdFuncionarioLogado.Value = id_funcionario_logado;
                command.Parameters.Add(_pmtIdFuncionarioLogado);

                SqlDataReader _leitor = command.ExecuteReader();

                if (_leitor.Read())
                {
                    conexaoDB.Close();
                    return true;
                }
                else
                {
                    conexaoDB.Close();
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void AdicionarMensagemAlerta(string mensagem)
        {
            TempData["MensagemAlerta"] = mensagem;
        }

        private bool InicioJornada(int idFuncionarioLogado)
        {
            SqlConnection conexaoDB = new SqlConnection(_servidoresBancoDados.servidor);

            conexaoDB.Open();
            try
            {
                string queryPrimeiroRegistroDia = "INSERT INTO Apontamento (Inicio_jornada, Dia, Id_funcionario) VALUES (@inicioJornada, @dia, @idFuncionario)";
                SqlCommand command = new SqlCommand(queryPrimeiroRegistroDia, conexaoDB);

                var _pmtInicioJornada = command.CreateParameter();
                _pmtInicioJornada.ParameterName = "@inicioJornada";
                _pmtInicioJornada.DbType = DbType.DateTime;
                _pmtInicioJornada.Value = HoraForm;
                command.Parameters.Add(_pmtInicioJornada);

                var _pmtDia = command.CreateParameter();
                _pmtDia.ParameterName = "@dia";
                _pmtDia.DbType = DbType.DateTime;
                _pmtDia.Value = DataForm;
                command.Parameters.Add(_pmtDia);

                var _pmtIdFuncionario = command.CreateParameter();
                _pmtIdFuncionario.ParameterName = "@idFuncionario";
                _pmtIdFuncionario.DbType = DbType.Int32;
                _pmtIdFuncionario.Value = idFuncionarioLogado;
                command.Parameters.Add(_pmtIdFuncionario);

                if (command.ExecuteNonQuery() > 0)
                {
                    AdicionarMensagemAlerta("Hora de início de jornada marcada com sucesso!");
                    conexaoDB.Close();
                    return true;
                }
                else
                {
                    conexaoDB.Close();
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private bool SaidaAlmoco()
        {
            SqlConnection conexaoDB = new SqlConnection(_servidoresBancoDados.servidor);

            conexaoDB.Open();
            try
            {
                string querySaidaAlmoco = "UPDATE Apontamento SET Saida_almoco = @saidaAlmoco WHERE Id_apontamento = @idApontamento";
                SqlCommand command = new SqlCommand(querySaidaAlmoco, conexaoDB);

                var _saidaAlmoco = command.CreateParameter();
                _saidaAlmoco.ParameterName = "@saidaAlmoco";
                _saidaAlmoco.DbType = DbType.DateTime;
                _saidaAlmoco.Value = HoraForm;
                command.Parameters.Add(_saidaAlmoco);

                var _pmtIdApontamento = command.CreateParameter();
                _pmtIdApontamento.ParameterName = "@idApontamento";
                _pmtIdApontamento.DbType = DbType.Int32;
                _pmtIdApontamento.Value = idApontamento;
                command.Parameters.Add(_pmtIdApontamento);

                if (command.ExecuteNonQuery() > 0)
                {
                    AdicionarMensagemAlerta("Hora de almoço marcada com sucesso!");
                    conexaoDB.Close();
                    return true;
                }
                else
                {
                    conexaoDB.Close();
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private bool RetornoAlmoco()
        {
            SqlConnection conexaoDB = new SqlConnection(_servidoresBancoDados.servidor);

            conexaoDB.Open();
            try
            {
                string queryRetornoAlmoco = "UPDATE Apontamento SET Retorno_almoco = @retornoAlmoco WHERE Id_apontamento = @idApontamento";
                SqlCommand command = new SqlCommand(queryRetornoAlmoco, conexaoDB);

                var _saidaAlmoco = command.CreateParameter();
                _saidaAlmoco.ParameterName = "@retornoAlmoco";
                _saidaAlmoco.DbType = DbType.DateTime;
                _saidaAlmoco.Value = HoraForm;
                command.Parameters.Add(_saidaAlmoco);

                var _pmtIdApontamento = command.CreateParameter();
                _pmtIdApontamento.ParameterName = "@idApontamento";
                _pmtIdApontamento.DbType = DbType.Int32;
                _pmtIdApontamento.Value = idApontamento;
                command.Parameters.Add(_pmtIdApontamento);

                if (command.ExecuteNonQuery() > 0)
                {
                    AdicionarMensagemAlerta("Retorno almoço marcada com sucesso!");
                    conexaoDB.Close();
                    return true;
                }
                else
                {
                    conexaoDB.Close();
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private bool FimJornada()
        {
            SqlConnection conexaoDB = new SqlConnection(_servidoresBancoDados.servidor);

            conexaoDB.Open();
            try
            {
                string queryFimJornada = "UPDATE Apontamento SET Fim_jornada = @fimJornada WHERE Id_apontamento = @idApontamento";
                SqlCommand command = new SqlCommand(queryFimJornada, conexaoDB);

                var _saidaAlmoco = command.CreateParameter();
                _saidaAlmoco.ParameterName = "@fimJornada";
                _saidaAlmoco.DbType = DbType.DateTime;
                _saidaAlmoco.Value = HoraForm;
                command.Parameters.Add(_saidaAlmoco);

                var _pmtIdApontamento = command.CreateParameter();
                _pmtIdApontamento.ParameterName = "@idApontamento";
                _pmtIdApontamento.DbType = DbType.Int32;
                _pmtIdApontamento.Value = idApontamento;
                command.Parameters.Add(_pmtIdApontamento);

                if (command.ExecuteNonQuery() > 0)
                {
                    AdicionarMensagemAlerta("Hora de fim de jornada marcada com sucesso!");
                    conexaoDB.Close();
                    return true;
                }
                else
                {
                    conexaoDB.Close();
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private List<ApontamentoModel> CapturarRegistros(int idFuncionarioLogado, ApontamentoModel _apontamentoModel)
        {
            SqlConnection conexaoDB = new SqlConnection(_servidoresBancoDados.servidor);

            try
            {
                conexaoDB.Open();
                string query = "SELECT Inicio_jornada, Saida_almoco, retorno_almoco, Fim_jornada FROM Apontamento WHERE Id_funcionario = @idFuncionarioLogado";

                SqlCommand cmd = new SqlCommand(query, conexaoDB);

                List<ApontamentoModel> _registros = new List<ApontamentoModel>();

                var _pmtIdFuncionarioLogado = cmd.CreateParameter();
                _pmtIdFuncionarioLogado.ParameterName = "@idFuncionarioLogado";
                _pmtIdFuncionarioLogado.DbType = DbType.Int32;
                _pmtIdFuncionarioLogado.Value = idFuncionarioLogado;
                cmd.Parameters.Add(_pmtIdFuncionarioLogado);

                SqlDataReader _leitor = cmd.ExecuteReader();

                while (_leitor.Read())
                {
                    // DENTRO DO WHILE EU VOU TER Q CAPTURAR OS DADOS EM DATETIME E DEPOIS CONVERTER PARA TIMESPAN PARA ARMAZENAR NOS ATRIBUTOS E UTILIZAR.

                    DateTime inicioExpediente = _leitor.GetDateTime(0);
                    DateTime saidAlmoco = _leitor.GetDateTime(1);
                    DateTime retornoAlmoco = _leitor.GetDateTime(2);
                    DateTime fimExpediente = _leitor.GetDateTime(3);

                    string inicio = inicioExpediente.ToString();
                    _apontamentoModel.Inicio_jornada = HoraFomatada(inicio);

                    string inicioAlmoco = saidAlmoco.ToString();
                    _apontamentoModel.Saida_almoco = HoraFomatada(inicioAlmoco);

                    string voltAlmoco = retornoAlmoco.ToString();
                    _apontamentoModel.Retorno_almoco = HoraFomatada(voltAlmoco);

                    string saida = fimExpediente.ToString();
                    _apontamentoModel.Fim_jornada = HoraFomatada(saida);

                    _registros.Add(_apontamentoModel);
                }
                conexaoDB.Close();
                return _registros;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private DateTime HoraFomatada(string periodo)
        {
            string periodoLimpo = periodo.Replace("{", "").Replace("}", "").Replace("/", " ").Replace(":", " ");

            // Divida a string limpa em partes
            string[] periodoPartes = periodoLimpo.Split(' ');

            // Extraia ano, mês, dia, horas, minutos e segundos
            int dia = Convert.ToInt32(periodoPartes[0]);
            int mes = Convert.ToInt32(periodoPartes[1]);
            int ano = Convert.ToInt32(periodoPartes[2]);
            int horas = Convert.ToInt32(periodoPartes[3]);
            int minutos = Convert.ToInt32(periodoPartes[4]);
            int segundos = Convert.ToInt32(periodoPartes[5]);
            DateTime inicioExpedienteFormatado = new DateTime(ano, mes, dia, horas, minutos, segundos);
            return inicioExpedienteFormatado;
        }
    }
}

