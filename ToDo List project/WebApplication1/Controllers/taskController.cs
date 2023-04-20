using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using toDoApi.Models;
using Task = toDoApi.Models.Task;

namespace toDoApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class taskController: ControllerBase
    {
        private readonly IConfiguration _configuration; 

        public taskController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllTasks")]

        public Response GetAllTasks()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetAllTasks(con);
            return response;
        }

        [HttpGet]
        [Route("GetTaskByID/{id}")]

        public Response GetTasksByID(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetTaskByID(con, id);
            return response;
        }

        [HttpPost]
        [Route("AddTask")]
        public Response AddTask(Task task)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.AddTask(con, task);
            return response;
        }

        [HttpPut]
        [Route("UpdateTask")]
        public Response UpdateTask(Task task)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.UpdateTask(con, task);
            return response;
        }


        [HttpDelete]
        [Route("DeleteTask/{Id}")]
        public Response DeleteTask(int Id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.DeleteTask(con, Id);
            return response;
        }
       /* [HttpGet]
        [Route("GetAllBills")]
        public Response GetAllBills()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            Response response = new Response();
            BillApplication apl = new BillApplication();
            response = apl.GetAllBills(con);
            return response;
        }

        [HttpGet]
        [Route("GetAllBillsByID/{id}")]

        public Response GetAllBillsByID(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            Response response = new Response();
            BillApplication apl = new BillApplication();
            response = apl.GetAllBillsByID(con, id);
            return response;
        }

        [HttpPost]
        [Route("AddBill")]
        public Response AddBill(Bill bill)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            Response response = new Response();
            BillApplication apl = new BillApplication();
            response = apl.AddBill(con, bill);
            return response;
        }

        [HttpPut]
        [Route("UpdateBill")]
        public Response UpdateBill(Bill bill)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            Response response = new Response();
            BillApplication apl = new BillApplication();
            response = apl.UpdateBill(con, bill);
            return response;
        }

        [HttpDelete]
        [Route(" DeleteBill/{Id}")]
        public Response DeleteBill(int Id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            Response response = new Response();
            BillApplication apl = new BillApplication();
            response = apl.DeleteBill(con, Id);
            return response;
        }

        [HttpPut]
        [Route("PayBill/{id}/{amount}/{bankBalance}")]
        public Response PayBill(int id, decimal amount, decimal bankBalance)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("taskCon").ToString());
            Response response = new Response();
            BillApplication apl = new BillApplication();
            response = apl.PayBill(con, id, amount, bankBalance);
            return response;
        }*/
    }
}
