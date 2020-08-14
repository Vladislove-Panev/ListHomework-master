using ListHomework.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace ListHomework.ViewModels
{
    public class MainPageViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<Animals> _animals;
        public ObservableCollection<Animals> Animals
        {
            get
            {
                return _animals;
            }
            set
            {
                _animals = value;
                OnPropertyChanged("Animals");
            }
        }
        public MainPageViewModel()
        {
            GetAnimalsList();
        }

        private async void GetAnimalsList()
        {
            List<Animals> list = new List<Animals>();
            using (var stream = await FileSystem.OpenAppPackageFileAsync("Animals.json"))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string json = await reader.ReadToEndAsync();

                    list = JsonConvert.DeserializeObject<List<Animals>>(json);
                }
            }
            Animals = new ObservableCollection<Animals>(list);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
