using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloTaskManager.Models
{
    internal class Task_Model :  INotifyPropertyChanged
    {
        private bool _isDone; //Завершена или нет
        private string _taskDescription; //Сама задача
        public DateTime CreationDate { get; set; } = DateTime.UtcNow; //Устанавливает текущее время добавления даты

        
        public bool IsDone //Состояние задачи (выполнена или нет, а также сама задача)
        {
            get { return _isDone; }
            set 
            {
                if (_isDone == value)
                    return;
                _isDone = value;
                OnPropertyChanged("IsDone");
            }
        }
        public string TaskDescription
        {
            get { return _taskDescription ; }
            set 
            {
                if (_taskDescription == value)
                    return;
                _taskDescription = value;
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
