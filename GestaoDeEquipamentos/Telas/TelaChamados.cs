using GestaoDeEquipamentos.Entities;
using GestaoDeEquipamentos.Repositorio;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GestaoDeEquipamentos.Telas
{
    internal class TelaChamados : Registro<Chamado>
    {
        private List<Equipamento> equipamentos;

        public TelaChamados(List<Equipamento> equipamentos, string entidade) : base(entidade)
        {
            this.equipamentos = equipamentos;
            this.list = new List<Chamado>();
        }

        public void MenuChamados()
        {
            while (true)
            {
                switch (ApresentarMenu())
                {
                    case '1':
                        Cadastrar();
                        break;
                    case '2':
                        Visualizar();
                        break;
                    case '3':
                        Editar();
                        break;
                    case '4':
                        Excluir();
                        break;
                    case '5':
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void Cadastrar()
        {
            Console.Clear();
            if (equipamentos.Count == 0)
            {
                Console.WriteLine("Cadastre pelo menos um equipamento antes de abrir um chamado.");
                return;
            }

            Console.Write("Título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Descrição do chamado: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Selecione o equipamento pelo ID:");
            foreach (Equipamento e in equipamentos)
                Console.WriteLine($"ID: {e.ID} | Nome: {e.Nome}");

            if (!int.TryParse(Console.ReadLine(), out int idEquipamento))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Equipamento equipamentoSelecionado = equipamentos.Find(e => e.ID == idEquipamento);
            if (equipamentoSelecionado == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            Chamado chamado = new Chamado(
                id: list.Count + 1,
                titulo: titulo,
                descricao: descricao,
                equipamento: equipamentoSelecionado,
                dataAbertura: DateTime.Now
            );

            Adicionar(chamado); // herdado
            Console.WriteLine("Chamado registrado com sucesso!");
        }

        private void Visualizar()
        {
            Console.Clear();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhum chamado registrado.");
                return;
            }

            foreach (Chamado c in list)
            {
                int diasAbertos = (DateTime.Now - c.DataAbertura).Days;
                Console.WriteLine($"ID: {c.Id} | Título: {c.Titulo} | Equipamento: {c.Equipamento.Nome} | Data Abertura: {c.DataAbertura:dd/MM/yyyy} | Dias em aberto: {diasAbertos}");
            }
        }

        private void Editar()
        {
            Console.Clear();
            Visualizar();

            Console.Write("\nDigite o ID do chamado que deseja editar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Chamado chamado = list.Find(c => c.Id == id);
            if (chamado == null)
            {
                Console.WriteLine("Chamado não encontrado.");
                return;
            }

            Console.Write("Novo título: ");
            string titulo = Console.ReadLine();

            Console.Write("Nova descrição: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Selecione o novo equipamento pelo ID:");
            foreach (Equipamento e in equipamentos)
                Console.WriteLine($"ID: {e.ID} | Nome: {e.Nome}");

            if (!int.TryParse(Console.ReadLine(), out int idEquipamento))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Equipamento equipamentoSelecionado = equipamentos.Find(e => e.ID == idEquipamento);
            if (equipamentoSelecionado == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            chamado.AtualiazaDados(titulo, descricao, equipamentoSelecionado);
            Console.WriteLine("Chamado atualizado com sucesso!");
        }

        private void Excluir()
        {
            Console.Clear();
            Visualizar();

            Console.Write("\nDigite o ID do chamado que deseja excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Chamado chamado = list.Find(c => c.Id == id);
            if (chamado == null)
            {
                Console.WriteLine("Chamado não encontrado.");
                return;
            }

            Remover(chamado); 
            Console.WriteLine("Chamado excluído com sucesso!");
        }
    }
}
