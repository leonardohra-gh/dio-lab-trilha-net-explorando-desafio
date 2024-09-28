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
    public void ObterQuantidadeHospedes_ComHospedes_DeveRetornarQuantidade()
    {
        // Preparando
        int esperado = 2;
        List<Pessoa> hospedes = CriarListaHospedes(esperado);
        Suite suite = new(tipoSuite: "Premium", capacidade: esperado, valorDiaria: 30);

        Reserva reserva = new Reserva();
        reserva.CadastrarSuite(suite);
        reserva.CadastrarHospedes(hospedes);

        // Assert
        int quantidadeHospedes = reserva.ObterQuantidadeHospedes();
        Assert.AreEqual(esperado, quantidadeHospedes, 0, "Erro ao obter quantidade de hospedes");
    }
}