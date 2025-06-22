using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASODotNetTrainingBatch1.Domain.Models
{
    public class ResponseModel
    {
        public ResponseModel(bool issuccess, string message, object? data = null)
        {
            IsSuccess = issuccess;
            Message = message;
            Data = data;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        //public ResponseModel()
        //{
        //    IsSuccess = true;
        //    Message = string.Empty;
        //    Data = null;
        //}
        
    }
}
