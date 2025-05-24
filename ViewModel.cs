using MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LINQ_in_WPF
{
    class ViewModel : INotifyPropertyChanged
    {
        //数据
        private Model model = new Model();
        public string InputWord
        {
            get;
            set;
        }

        public List<string> Words
        {
            get => model.WordCollection;
        }

        public string[] HotWords
        {
            get => model.HotWordsList;
            set
            {
                model.HotWordsList = value;
                OnPropertyChanged(nameof(outputWord1));
                OnPropertyChanged(nameof(outputWord2));
                OnPropertyChanged(nameof(outputWord3));
            }
        }

        public string outputWord1 { get; set; }
        public string outputWord2 { get; set; }
        public string outputWord3 { get; set; }



        //连接前端,后端数据修改时,通知前端修改
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SearchCommand
        {
            get => new RelayCommand(AddWord);
        }

        public void AddWord()
        {
            Words.Add(InputWord);
            RefreshWordList();
        }

        private void RefreshWordList()
        {
            var result = Words
                        .GroupBy(a => a)
                        .OrderByDescending(a => a.Count())
                        .Take(3)
                        .Select(a => a.Key)
                        .ToArray();

            outputWord1 = result[0];
            outputWord2 = result.Length > 1 ? result[1] : " ";
            outputWord3 = result.Length > 2 ? result[2] : " ";
            HotWords = result;
        }
    }
}
