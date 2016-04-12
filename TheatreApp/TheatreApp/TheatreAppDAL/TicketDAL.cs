using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;

namespace TheatreAppDAL
{
    public static class TicketDAL
    {
        public static List<Ticket> getAllTicketsForSpectacle(string spectacol)
        {
            string getCode = "SELECT * FROM Tickets where Spectacol = @spectacol";
            List<Ticket> tickets = null;

            using (SqlConnection con = new SqlConnection(Constants.connectionString))
            {
                try
                {
                    con.Open();
                    tickets = new List<Ticket>();
                    SqlCommand com = new SqlCommand(getCode, con);
                    com.Parameters.AddWithValue("@spectacol", spectacol);
                    SqlDataReader reader = com.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            string codeR = reader[Constants.codeField].ToString();
                            int randR = int.Parse(reader[Constants.randField].ToString());
                            int numarR = int.Parse(reader[Constants.numarField].ToString());
                            Ticket ticket = new Ticket(codeR, spectacol, randR, numarR);
                            tickets.Add(ticket);
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        return null;
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                catch (SqlException ex)
                {
                    // Just return null and handle the this result in class that invokes this method
                    return null;
                }
            }
            return tickets;
        }

        public static OperationResult.opResult addTicketForSpectacle(string code, string spectacol, int rand, int numar)
        {
            string addTicket = "IF NOT EXISTS (SELECT * FROM Tickets WHERE Rand = @rand AND Numar = @numar AND Spectacol = @spectacol) INSERT INTO Tickets VALUES (@code,@spectacol,@rand,@numar)";

            using (SqlConnection con = new SqlConnection(Constants.connectionString))
            {
                int rowsAffected = 0;
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand(addTicket, con);
                    com.Parameters.AddWithValue("@code", code);
                    com.Parameters.AddWithValue("@spectacol", spectacol);
                    com.Parameters.AddWithValue("@rand", rand);
                    com.Parameters.AddWithValue("@numar", numar);
                    rowsAffected = com.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    return OperationResult.opResult.OperationAddTicketFail;
                }

                if (rowsAffected == 0) return OperationResult.opResult.OperationInsertTicketDuplicate;
            }

            return OperationResult.opResult.OperationAddTicketSucces;
        }

        public static OperationResult.opResult deleteTicketsForSpectacle(string spectacol)
        {
            string delTickets = "DELETE FROM Tickets WHERE Spectacol ='" + spectacol + "'";

            using (SqlConnection con = new SqlConnection(Constants.connectionString))
            {
                int rowsAffected = 0;
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand(delTickets, con);
                    rowsAffected = com.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    return OperationResult.opResult.OperationDeleteSpectacleFail;
                }

                if (rowsAffected == 0) return OperationResult.opResult.OperationDeleteSpectacleFail;
            }
            return OperationResult.opResult.OperationDeleteSpectacleSucces;
        }
    }
}
