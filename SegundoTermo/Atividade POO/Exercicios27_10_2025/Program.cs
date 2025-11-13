namespace Exercicios27_10_2025;

class Program
{
    static void Main(string[] args)
    {
        Hospede H1 = new Hospede("163726", "Carlos Pereira", 1174836);
        Hospede H2 = new Hospede("4739847823", "Pedrim do grau", 1193783484);
        Quarto Q1 = new Quarto(101, "simples", 20.5);
        Quarto Q2 = new Quarto(505, "duplo", 67);
        Reserva RN = new Reserva(H1, Q1, 2);
        ReservaVip RV = new ReservaVip(H2, Q2, 4, 2);

        H1.ExibirDetalhes();
        H2.ExibirDetalhes();
        Q1.Ocupar();
        Q1.ExibirDetalhesQuarto();
        Q2.Ocupar();
        Q2.ExibirDetalhesQuarto();
        RN.CalcularTotal();
        RN.ResumoReserva();
        RV.CalcularTotal();
        RV.ResumoReserva();
    } 
}
