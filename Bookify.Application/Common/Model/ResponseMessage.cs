using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.Common.Model
{
    public class ResponseMessage<T>
    {
        public string Status { get; set; }
        public string Message { get; set;}
        public T Data { get; set; }
    }
}
