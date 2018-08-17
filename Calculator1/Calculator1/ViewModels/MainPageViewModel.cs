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
        public ICommand Command_AddNumber { get; private set; }
        public ICommand Command_AddOperator { get; private set; }
        public ICommand Command_Clear { get; private set; }
        public ICommand Command_Delete { get; private set; }

        // Ctor ---------------------------------------------------------------
        public MainPageViewModel()
        {
            Command_AddNumber = new Command<string>(
                execute: (string param) =>
                {
                    Entry_Input += param;
                    RefreshCanExecutes();
                });

            Command_AddOperator = new Command<string>(
                execute: (string param) =>
                {
                    Entry_Input += param;
                    RefreshCanExecutes();
                },
                canExecute: (string param) =>
                {
                    if (string.IsNullOrEmpty(Entry_Input)) return false;
                    if (char.IsDigit(Entry_Input[Entry_Input.Length - 1])) return true;
                    else return false;
                });


            Command_Clear = new Command(
                execute: () =>
                {
                    Entry_Input = string.Empty;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    if (string.IsNullOrEmpty(Entry_Input)) return false;
                    else return true;
                });

            Command_Delete = new Command(
                execute: () =>
                {
                    if (!string.IsNullOrEmpty(entry_Input) && entry_Input[entry_Input.Length - 1] == ' ')
                    {
                        Entry_Input = Entry_Input.Remove(Entry_Input.Length - 3, 3);
                    }
                    else if (!string.IsNullOrEmpty(entry_Input))
                        Entry_Input = Entry_Input.Remove(entry_Input.Length - 1, 1);

                    RefreshCanExecutes();
                }, 
                canExecute: () =>
                {
                    if (string.IsNullOrEmpty(Entry_Input)) return false;
                    else return true;
                });

        } // ctor End ----------------------------------------------------------------------

        
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)] // this method is only executed inline // this attribute can be delted its just for performance
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

        private void RefreshCanExecutes()
        {
            ((Command)Command_AddNumber).ChangeCanExecute();
            ((Command)Command_AddOperator).ChangeCanExecute(); 
            ((Command)Command_Clear).ChangeCanExecute();
            ((Command)Command_Delete).ChangeCanExecute();
        }
    }
}
