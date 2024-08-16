using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconBuilderAI.Domain.Common
{
    public class Response<T>
    {
        public Response(T data) 
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = new List<ErrorDto>();
            Data = data;
        }

        public Response(T data, string message)
        {
            Succeeded = true;
            Message = message;
            Errors = new List<ErrorDto>();
            Data = data;
        }

        public Response(string message, List<ErrorDto> errors)
        {
            Succeeded = false;
            Message = message;
            Errors = errors;
            Data = default;
        }

        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = new List<ErrorDto>();
            Data = default;
        }


        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public IEnumerable<ErrorDto> Errors { get; set; }
        public T Data { get; set; }
    }
}
