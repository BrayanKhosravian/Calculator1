using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Calculator1.Extentions;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace Calculator1.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        public ICommand Button_Plus { get; private set; }
        public ICommand Button_Minus { get; private set; }
        public ICommand Button_Divid { get; private set; }
        public ICommand Button_Multiply { get; private set; }

        public ICommand Button_Delete { get; private set; }
        public ICommand Button_Clear { get; private set; }

        public ICommand Button_One { get; private set; } 
        public ICommand Button_Two { get; private set; }
        public ICommand Button_Three { get; private set; }
        public ICommand Button_Four  { get; private set; }
        public ICommand Button_Five  { get; private set; }
        public ICommand Button_Six   { get; private set; }
        public ICommand Button_Seven { get; private set; }
        public ICommand Button_Eight { get; private set; }
        public ICommand Button_Nine  { get; private set; }
        public ICommand Button_Zero  { get; private set; }

        public MainPageViewModel()
        {
            Button_Plus = new Command(x => Entry_Input += " + ");
            Button_Minus = new Command(x => Entry_Input += " - ");
            Button_Divid = new Command(x => Entry_Input += " / ");
            Button_Multiply = new Command(x => Entry_Input += " * ");

            Button_Clear = new Command(x => Entry_Input = string.Empty);
            Button_Delete = new Command(x =>
            {
                if (!string.IsNullOrEmpty(entry_Input) && entry_Input[entry_Input.Length - 1] == ' ')
                {
                    Entry_Input = Entry_Input.Remove(Entry_Input.Length - 3, 3);
                }
                else if (!string.IsNullOrEmpty(entry_Input))
                    Entry_Input = Entry_Input.Remove(entry_Input.Length - 1, 1);
            });

            Button_One = new Command<string>(x => AddNumb("1"));
            Button_Two = new Command(x => Entry_Input += "2");
            Button_Three = new Command(x => Entry_Input += "3");
            Button_Four = new Command(x => Entry_Input += "4");
            Button_Five = new Command(x => Entry_Input += "5");
            Button_Six = new Command(x => Entry_Input += "6");
            Button_Seven = new Command(x => Entry_Input += "7");
            Button_Eight = new Command(x => Entry_Input += "8");
            Button_Nine = new Command(x => Entry_Input += "9");
            Button_Zero = new Command(x => Entry_Input += "0");

            void AddNumb(string numb)
            {
                Entry_Input += numb;
            }

        } // ctor End

        private void SetOutput(string entry)
        {
            MathParser mathParser = new MathParser();
            if (!string.IsNullOrEmpty(entry) && char.IsDigit(entry[entry.Length - 1]))
            {
                Label_Output = mathParser.Parse(entry).ToString();
            }
            else
            {
                Label_Output = "Error";
            }
        }
        
        private string label_Output;
        public string Label_Output
        {
            get => label_Output;
            set
            {
                if (label_Output != value) label_Output = value;
                else return;

                base.OnPropertyChanged();
            }
        }

        private string entry_Input;
        public string Entry_Input
        {
            get => entry_Input;
            set
            {
                if (entry_Input != value) entry_Input = value;
                else return;

                SetOutput(Regex.Replace(entry_Input, " ", ""));

                base.OnPropertyChanged();
            }
        }

        private bool CanExecute(object parameter)
        {
            var i = parameter as string;
            if (!string.IsNullOrEmpty(entry_Input)) return true;
            else return false;
        }
    }
}
