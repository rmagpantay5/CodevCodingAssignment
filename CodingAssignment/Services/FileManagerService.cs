using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodingAssignment.Models;
using CodingAssignment.Services.Interfaces;
using Newtonsoft.Json;

namespace CodingAssignment.Services
{
    public class FileManagerService: IFileManagerService
    {
        private const string JSON_FILE = "./AppData/DataFile.json";
        private DataFileModel _data;

        public FileManagerService()
        {
            _data = ReadFromFile();
        }

        public DataFileModel GetData()
        {
            return _data;
        }

        public bool Insert(DataModel model)
        {

            DataModel dm = _data.Data.FirstOrDefault(x => x.Id == model.Id);

            if (dm != null || String.IsNullOrEmpty(model.Id.ToString()))
            {
                throw new Exception("An item with the same id already exists");

            } else
            {
                _data.Data.Add(model);

                if (WriteToFile())
                {
                    _data = ReadFromFile();
                    return true;
                }

            }


            return false;
        }

        public bool Update(DataModel model, int id)
        {

            if(id != model.Id)
            {
                throw new Exception();
            }

            DataModel tDataModel = _data.Data.FirstOrDefault(x => x.Id == id);

            if(tDataModel != null)
            {
                tDataModel.Details = model.Details;

                if (WriteToFile())
                {
                    _data = ReadFromFile();
                    return true;
                }
            }

            return false;

        }

        public bool Delete(int id)
        {

            DataModel tDataModel = _data.Data.FirstOrDefault(x => x.Id == id);

            if (tDataModel != null)
            {
                _data.Data.Remove(tDataModel);

                if (WriteToFile())
                {
                    _data = ReadFromFile();
                    return true;
                }

            }

            return false;

        }

        public DataModel GetDataById(int id)
        {
           return GetData().Data.FirstOrDefault(x => x.Id == id);
        }

        private bool WriteToFile()
        {
            string json = JsonConvert.SerializeObject(_data);

            if (!String.IsNullOrEmpty(json))
            {
                File.WriteAllText(JSON_FILE, json);
                return true;
            }

            return false;
        }

        private DataFileModel ReadFromFile()
        {
           return JsonConvert.DeserializeObject<DataFileModel>(File.ReadAllText(JSON_FILE));
        }
    }
}
