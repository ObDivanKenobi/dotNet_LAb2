using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Lab2
{
    class ApplicationViewModel //: IDataErrorInfo
    {
        Battleship selectedShip;
        int filterMinCaliber;
        int filterMaxCaliber;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Battleship> Ships { get; set; }
        public ListCollectionView Collection { get; set; }

        public Battleship SelectedShip
        {
            get { return selectedShip; }
            set
            {
                //selectedShip = value;
                if (value != null)
                {
                    selectedShip = value;
                    OnPropertyChanged("SelectedShip");
                }
            }
        }

        public int FilterMinCaliber
        {
            get { return filterMinCaliber; }
            set
            {
                filterMinCaliber = value;
                SetStatuses(filterMinCaliber, filterMaxCaliber);
            }
        }

        public int FilterMaxCaliber
        {
            get { return filterMaxCaliber; }
            set
            {
                filterMaxCaliber = value;
                SetStatuses(filterMinCaliber, filterMaxCaliber);
            }
        }

        public ApplicationViewModel()
        {
            Ships = new ObservableCollection<Battleship>
            {
                new Battleship { Class = "Iowa", Name = "Iowa", Type = "Линкор", Country = "США", Launched = 1943, Caliber = 403, NumGuns = 9 },
                new Battleship { Class = "Iowa", Name = "Missouri", Type = "Линкор", Country = "США", Launched = 1944, Caliber = 403, NumGuns = 9 },
                new Battleship { Class = "Omaha", Name = "Omaha", Type = "Крейсер", Country = "США", Launched = 1920, Caliber = 152, NumGuns = 12 },
                new Battleship { Class = "Yamato", Name = "Yamato", Type = "Линкор", Country = "Япония", Launched = 1940, Caliber = 460, NumGuns = 9 },
                new Battleship { Class = "Omaha", Name = "Concord", Type = "Крейсер", Country = "США", Launched = 1921, Caliber = 152, NumGuns = 12 },
                new Battleship { Class = "Omaha", Name = "Мурманск", Type = "Крейсер", Country = "СССР", Launched = 1920, Caliber = 152, NumGuns = 12 },
                new Battleship { Class = "Pensacola", Name = "Sault-Lake-City", Type = "Крейсер", Country = "США", Launched = 1929, Caliber = 203, NumGuns = 8 },
                new Battleship { Class = "Kagero", Name = "Isokaze", Type = "Эсминец", Country = "Япония", Launched = 1939, Caliber = 127, NumGuns = 6 },
                new Battleship { Class = "Диана", Name = "Аврора", Type = "Крейсер", Country = "СССР", Launched = 1900, Caliber = null, NumGuns = 8 },
                new Battleship { Class = "Renown", Name = "Renown", Type = "Линейный крейсер", Country = "Британия", Launched = 1916, Caliber = 381, NumGuns = 6 },
                new Battleship { Class = "King George V", Name = "Duke of York", Type = "Линкор", Country = "Британия", Launched = 1939, Caliber = 356, NumGuns = 10 },
                new Battleship { Class = "Bismarck", Name = "Tirpitz", Type = "Линкор", Country = "Германия", Launched = 1939, Caliber = 380, NumGuns = 8 },
                new Battleship { Class = "Проект 20И", Name = "Ташкент", Type = "Эсминец", Country = "СССР", Launched = 1937, Caliber = 130, NumGuns = 6 },
                new Battleship { Class = "Kongo", Name = "Kirishima", Type = "Линейный крейсер", Country = "Япония", Launched = 1913, Caliber = 356, NumGuns = 8 },
                new Battleship { Class = "Проект 30", Name = "Огневой", Type = "Эсминец", Country = "СССР", Launched = 1940, Caliber = 130, NumGuns = 4 },
                new Battleship { Class = "Севастополь", Name = "Петропавловск/Марат", Type = "Линкор", Country = "СССР", Launched = 1911, Caliber = 305, NumGuns = 12 }
            };
            Collection = new ListCollectionView(Ships);
            Collection.GroupDescriptions.Add(new PropertyGroupDescription("Type"));
            Collection.IsLiveGrouping = true;
            selectedShip = null;
        }

        void SetStatuses(int caliber1, int caliber2)
        {
            foreach (Battleship b in Ships)
            {
                if (caliber2 < caliber1 || caliber1 < 0 || caliber2 <= 0 || b.Caliber == null)
                    b.State = Battleship.ComparationState.Incorrect;
                else if (b.Caliber < caliber1) b.State = Battleship.ComparationState.Less;
                else if (b.Caliber <= caliber2) b.State = Battleship.ComparationState.In;
                else b.State = Battleship.ComparationState.More;
            }
        }

        /// <summary>
        /// Сброс "выделения"
        /// </summary>
        public void ResetStatuses()
        {
            foreach (Battleship b in Ships)
            {
                b.State = Battleship.ComparationState.Incorrect;
            }
        }

        /// <summary>
        /// Для корректного отображения панели редактирования
        /// </summary>
        Visibility IsRedactPanelVisible
        {
            get
            {
                if (selectedShip != null)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        #region IDataErrorInfo
        //public string Error
        //{
        //    get
        //    {
        //        return string.Empty;
        //    }
        //}

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        string error = String.Empty;
        //        switch (columnName)
        //        {
        //            case "FilterMinCaliber":
        //                if (FilterMinCaliber < 0)
        //                    error = "Отрицательный калибр.";
        //                else if (FilterMinCaliber > filterMaxCaliber)
        //                    error = "Минимальный калибр больше максимального.";
        //                break;
        //            case "FilterMaxCaliber":
        //                if (FilterMaxCaliber < 0)
        //                    error = "Отрицательный калибр.";
        //                else if (FilterMinCaliber > filterMaxCaliber)
        //                    error = "Минимальный калибр больше максимального.";
        //                break;
        //            default: break;
        //        }
        //        return error;
        //    }
        //}
        #endregion

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
