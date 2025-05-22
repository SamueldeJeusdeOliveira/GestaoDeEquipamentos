namespace GestaoDeEquipamentos.Entities
{
    class Chamado
    {
        public int _iD { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Equipamento Equipamento { get; set; }
        public DateTime DataAbertura { get; set; }
        public int Id
        {
            get { return _iD; }
            set { _iD = value; }
        }

        public Chamado(string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura, int id)
        {
            Titulo = titulo;
            Descricao = descricao;
            Equipamento = equipamento;
            DataAbertura = dataAbertura;
            Id = id;
        }

        public void AtualiazaDados(string titulo, string descricao, Equipamento equipamento)
        {
            Titulo = titulo;
            Descricao = descricao;
            Equipamento = equipamento;
        }
    }
}
