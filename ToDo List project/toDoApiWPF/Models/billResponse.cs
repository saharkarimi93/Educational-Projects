

using System.Collections.Generic;

namespace toDoApi.Models
{
    public class billResponse
    {
        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public Bill bll { get; set; }
        public List<Bill> Bills { get; set; }
    }
}
