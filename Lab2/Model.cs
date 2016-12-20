using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Battleship : INotifyPropertyChanged
    {
        public static int FirstIronBattleship = 1812;

        public static ObservableCollection<string> TypeList = new ObservableCollection<string>
        { "Эсминец", "Крейсер", "Линейный крейсер", "Линкор"};
        public static ObservableCollection<string> CountryList { get; set; } = new ObservableCollection<string>
        { "США", "СССР", "Япония", "Британия"};

        string name;
        string shipClass;
        string type;
        string country;
        int? launched;
        int? numGuns;
        int? caliber;
        ComparationState state = ComparationState.Incorrect;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public IEnumerable<string> Types
        {
            get
            {
                return TypeList;
            }
        }

        public string Class
        {
            get { return shipClass; }
            set
            {
                if (value == "")
                    shipClass = null;
                else
                    shipClass = value;
                OnPropertyChanged("Class");
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                if (value == "")
                    type = null;
                else
                    type = value;
                OnPropertyChanged("Type");
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                if (value == "")
                    country = null;
                else
                    country = value;
                OnPropertyChanged("Country");
            }
        }

        public int? Launched
        {
            get { return launched; }
            set
            {
                launched = value;
                OnPropertyChanged("Launched");
            }
        }

        public int? NumGuns
        {
            get { return numGuns; }
            set
            {
                numGuns = value;
                OnPropertyChanged("NumGuns");
            }
        }

        public int? Caliber
        {
            get { return caliber; }
            set
            {
                caliber = value;
                OnPropertyChanged("Caliber");
            }
        }

        public ComparationState State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }

                public override string ToString()
        {
            return Name + " " + Country;
        }

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public enum ComparationState
        {
            Less = -1,
            In = 0,
            More = 1,
            Incorrect = -2
        }
    }
}
