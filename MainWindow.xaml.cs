using PomeloTaskManager.Models;
using PomeloTaskManager.Services;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PomeloTaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<Task_Model> _taskDataList; //по сути, список из модели, которая просто позволяет делать много задач

        private readonly string PATH = $"{Environment.CurrentDirectory}\\taskDataList.json";
        private FileIOService _fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);

            try //чтобы не было ситуаций вызова пустоты, из-за которой ошибки, не будет доходить дальше
            {
                _taskDataList = _fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //сообщение о неудачи
                Close();
            }

            

            /*_taskDataList = new BindingList<Task_Model>()
            { //пример создания собственных колонок
                new Task_Model() {TaskDescription = "Текст"}, //передали запись в геттер
                new Task_Model() {TaskDescription = "Текст"}

            };*/

            PTaskManager.ItemsSource = _taskDataList; //сохранение изменений в лист
            _taskDataList.ListChanged += _taskDataList_ListChanged; //событие, которое возникает при изменении чего-то в списке
        }

        private void _taskDataList_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted  
                || e.ListChangedType == ListChangedType.ItemChanged) //отслеживание записи (например, если добавляем чет, то попадаем в обработчик ItemAdded)
            {
                try //чтобы не было ситуаций вызова пустоты, из-за которой ошибки, не будет доходить дальше
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); //сообщение о неудачи
                    Close();
                }
            }
        }
    }
}