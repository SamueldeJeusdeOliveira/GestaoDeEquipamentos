namespace GestaoDeEquipamentos.Entities
{
    class Equipamento
    {
        private int _iD { get; set; }
        public string Nome { get; set; }
        private double _precoAquisicao { get; set; }
        public string NumSerie { get; set; }
        private DateTime _dataFabricacao { get; set; }
        public Fabricantes Fabricante { get; set; }
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        public double PrecoAquisicao
        {
            get { return _precoAquisicao; }
            set { _precoAquisicao = value; }
        }
        public DateTime DataFabricacao
        {
            get { return _dataFabricacao; }
            set { _dataFabricacao = value; }
        }

        public Equipamento(string nome, string numSerie, Fabricantes fabricante, int iD, double precoAquisicao, DateTime dataFabricacao)
        {
            Nome = nome;
            NumSerie = numSerie;
            Fabricante = fabricante;
            ID = iD;
            PrecoAquisicao = precoAquisicao;
            DataFabricacao = dataFabricacao;
        }

        public void AtualiazaDados(string nome, double preco, string numSerie, DateTime date, Fabricantes fabricante)
        {
            Nome = nome;
            PrecoAquisicao = preco;
            NumSerie = numSerie;
            DataFabricacao = date;
            Fabricante = fabricante;
        }
    }
}
