using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace App4.ViewModels
{
    public class CountViewModel : BaseViewModel
    {
        int contador;
        ICommand buttonClickCommand;
        ICommand resetClickCommand;
        string countConverted;

        public CountViewModel()
        {
            contador = 0;
        }

        public int Contador {
            get => contador;
            set
            {
                if (value == contador) return;
                contador = value;
                CountConverted = $"Clickeado {contador} veces";
                OnPropertyChanged(nameof(CountConverted));
            }
        }

        public string CountConverted
        {
            get => countConverted;
            set
            {
                if (string.Equals(countConverted, value)) return;
                countConverted = value;
                OnPropertyChanged();
            }
        }

        public ICommand ButtonClickCommand
        {
            get => buttonClickCommand ?? (buttonClickCommand = new Command(ButtonClickAction));
        }

        public ICommand ResetClickCommand
        {
            get => resetClickCommand ?? (resetClickCommand = new Command(ResetClickAction));
        }

        private void ResetClickAction()
        {
            Contador = 0;
            CountConverted = $"Contador reseteado";
        }

        private void ButtonClickAction()
        {
            Contador++;
        }
    }
}
