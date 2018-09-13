using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TicTakToe
{
    public class DBConnection
    {
        public SqlConnection cnn;
        public SqlConnection connetionString = new SqlConnection("Data Source =.; Initial Catalog = TicTacToe; User ID = sa; Password=test123!@#");

        public void insert(string FName, string LName, string UserName)
        {

            connetionString.Open();
            
            string TokenID = Guid.NewGuid().ToString();

            string query = "Insert into  userTable  (firstName,lastName,userID,accessToken) values ('" + FName + "', '" + LName + "', '" + UserName + "', '" + TokenID + "')";

            SqlCommand myCommand = new SqlCommand(query, connetionString);
            myCommand.ExecuteNonQuery();

        }
        public bool isAuthenticated(string tokenId)
        {
            connetionString.Open();
            string query = "SELECT * FROM userTable where accessToken = '" + tokenId+"'";
            SqlCommand sqlCommand = new SqlCommand(query, connetionString);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if(sqlDataReader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void loging(log logs)
        {
            connetionString.Open();
            string query = "Insert into  loging  (request,response,exception,status) values ('" +logs.request +"', '" +logs.response +"','" +logs.exception +"', '" +logs.status +"')";
            SqlCommand myCommand = new SqlCommand(query, connetionString);
            myCommand.ExecuteNonQuery();

        }
    }
}
