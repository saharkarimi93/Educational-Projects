using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using toDoApi.Models;


namespace toDoApi.Controllers
{

    [Route("api/[controller]")]
   [ApiController]
    public class billController:ControllerBase
    {
        private readonly IConfiguration _configuration;

        public billController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllBills")]
        public billResponse GetAllBills()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            billResponse response = new billResponse();
            BillApplication apl = new BillApplication();
            response = apl.GetAllBills(con);
            return response;
        }

        [HttpGet]
        [Route("GetAllBillsByID/{id}")]

        public billResponse GetAllBillsByID(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            billResponse response = new billResponse();
            BillApplication apl = new BillApplication();
            response = apl.GetAllBillsByID(con, id);
            return response;
        }

        [HttpPost]
        [Route("AddBill")]
        public billResponse AddBill(Bill bill)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            billResponse response = new billResponse();
            BillApplication apl = new BillApplication();
            response = apl.AddBill(con, bill);
            return response;
        }

        [HttpPut]
        [Route("UpdateBill")]
        public billResponse UpdateBill(Bill bill)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            billResponse response = new billResponse();
            BillApplication apl = new BillApplication();
            response = apl.UpdateBill(con, bill);
            return response;
        }

        [HttpDelete]
        [Route(" DeleteBill/{Id}")]
        public billResponse DeleteBill(int Id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            billResponse response = new billResponse();
            BillApplication apl = new BillApplication();
            response = apl.DeleteBill(con, Id);
            return response;
        }

        [HttpPut]
        [Route("PayBill/{id}/{amount}/{bankBalance}")]
        public billResponse PayBill(int id, decimal amount,decimal bankBalance)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            billResponse response = new billResponse();
            BillApplication apl = new BillApplication();
            response = apl.PayBill(con, id, amount, bankBalance);
            return response;
        }
    }
}
