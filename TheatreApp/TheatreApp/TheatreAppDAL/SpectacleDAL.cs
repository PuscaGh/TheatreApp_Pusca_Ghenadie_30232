using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;
using System.Collections;

namespace TheatreAppDAL
{
    public static class SpectacleDAL
    {
        public static List<Spectacle> getAllSpectacles()
        {
            string getSpectacle = "SELECT * FROM Spectacles";
            List<Spectacle> spectacles = null;

            using (SqlConnection con = new SqlConnection(Constants.connectionString))
            {
                try
                {
                    con.Open();
                    spectacles = new List<Spectacle>();
                    SqlCommand com = new SqlCommand(getSpectacle, con);
                    SqlDataReader reader = com.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            int premieraColIdx = reader.GetOrdinal(Constants.premieraField);
                            int nrOfTicketsColIdx = reader.GetOrdinal(Constants.nrOfTicketsField);
                            string titluStr = reader[Constants.titluField].ToString();
                            string regiaStr = reader[Constants.regiaField].ToString();
                            string distributiaStr = reader[Constants.distributiaField].ToString();
                            DateTime premiera = reader.GetDateTime(premieraColIdx);
                            int nrOfTickets = reader.GetInt32(nrOfTicketsColIdx);

                            Spectacle spectacle = new Spectacle(premiera, titluStr, regiaStr, distributiaStr, nrOfTickets);
                            spectacles.Add(spectacle);
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

            return spectacles;
        }

        public static OperationResult.opResult addSpectacle(DateTime premiera,string titlu, string regia, string distributia,int maxNrOfTickets)
        {
            string addSpectacle = "INSERT INTO Spectacles VALUES (@titlu,@regia,@distributia,@premiera,@nrOfTickets)";

            using (SqlConnection con = new SqlConnection(Constants.connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand(addSpectacle, con);
                    com.Parameters.AddWithValue("@premiera", premiera);
                    com.Parameters.AddWithValue("@titlu", titlu);
                    com.Parameters.AddWithValue("@regia", regia);
                    com.Parameters.AddWithValue("@distributia", distributia);
                    com.Parameters.AddWithValue("@nrOfTickets", maxNrOfTickets);

                    com.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    return OperationResult.opResult.OperationAddSpectacleFail;
                }
            }

            return OperationResult.opResult.OperationAddSpectacleSucces;
        }

        public static OperationResult.opResult updateSpectacle(DateTime premiera,string titlu, string regia, string distributia,int nrOfTickets)
        {
            string updateSpectacle = "Update Spectacles SET Premiera = '" + premiera + "', Regia = @regia, Distributia = @distributia, TicketsNR ='" + nrOfTickets + "' WHERE Titlu = '" + titlu + "'";

            using (SqlConnection con = new SqlConnection(Constants.connectionString))
            {
                int rowsAffected = 0;
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand(updateSpectacle, con);
                    com.Parameters.AddWithValue("@regia", regia.ToString());
                    com.Parameters.AddWithValue("@distributia", distributia.ToString());
                    rowsAffected = com.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    return OperationResult.opResult.OperationUpdateSpectacleFail;
                }
                if (rowsAffected == 0) return OperationResult.opResult.OperationDeleteSpectacleFail;
            }

            return OperationResult.opResult.OperationUpdateSpectacleSucces;
        }

        public static OperationResult.opResult deleteSpectacle(string spectacol)
        {
            string delSpectacle = "DELETE FROM Spectacles WHERE Titlu ='" + spectacol + "'";

            OperationResult.opResult delTicketsResult = TicketDAL.deleteTicketsForSpectacle(spectacol);

            using (SqlConnection con = new SqlConnection(Constants.connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand(delSpectacle, con);
                    com.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    return OperationResult.opResult.OperationDeleteSpectacleFail;
                }
            }

            return delTicketsResult;
        }

        public static int getNrOfTicketsForSpectacle(string titlu)
        {
            string getTickets = "SELECT TicketsNR FROM Spectacles WHERE Titlu ='" + titlu + "'";
            int nrOfTickets = 0;

            using (SqlConnection con = new SqlConnection(Constants.connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand(getTickets, con);
                    SqlDataReader reader = com.ExecuteReader();
                    try
                    {
                        reader.Read();

                        int colIdx = reader.GetOrdinal(Constants.nrOfTicketsField);
                        nrOfTickets = reader.GetInt32(colIdx);
                    }
                    catch (InvalidOperationException)
                    {
                        return -1;
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                catch (SqlException)
                {
                    return -1;
                }
            }
            return nrOfTickets;
        }
    }
}
