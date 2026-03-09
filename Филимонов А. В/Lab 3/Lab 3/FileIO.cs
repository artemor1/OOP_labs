using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Lab_3
{
    public class File_IO_Methods
    {
        public static int SaveDataToTxtFile(List<double> data, string path)
        {
            try
            {
                Debug.WriteLine($"[FileIO.SaveDataToTxtFile] path={path}, dataCount={(data == null ? 0 : data.Count)}");
                var str = ""; // Контейнер для накопления текстовой информации 
                foreach (var d in data)
                {
                    str += d.ToString() + "\n";
                }
                using (var sw = new StreamWriter(path)) //Создание потока данных 
                {
                    sw.Write(str);
                }
                return data.Count + 1; //Возврат количества записанных строк 
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return 0;
        }
        public static List<double> LoadDataFromTxtFile(string path)
        {
            try
            {
                Debug.WriteLine($"[FileIO.LoadDataFromTxtFile] path={path}");
                var data = new List<double>(); //Создание контейнера для результата 
                using (var sr = new StreamReader(path)) //Создание потока для чтения  
                {
                    double d = 0; //временная переменная 
                    while (!sr.EndOfStream) //Чтение, пока не дойдет до конца файла 
                    {
                        var s = sr.ReadLine();
                        s = s.Replace('.', ','); //замена символов, так как Parse не может преобразовать данные с точкой
                        if (!double.TryParse(s, out d)) continue;
                        data.Add(d); //добавление данных в список 
                    }

                }
                Debug.WriteLine($"[FileIO.LoadDataFromTxtFile] loadedCount={data.Count}");
                return data;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public static int SaveDataToBinFile(List<double> data, string path)
        {
            try
            {
                Debug.WriteLine($"[FileIO.SaveDataToBinFile] path={path}, dataCount={(data == null ? 0 : data.Count)}");
                //Создание потока записи данных 
                using (var sw = new BinaryWriter(File.Create(path)))
                {
                    foreach (var d in data)
                    {
                        sw.Write(d);
                    }
                }
                return data.Count; //Возврат количества записанных значений 
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return 0;
        }
        public static List<double> LoadDataFromBinFile(string path)
        {
            try
            {
                Debug.WriteLine($"[FileIO.LoadDataFromBinFile] path={path}");
                //Создание контейнера для вывода результата 
                var data = new List<double>();
                //Создание потока для чтения данных 
                using (var sr = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    double d = 0; //временная переменная 
                    var count = sr.BaseStream.Length / sizeof(double);
                    //Вычисление количества значений в файле 
                    int i = 0;
                    while (i < count) //цикл чтения, пока не дойдет до конца файла 
                    {
                        d = sr.ReadDouble();
                        data.Add(d); //добавление данных в список 
                        i++;
                    }
                }
                Debug.WriteLine($"[FileIO.LoadDataFromBinFile] loadedCount={data.Count}");
                return data;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return null;
        }


    }
}
