using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Form
{
    class VM : ViewModelBase
    {
        private string _name;
        private string _gender;
        private DateTime _date;

        public RelayCommand SaveDataCommand { get; }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
                RaisePropertyChanged(() => NameCorrect);
            }
        }
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                RaisePropertyChanged(() => Gender);
                RaisePropertyChanged(() => GenderCorrect);
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                RaisePropertyChanged(() => Date);
                RaisePropertyChanged(() => DateCorrect);
            }
        }
        public bool NameCorrect
        {
            get
            {
                return Name.Length >= 3 && Regex.IsMatch(Name, @"^[\p{L}]+ [\p{L}]+$");
            }
        }
        public bool GenderCorrect
        {
            get
            {
                return Gender.Length >= 3 && Regex.IsMatch(Gender, @"^[\p{L}]+$");
            }
        }
        public bool DateCorrect
        {
            get
            {
                return Date != DateTime.MinValue;
            }
        }

        public VM()
        {
            Name = "";
            Gender = "";
            Date = DateTime.Now;

            SaveDataCommand = new RelayCommand(SaveData);
        }

        public bool CheckData()
        {
            if (!NameCorrect || !GenderCorrect || !DateCorrect) return false;
            return true;
        }

        public void SaveData()
        {
            if (!CheckData()) return;
            Person p = new Person(Name, Gender, Date);
            Debug.WriteLine(p);
        }
    }
}
