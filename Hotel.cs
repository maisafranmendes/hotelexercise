public class Hotel{
    private string nome;
    private int classificacao;
    private double valorDiaDeSemanaRegular;
    private double valorFimDeSemanaRegular;
    private double valorDiaDeSemanaFidelidade;
    private double valorFimDeSemanaFidelidade;

    public string Nome { get => nome; set => nome = value; }
    public int Classificacao { get => classificacao; set => classificacao = value; }
    public double ValorDiaDeSemanaRegular { get => valorDiaDeSemanaRegular; set => valorDiaDeSemanaRegular = value; }
    public double ValorFimDeSemanaRegular { get => valorFimDeSemanaRegular; set => valorFimDeSemanaRegular = value; }
    public double ValorFimDeSemanaFidelidade { get => valorFimDeSemanaFidelidade; set => valorFimDeSemanaFidelidade = value; }
    public double ValorDiaDeSemanaFidelidade { get => valorDiaDeSemanaFidelidade; set => valorDiaDeSemanaFidelidade = value; }

    public bool DiaDisponivel(DateTime dia){
        return true;
    }
}