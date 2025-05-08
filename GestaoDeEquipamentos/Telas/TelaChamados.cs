using GestaoDeEquipamentos.Entities;
using System;
using System.Collections.Generic;

namespace GestaoDeEquipamentos.Telas
{
    internal class TelaChamados
    {
        private List<Chamado> chamados = new List<Chamado>();
        private List<Equipamento> equipamentos = new List<Equipamento>(); // Compartilhado
        private int contadorId = 1;

        public TelaChamados(List<Equipamento> equipamentos)
        {
            this.equipamentos = equipamentos;
        }

        public void MenuChamados()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("(1) Visualizar chamados");
                Console.WriteLine("(2) Registrar chamado");
                Console.WriteLine("(3) Editar chamado");
                Console.WriteLine("(4) Excluir chamado");
                Console.WriteLine("(5) Voltar");

                char opcao = char.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case '1':
                        VisualizarChamados();
                        break;
                    case '2':
                        RegistrarChamado();
                        break;
                    case '3':
                        EditarChamado();
                        break;
                    case '4':
                        ExcluirChamado();
                        break;
                    case '5':
                        return;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void VisualizarChamados()
        {
            Console.Clear();

            if (chamados.Count == 0)
            {
                Console.WriteLine("Nenhum chamado registrado.");
                return;
            }

            foreach (Chamado c in chamados)
            {
                int diasAbertos = (DateTime.Now - c.DataAbertura).Days;
                Console.WriteLine($"ID: {c.Id} | Título: {c.Titulo} | Equipamento: {c.Equipamento.Name} | Data Abertura: {c.DataAbertura.ToShortDateString()} | Dias em aberto: {diasAbertos}");
            }
        }

        public void RegistrarChamado()
        {
            Console.Clear();
            if (equipamentos.Count == 0)
            {
                Console.WriteLine("Cadastre pelo menos um equipamento antes de abrir um chamado.");
                return;
            }

            Chamado chamado = new Chamado();
            chamado.Id = contadorId++;

            Console.Write("Título do chamado: ");
            chamado.Titulo = Console.ReadLine();

            Console.Write("Descrição do chamado: ");
            chamado.Descricao = Console.ReadLine();

            Console.WriteLine("Selecione o equipamento pelo ID:");
            foreach (Equipamento e in equipamentos)
                Console.WriteLine($"ID: {e.Id} | Nome: {e.Name}");

            int idEquipamento = int.Parse(Console.ReadLine());
            Equipamento equipamentoSelecionado = equipamentos.Find(e => e.Id == idEquipamento);

            if (equipamentoSelecionado == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            chamado.Equipamento = equipamentoSelecionado;
            chamado.DataAbertura = DateTime.Now;

            chamados.Add(chamado);
            Console.WriteLine("Chamado registrado com sucesso!");
        }

        public void EditarChamado()
        {
            Console.Clear();
            VisualizarChamados();
            Console.Write("\nDigite o ID do chamado que deseja editar: ");
            int id = int.Parse(Console.ReadLine());

            Chamado chamado = chamados.Find(c => c.Id == id);
            if (chamado == null)
            {
                Console.WriteLine("Chamado não encontrado.");
                return;
            }

            Console.Write("Novo título: ");
            chamado.Titulo = Console.ReadLine();

            Console.Write("Nova descrição: ");
            chamado.Descricao = Console.ReadLine();

            Console.WriteLine("Selecione o novo equipamento pelo ID:");
            foreach (Equipamento e in equipamentos)
                Console.WriteLine($"ID: {e.Id} | Nome: {e.Name}");

            int idEquipamento = int.Parse(Console.ReadLine());
            Equipamento equipamentoSelecionado = equipamentos.Find(e => e.Id == idEquipamento);
            if (equipamentoSelecionado != null)
                chamado.Equipamento = equipamentoSelecionado;

            Console.WriteLine("Chamado atualizado com sucesso!");
        }

        public void ExcluirChamado()
        {
            Console.Clear();
            VisualizarChamados();
            Console.Write("\nDigite o ID do chamado que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Chamado chamado = chamados.Find(c => c.Id == id);
            if (chamado == null)
            {
                Console.WriteLine("Chamado não encontrado.");
                return;
            }

            chamados.Remove(chamado);
            Console.WriteLine("Chamado excluído com sucesso!");
        }
    }
}
