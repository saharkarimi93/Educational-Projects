using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace toDoApi.Models
{
    public class BillApplication
    {
        public billResponse GetAllBills(SqlConnection con)
        {
            billResponse response = new billResponse();
            SqlDataAdapter da = new SqlDataAdapter("Select * from BillReminders", con);
            DataTable dt = new DataTable();
            List<Bill> Listbills = new List<Bill>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Bill bill = new Bill();
                    bill.Id = (int)dt.Rows[i]["Id"];
                    bill.Description = (string)dt.Rows[i]["Description"];
                    bill.Amount = decimal.Parse(dt.Rows[i]["Amount"].ToString());
                    bill.DueDate = (string)dt.Rows[i]["DueDate"];
                    bill.bankBalance = decimal.Parse(dt.Rows[i]["bankBalance"].ToString());

                    Listbills.Add(bill);
                }
            }
            response.bll = new Bill();
            if (Listbills.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.Bills = Listbills;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.Bills= null;
            }
            return response;
        }

        public billResponse GetAllBillsByID(SqlConnection con, int id)
        {
            billResponse response = new billResponse();
            SqlDataAdapter da = new SqlDataAdapter("Select * from BillReminders Where ID = '" + id + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Bill bill = new Bill();
                bill.Id = (int)dt.Rows[0]["Id"];
                bill.Description = (string)dt.Rows[0]["Description"];
                bill.Amount = decimal.Parse(dt.Rows[0]["Amount"].ToString());
                bill.DueDate = (string)dt.Rows[0]["DueDate"];
                bill.bankBalance = decimal.Parse(dt.Rows[0]["bankBalance"].ToString());
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.bll =bill;


            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.Bills = null;
            }
            return response;
        }

        public billResponse AddBill(SqlConnection con, Bill bill)
        {
            billResponse response = new billResponse();
            SqlCommand cmd = new SqlCommand("Insert into BillReminders(Id, Description, Amount,DueDate, bankBalance) Values('" + bill.Id + "','" + bill.Description + "', '" + bill.Amount + "', '" + bill.DueDate + "','" +bill.bankBalance + "') ", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Bill Added";



            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted";

            }
            return response;
        }

        public billResponse UpdateBill(SqlConnection con, Bill bill)
        {
            billResponse response = new billResponse();
            SqlCommand cmd = new SqlCommand("Update BillReminders set Description='" + bill.Description + "', Amount='" + bill.Amount + "', DueDate='" + bill.DueDate + "', bankBalance='" + bill.bankBalance + "' Where Id='" + bill.Id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Bill Updated";



            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted";

            }
            return response;
        }

        public billResponse DeleteBill(SqlConnection con, int Id)
        {
            billResponse response = new billResponse();
            SqlCommand cmd = new SqlCommand("Delete from BillReminders Where ID = '" + Id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Bill Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "ID does not Exist!";
            }

            return response;
        }

        public billResponse PayBill(SqlConnection con, int id, decimal amount, decimal bankBalance)
        {
            billResponse response = new billResponse();

            SqlCommand cmd = new SqlCommand("Update BillReminders set bankBalance=bankBalance - '" + amount + "' where Id='" + id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Bank Balance Updated";
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted";

            }
            return response;
        }
    }
}
