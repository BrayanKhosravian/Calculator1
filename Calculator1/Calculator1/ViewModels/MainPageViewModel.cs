using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator1.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        private string entry_Number1;
        private string entry_Number2;
        private string label_Operation;
        private string label_Result;

        private char _operation;

        public ICommand Button_Plus { get; private set; }
        public ICommand Button_Minus { get; private set; }
        public  ICommand Button_Divid { get; private set; }
        public ICommand Button_Multiply { get; private set; }


        public MainPageViewModel()
        {
            Button_Plus = new Command(x =>
            {
                _operation = '+';
                base.OnPropertyChanged(nameof(Label_Operation));
                base.OnPropertyChanged(nameof(Label_Result));
            });
            Button_Minus = new Command(x =>
            {
                _operation = '-';
                base.OnPropertyChanged(nameof(Label_Operation));
                base.OnPropertyChanged(nameof(Label_Result));
            });
            Button_Divid = new Command(x =>
            {
                _operation = '/';
                base.OnPropertyChanged(nameof(Label_Operation));
                base.OnPropertyChanged(nameof(Label_Result));
            });
            Button_Multiply = new Command(x =>
            {
                _operation = '*';
                base.OnPropertyChanged(nameof(Label_Operation));
                base.OnPropertyChanged(nameof(Label_Result));
            });
        }

        public string Entry_Number1
        {
            get => entry_Number1;
            set
            {
                if (entry_Number1 != value) entry_Number1 = value;
                else return;

                base.OnPropertyChanged();
                base.OnPropertyChanged(nameof(Label_Result));
            }
        }

        public string Entry_Number2
        {
            get => entry_Number2;
            set
            {
                if (entry_Number2 != value) entry_Number2 = value;
                else return;

                base.OnPropertyChanged();
                base.OnPropertyChanged(nameof(Label_Result));
            }
        }

        
        public string Label_Operation
        {
            get => _operation.ToString();
            set
            {
                if (label_Operation != value) label_Operation = value;
                else return;

                base.OnPropertyChanged();
            }
        }
        
        public string Label_Result
        {
            get
            {
                if (entry_Number1 != null && entry_Number2 != null)
                {
                    if (_operation.Equals('+')) return (double.Parse(entry_Number1) + double.Parse(entry_Number2)).ToString();
                    else if (_operation.Equals('-')) return (double.Parse(entry_Number1) - double.Parse(entry_Number2)).ToString();
                    else if (_operation.Equals('/')) return (double.Parse(entry_Number1) / double.Parse(entry_Number2)).ToString();
                    else if (_operation.Equals('*')) return (double.Parse(entry_Number1) * double.Parse(entry_Number2)).ToString();
                }
                return "0";
            }
            set
            {
                if (label_Result != value) label_Result = value;
                else return;

                base.OnPropertyChanged();
            }
        }
    }
}
