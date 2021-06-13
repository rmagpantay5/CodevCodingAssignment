using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingAssignment.Models;
using CodingAssignment.Services;
using CodingAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodingAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {

        private readonly IFileManagerService _fileManger;

        public FileController(IFileManagerService fileManager)
        {
            _fileManger = fileManager;
        }

        [HttpGet]
        public DataFileModel Get()
        {

           return _fileManger.GetData();
        }

        [HttpGet("{id}")]
        public DataModel GetById(int id)
        {
            return _fileManger.GetDataById(id);
        }

        [HttpPost]
        public DataFileModel Post(DataModel model)
        {

            if (_fileManger.Insert(model))
            {
                return _fileManger.GetData();
            };

            return null;

        }

        [HttpPut]
        public DataFileModel Put(DataModel model, int id)
        {

            if (_fileManger.Update(model, id))
            {
                return _fileManger.GetData();
            };

            return null;

        }

        [HttpDelete]
        public DataFileModel Delete(int id)
        {
            if (_fileManger.Delete(id))
            {
                return _fileManger.GetData();
            };

            return null;
        }
    }
}
