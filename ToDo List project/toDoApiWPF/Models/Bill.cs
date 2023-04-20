using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace toDoApi.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string DueDate { get; set; }
        public decimal bankBalance { get; set; }
    }
}
