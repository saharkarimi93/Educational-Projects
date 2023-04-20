using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toDoApiWPF.Models
{
    class Response
    {
        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }
        public Task task { get; set; }
        public List<Task> tasks { get; set; }
    }
}
