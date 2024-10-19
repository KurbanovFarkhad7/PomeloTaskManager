using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloTaskManager.Models
{
    internal class Task_Explorer_Model : INotifyPropertyChanged
    {
        private string _tasks; //Сама задача

        public string Tasks
        {
            get { return _tasks; }
            set
            {
                if (_tasks == value)
                    return;
                _tasks = value;
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "") //метод, который не выходит из класса, виртуал - позволяет унаследоваться от класса на измененние
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //реагирование на пустоту строки
        }
    }
}
