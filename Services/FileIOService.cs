using Newtonsoft.Json;
using PomeloTaskManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PomeloTaskManager.Services
{
    internal class FileIOService
    {
        public readonly string PATH;

        public FileIOService(string path) //идентафикация пути для сохраненных и загруженных данных
        {
            PATH = path;
        }

        public BindingList<Task_Model> LoadData()
        {
            var fileExist = File.Exists(PATH); //проверка на существование файла, результат в bool переменной
            if (!fileExist) //Если не существует, то создает такой файл
            {
                File.CreateText(PATH).Dispose(); //Указываем путь, а затем Dispose - освобождаем ресурсы
                return new BindingList<Task_Model>();
            }
            using (var reader = File.OpenText(PATH)) //если существует, то выполнится это
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Task_Model>>(fileText);
                //преобразует json файл в коллекцию, где хранятся данные
            }
        }

        public void SaveData(object taskDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH)) //определили Класс записи файлов
            {
                string output = JsonConvert.SerializeObject(taskDataList); //передаем список в файл
                writer.Write(output); //записываем
            }
        }
    }
}
