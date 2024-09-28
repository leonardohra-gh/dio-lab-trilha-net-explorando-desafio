namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public const string SuiteNaoCadastradaMessage = "Não há uma suíte cadastrada."; 
        public const string MaisHospedesQueOPermitidoMessage = "Quantidade de hóspedes maior que a capacidade da suíte."; 
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if(Suite == null)
            {
                throw new Exception(SuiteNaoCadastradaMessage);
            }
            else if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception(MaisHospedesQueOPermitidoMessage);
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if(Hospedes != null)
            {
                return Hospedes.Count;
            }

            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            if(Suite == null)
            {
                throw new Exception(SuiteNaoCadastradaMessage);
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor *= 0.9M;
            }

            return valor;
        }
    }
}