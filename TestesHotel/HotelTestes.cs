namespace TestesHotel;

using DesafioProjetoHospedagem.Models;

[TestClass]
public class HotelTestes
{


    private List<Pessoa> CriarListaHospedes(int quantidade)
    {
        List<Pessoa> hospedes = [];

        for(int i = 0; i < quantidade; i++)
        {
            Pessoa p1 = new(nome: $"Hóspede {i+1}");
            hospedes.Add(p1);
        }

        return hospedes;
    }

    [TestMethod]
    public void CadastrarHospedes_ComSuiteEQuantidadeHospedesValida_DeveAdicionarHospedes()
    {
        int quantidadeHospedes = 3;
        List<Pessoa> hospedes = CriarListaHospedes(quantidadeHospedes);
        Suite suite = new(tipoSuite: "Premium", capacidade: quantidadeHospedes, valorDiaria: 30);

        Reserva reserva = new();
        reserva.CadastrarSuite(suite);
        reserva.CadastrarHospedes(hospedes);

        Assert.AreEqual(expected: hospedes, actual: hospedes);
    }

    [TestMethod]
    public void CadastrarHospedes_SemSuite_DeveJogarExceptionSuite()
    {
        int quantidadeHospedes = 3;
        List<Pessoa> hospedes = CriarListaHospedes(quantidadeHospedes);

        Reserva reserva = new();

        try
        {
            reserva.CadastrarHospedes(hospedes);
        }
        catch(Exception e)
        {
            StringAssert.Contains(e.Message, Reserva.SuiteNaoCadastradaMessage);
            return;
        }

        Assert.Fail("A exception esperada não foi lançada");
    }

    [TestMethod]
    public void CadastrarHospedes_ComSuiteEQuantidadeHospedesAcimaLimite_DeveJogarExceptionQuantidadeHospedes()
    {
        int quantidadeHospedes = 3;
        List<Pessoa> hospedes = CriarListaHospedes(quantidadeHospedes);
        Suite suite = new(tipoSuite: "Premium", capacidade: quantidadeHospedes-1, valorDiaria: 30);
        Reserva reserva = new();

        try
        {
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);
        }
        catch(Exception e)
        {
            StringAssert.Contains(e.Message, Reserva.MaisHospedesQueOPermitidoMessage);
            return;
        }

        Assert.Fail("A exception esperada não foi lançada");
    }

    [TestMethod]
    public void ObterQuantidadeHospedes_ComHospedes_DeveRetornarQuantidade()
    {
        // Preparando
        int esperado = 2;
        List<Pessoa> hospedes = CriarListaHospedes(esperado);
        Suite suite = new(tipoSuite: "Premium", capacidade: esperado, valorDiaria: 30);

        Reserva reserva = new();
        reserva.CadastrarSuite(suite);
        reserva.CadastrarHospedes(hospedes);

        // Assert
        int quantidadeHospedes = reserva.ObterQuantidadeHospedes();
        Assert.AreEqual(esperado, quantidadeHospedes, 0, "Erro ao obter quantidade de hospedes");
    }
}