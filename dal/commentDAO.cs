using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.dal
{
    public class commentDAO
    {
        DataProvider dataProvider = new DataProvider();
        public List<comment> getbyBook(int bookid)
        {
            try
            {
                String query = "select comment.id, bookid,comment,account.userName,account.displayName,createdDate from comment inner join account account on account.userName=comment.Username where bookid=" + bookid + " and comment.status=1";
                DataTable dataTable = dataProvider.excuteQuery(query);

                List<comment> list = new List<comment>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    account a = new account();
                    a.username = dataTable.Rows[i]["userName"].ToString();
                    a.fullname = dataTable.Rows[i]["displayName"].ToString();
                    comment S = new comment();
                    S.id = int.Parse(dataTable.Rows[i]["id"].ToString());
                    S.bookid = int.Parse(dataTable.Rows[i]["bookid"].ToString());
                    S.detail = dataTable.Rows[i]["comment"].ToString();
                    S.createdon = DateTime.Parse(dataTable.Rows[i]["createdDate"].ToString());
                    S.createdby = a;
                    list.Add(S);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Load comment");
            }
            return null;

        }
        public List<comment> getAll()
        {
            try
            {
                String query = "select comment.id, bookid,comment,a.userName,a.displayName,createdDate from comment inner join account a on a.userName=comment.Username ";
                DataTable dataTable = dataProvider.excuteQuery(query);

                List<comment> list = new List<comment>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    account a = new account();
                    a.username = dataTable.Rows[i]["userName"].ToString();
                    a.fullname = dataTable.Rows[i]["displayName"].ToString();
                    comment S = new comment();
                    S.id = int.Parse(dataTable.Rows[i]["id"].ToString());
                    S.bookid = int.Parse(dataTable.Rows[i]["bookid"].ToString());
                    S.detail = dataTable.Rows[i]["comment"].ToString();
                    S.createdon = DateTime.Parse(dataTable.Rows[i]["createdDate"].ToString());
                    S.createdby = a;
                    list.Add(S);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Load comment");
            }
            return null;
        }
        public List<comment> getbyUser(String b)
        {
            try
            {
                String query = "select comment.id, bookid,comment,a.userName,a.displayName,createdDate from "
                        + "comment inner join account a on a.userName=comment.Username where comment.Username='" + b + "'";
                DataTable dataTable = dataProvider.excuteQuery(query);

                List<comment> list = new List<comment>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    account a = new account();
                    a.username = dataTable.Rows[i]["userName"].ToString();
                    a.fullname = dataTable.Rows[i]["displayName"].ToString();
                    comment S = new comment();
                    S.id = int.Parse(dataTable.Rows[i]["id"].ToString());
                    S.bookid = int.Parse(dataTable.Rows[i]["bookid"].ToString());
                    S.detail = dataTable.Rows[i]["comment"].ToString();
                    S.createdon = DateTime.Parse(dataTable.Rows[i]["createdDate"].ToString());
                    S.createdby = a;
                    list.Add(S);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Load comment");
            }
            return null;
        }
        public void addnewComment(String username, String comment, int bookid)
        {
            String query = "INSERT INTO [dbo].[comment]\n" +
    "           ([bookid]\n" +
    "           ,[comment]\n" +
    "           ,[Username]\n" +
    "           ,[createdDate],[status])\n" +
    "     VALUES\n"
                    + "           ('" + bookid + "'\n"
                    + "           ,'" + comment + "'\n"
                    + "           ,'" + username + "'\n"
                    + "           ,GETDATE(),1)";
            dataProvider.ExcuteNonQuery(query);
        }
        public void addReply(String username, String comment, int id)
        {
            String query = "INSERT INTO [dbo].[reply]([commentid],[detail],[username]) VALUES ("+id+",'"+comment+"','"+username+"')";
            dataProvider.ExcuteNonQuery(query);
        }
        public void delete(int id)
        {
            String query = "DELETE FROM [dbo].[comment] WHERE id='" + id + "'";
            dataProvider.ExcuteNonQuery(query);
        }
        public void deletebyUser(int id)
        {
            String query = "UPDATE [dbo].[comment] SET [status] = 0 WHERE id = '" + id + "'";
            dataProvider.ExcuteNonQuery(query);
        }
        public List<reply> getReplys(int id)
        {
            try
            {
                String query = "SELECT r.[commentid],r.[id],r.[detail],r.[username]FROM[dbo].[reply] r inner join [comment] c on c.id=r.commentid WHERE bookid = "+id+" ";
                DataTable dataTable = dataProvider.excuteQuery(query);

                List<reply> list = new List<reply>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    reply a = new reply();
                    a.username = dataTable.Rows[i]["username"].ToString();
                    a.id = int.Parse(dataTable.Rows[i]["id"].ToString());
                    a.detail = dataTable.Rows[i]["detail"].ToString();
                    a.cmtid = int.Parse(dataTable.Rows[i]["commentid"].ToString());
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
    } 
}