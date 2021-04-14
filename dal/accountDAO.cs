using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.dal
{
    public class accountDAO
    {
        DataProvider dataProvider = new DataProvider();
        public List<account> getAll()
        {
            try
            {
                String query = "select * from account where role_id=0";
                DataTable dataTable = dataProvider.excuteQuery(query);

                List<account> list = new List<account>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    account a = new account();
                    a.username = dataTable.Rows[i]["userName"].ToString();
                    a.fullname = dataTable.Rows[i]["displayName"].ToString();
                    a.password = dataTable.Rows[i]["password"].ToString();
                    a.DOB = DateTime.Parse(dataTable.Rows[0]["dob"].ToString());
                    a.email = dataTable.Rows[i]["email"].ToString();
                    a.gender = bool.Parse(dataTable.Rows[i]["gender"].ToString());
                    a.role = bool.Parse(dataTable.Rows[i]["role_id"].ToString());
                    list.Add(a);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Load Account");
            }
            return null;

        }
     
        public account getAccount(String username, String password)
        {
            try
            {
                String query = "select * from account\n"
                    + "where userName = '" + username + "' and password = '" + password + "'";
                account a = new account();
                DataTable dataTable = dataProvider.excuteQuery(query);
                a.username = dataTable.Rows[0]["userName"].ToString();
                a.fullname = dataTable.Rows[0]["displayName"].ToString();
                a.password = dataTable.Rows[0]["password"].ToString();
                a.DOB = DateTime.Parse(dataTable.Rows[0]["dob"].ToString());
                a.email = dataTable.Rows[0]["email"].ToString();
                a.gender = bool.Parse(dataTable.Rows[0]["gender"].ToString());
                a.role = bool.Parse(dataTable.Rows[0]["role_id"].ToString());
                a.Status = bool.Parse(dataTable.Rows[0]["status"].ToString());
                return a;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "Login Account");
            }
            return null;

        }
        internal int getLastId()
        {
            try
            {
                string query = "SELECT TOP 1 * FROM book ORDER BY ID DESC";
                DataTable dt = dataProvider.excuteQuery(query);
                return int.Parse(dt.Rows[0]["id"].ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }

        public account getaccbyEmail(String email)
        {
            try
            {
                String query = "select * from account\n"
                    + "where email = '" + email + "' ";
                account a = new account();
                DataTable dataTable = dataProvider.excuteQuery(query);
                a.username = dataTable.Rows[0]["userName"].ToString();
                a.fullname = dataTable.Rows[0]["displayName"].ToString();
                a.password = dataTable.Rows[0]["password"].ToString();
                a.email = dataTable.Rows[0]["email"].ToString();
                a.DOB = DateTime.Parse(dataTable.Rows[0]["dob"].ToString());
                a.gender = bool.Parse(dataTable.Rows[0]["gender"].ToString());
                a.role = bool.Parse(dataTable.Rows[0]["role_id"].ToString());
                return a;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "Load fail Account");
            }
            return null;
        }
        public account getaccbyUser(String username)
        {
            try
            {
                String query = "select * from account\n"
                    + "where userName = '" + username + "' ";
                account a = new account();
                DataTable dataTable = dataProvider.excuteQuery(query);
                a.username = dataTable.Rows[0]["userName"].ToString();
                a.fullname = dataTable.Rows[0]["displayName"].ToString();
                a.password = dataTable.Rows[0]["password"].ToString();
                a.email = dataTable.Rows[0]["email"].ToString();
                a.DOB = DateTime.Parse(dataTable.Rows[0]["dob"].ToString());
                a.gender = bool.Parse(dataTable.Rows[0]["gender"].ToString());
                a.role = bool.Parse(dataTable.Rows[0]["role_id"].ToString());
                return a;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "Load fail Account");
            }
            return null;
        }
        public void delete(String username)
        {
            try
            {
                String query = "DELETE comment where Username='" + username + "'\n" +
   "DELETE book where createby='" + username + "'\n" +
   "DELETE account where userName='" + username + "'";
                dataProvider.ExcuteNonQuery(query);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "delete fail Account");
            }
        }
        public void addAccount(String username, String password, String display, DateTime dob, String mail, bool gender)
        {
            String query = "INSERT INTO account\n"
                    + "     VALUES\n"
                    + "           ('" + username + "'\n"
                    + "           ,'" + password + "'\n"
                    + "           ,'" + display + "'\n"
                    + "           ,'" + mail + "'\n"
                    + "           ,'" + dob + "'\n"
                    + "           ,'" + false + "'\n"
                    + "           ,'" + gender + "','"+false+"')";
            dataProvider.ExcuteNonQuery(query);
        }
        public void Updatepassword(String username, String pass)
        {
            String query = " UPDATE [dbo].[account]\n" +
    "   SET \n" +
    "      [password] = '"+pass+"'\n" +
    " WHERE [userName] ='"+username+"'";
            dataProvider.ExcuteNonQuery(query);
        }
        public void UpdateProfile(String username, String name, String email, DateTime dob, bool gender)
        {
            String query = " UPDATE [dbo].[account]\n" +
"   SET \n" +
"       [displayName] = '"+name+"'\n" +
"      ,[email] = '"+email+"'\n" +
"      ,[dob] = '"+dob+"'\n" +
"      ,[gender] = '"+gender+"'\n" +
" WHERE [userName] ='"+username+"'";
            dataProvider.ExcuteNonQuery(query);
        }
        public void UpdateVertify(String username)
        {
            String query = " UPDATE [dbo].[account] SET[status] = 'true' WHERE userName = '"+username+"'";
            dataProvider.ExcuteNonQuery(query);
        }
    }
    }