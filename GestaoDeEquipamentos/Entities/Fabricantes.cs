namespace GestaoDeEquipamentos.Entities
{
    internal class Fabricantes
    {
        private int _iD { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public int ID
        {
            get {  return _iD; }
            set { _iD = value; }
        }

        public Fabricantes(int iD, string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            ID = iD;
        }

        public void AtualiazaDados(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }

}
