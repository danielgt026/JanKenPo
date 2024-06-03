using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiApp1.Model;
using MauiApp1.Enum;

namespace MauiApp1.ViewModel
{
    public partial class JanKenPoViewModel : ObservableObject
    {

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private Jogador jogador;

        [ObservableProperty]
        private Jogador maquina;

        [ObservableProperty]
        private Opcao _escolha;

        [ObservableProperty]
        private int pontuacao;

        [ObservableProperty] 
        private string resultado;

        [ObservableProperty]
        private string _result;

        [ObservableProperty]
        private string _enemyImage;

        [ObservableProperty]
        private string _playerImage;

        [ObservableProperty]
        private string _pontuacao;



        public ICommand MakeChoiceCommand { get; }

        public JanKenPoViewModel()
        {
            Jogador = new Jogador(Name);
            Maquina = new Jogador("Máquina");
            MakeChoiceCommand = new Command(MakeChoice);
        }

        private void MakeChoice()
        {
            Jogador.Nome = Name;
            Jogador.Escolha = Escolha;
            Maquina.Escolha = (Opcao)new Random().Next(0, 3);
            EnemyImage = $"{Maquina.Escolha}.png";
            PlayerImage = $"{Jogador.Escolha}.png";
            DetermineWinner();
            Pontuacao = Jogador.Pontuacao;
        }

        private void DetermineWinner()
        {
            if (Jogador.Escolha == Maquina.Escolha)
            {
                Jogador.Pontuacao++;
                Maquina.Pontuacao++;
                Result = "Empate!";
            }
            else if ((Jogador.Escolha == Opcao.PEDRA && Maquina.Escolha == Opcao.TESOURA) ||
                     (Jogador.Escolha == Opcao.PAPEL && Maquina.Escolha == Opcao.PEDRA) ||
                     (Jogador.Escolha == Opcao.TESOURA && Maquina.Escolha == Opcao.PAPEL))
            {
                Jogador.Pontuacao += 3;
                Result = $"{Jogador.Nome} Venceu!";
            }
            else
            {
                Maquina.Pontuacao += 3;
                Result = $"{Maquina.Nome} Venceu!";
            }

        }
    }
}
