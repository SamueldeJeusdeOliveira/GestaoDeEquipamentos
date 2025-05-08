using GestaoDeEquipamentos.Entities;

internal class TelaEquipamentos
{
    private List<Equipamento> equipamentos = new List<Equipamento>();
    private int contadorId = 1;
    public TelaEquipamentos(List<Equipamento> equipamentosExternos)
    {
        equipamentos = equipamentosExternos;
    }

    public void MenuEquipamento()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("(1) Visualizar o inventário");
            Console.WriteLine("(2) Registrar um Equipamento");
            Console.WriteLine("(3) Editar um Equipamento");
            Console.WriteLine("(4) Excluir um Equipamento");
            Console.WriteLine("(5) Voltar");

            char opcao = char.Parse(Console.ReadLine());

            switch (opcao)
            {
                case '1':
                    VisualizarInventario();
                    break;
                case '2':
                    RegistrarEquipamento();
                    break;
                case '3':
                    EditarEquipamento();
                    break;
                case '4':
                    ExcluirEquipamento();
                    break;
                case '5':
                    return;
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    public void VisualizarInventario()
    {
        Console.Clear();
        foreach (Equipamento e in equipamentos)
        {
            Console.WriteLine($"ID: {e.Id} | Nome: {e.Name} | Preço: R${e.PrecoAquisicao} | N° Série: {e.NumSerie} | Fabricação: {e.DataFabricacao.ToShortDateString()} | Fabricante: {e.Fabricante}");
        }

        if (equipamentos.Count == 0)
            Console.WriteLine("Nenhum equipamento registrado.");
    }

    public void RegistrarEquipamento()
    {
        Console.Clear();
        Equipamento equipamento = new Equipamento();

        equipamento.Id = contadorId++;

        Console.Write("Nome (mín. 6 caracteres): ");
        string nome = Console.ReadLine();
        if (nome.Length < 6)
        {
            Console.WriteLine("Nome deve ter no mínimo 6 caracteres!");
            return;
        }
        equipamento.Name = nome;

        Console.Write("Preço de aquisição: ");
        equipamento.PrecoAquisicao = double.Parse(Console.ReadLine());

        Console.Write("Número de série: ");
        equipamento.NumSerie = Console.ReadLine();

        Console.Write("Data de fabricação (dd/mm/yyyy): ");
        equipamento.DataFabricacao = DateTime.Parse(Console.ReadLine());

        Console.Write("Fabricante: ");
        equipamento.Fabricante = Console.ReadLine();

        equipamentos.Add(equipamento);
        Console.WriteLine("Equipamento registrado com sucesso!");
    }

    public void EditarEquipamento()
    {
        Console.Clear();
        VisualizarInventario();
        Console.Write("\nDigite o ID do equipamento que deseja editar: ");
        int id = int.Parse(Console.ReadLine());

        Equipamento equipamento = equipamentos.Find(e => e.Id == id);
        if (equipamento == null)
        {
            Console.WriteLine("Equipamento não encontrado.");
            return;
        }

        Console.Write("Novo nome (mín. 6 caracteres): ");
        string nome = Console.ReadLine();
        if (nome.Length >= 6)
            equipamento.Name = nome;

        Console.Write("Novo preço de aquisição: ");
        equipamento.PrecoAquisicao = double.Parse(Console.ReadLine());

        Console.Write("Novo número de série: ");
        equipamento.NumSerie = Console.ReadLine();

        Console.Write("Nova data de fabricação (dd/mm/yyyy): ");
        equipamento.DataFabricacao = DateTime.Parse(Console.ReadLine());

        Console.Write("Novo fabricante: ");
        equipamento.Fabricante = Console.ReadLine();

        Console.WriteLine("Equipamento atualizado com sucesso!");
    }

    public void ExcluirEquipamento()
    {
        Console.Clear();
        VisualizarInventario();
        Console.Write("\nDigite o ID do equipamento que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());

        Equipamento equipamento = equipamentos.Find(e => e.Id == id);
        if (equipamento == null)
        {
            Console.WriteLine("Equipamento não encontrado.");
            return;
        }

        equipamentos.Remove(equipamento);
        Console.WriteLine("Equipamento excluído com sucesso!");
    }
}
