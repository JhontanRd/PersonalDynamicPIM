namespace WebPIM.Models
{
    public class ApontamentoModel
    {
        public int Id_apontamento { get; set; }
        public DateTime Dia { get; set; }
        public DateTime Inicio_jornada { get; set; } 
        public DateTime Saida_almoco { get; set; }
        public DateTime Retorno_almoco { get; set; } 
        public DateTime Fim_jornada { get; set; } 
        public DateTime Somatorio_dia { get; set; }
        public int Id_funcionario { get; set; }
        
    }
}
