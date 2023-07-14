using _9_07_2023_Planner.Models.ViewPanelTemplate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _9_07_2023_Planner.DataHandlers
{
    internal class DataSerializer
    {
        ObservableCollection<TaskGroupTemplate> _groupList = new ObservableCollection<TaskGroupTemplate>();
        public DataSerializer() { }
        public DataSerializer(ObservableCollection<TaskGroupTemplate> groupList)
        {
            _groupList = groupList;
        }

        private async void SerializeHelper<T>(ObservableCollection<T> collection, string filePath)
        {
            try
            {
                if (File.Exists(filePath)) { File.Delete(filePath); }
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    await JsonSerializer.SerializeAsync(fs, collection);

                    //TaskGroupPanel_UserControl userControl = new TaskGroupPanel_UserControl();
                    //userControl.DataContext= new 
                }
            }
            catch { return; }
        }
        public void JsonSerialization<T>(ObservableCollection<T> collection, string directory)
        {
            try
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                if (collection.Count > -1)
                {
                    if (collection is ObservableCollection<TaskGroupTemplate>)
                    {
                        string filePath = directory + "\\" + Properties.Resources.GroupListFileName;
                        SerializeHelper(collection, filePath);
                        //MessageBox.Show(filePath);
                    }

                }

            }
            catch (Exception)
            {

                return;
            }
        }

        public ObservableCollection<TaskGroupTemplate> JsonDeserialization(string directory)
        {
            try
            {
                string filePath = directory + "\\" + Properties.Resources.GroupListFileName;
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    _groupList = JsonSerializer.Deserialize<ObservableCollection<TaskGroupTemplate>>(fs);
                    if (_groupList == null) _groupList = new ObservableCollection<TaskGroupTemplate>();
                }
            }
            catch (Exception)
            {

                return _groupList;
            }

            return _groupList;
        }
        //public async Task<ObservableCollection<TaskGroupPanelModel>> JsonDeserialization(string directory)
        //{
        //    try
        //    {
        //        string filePath = directory + "\\" + Properties.Resources.GroupListFileName;
        //        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        //        {
        //            _groupList = await JsonSerializer.DeserializeAsync<ObservableCollection<TaskGroupPanelModel>>(fs);
        //            if (_groupList == null) _groupList = new ObservableCollection<TaskGroupPanelModel>();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        return _groupList;
        //    }

        //    return _groupList;
        //}
    }
}
