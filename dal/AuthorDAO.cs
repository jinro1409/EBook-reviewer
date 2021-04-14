using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.dal
{
    public class AuthorDAO
    {
        DataProvider dataProvider = new DataProvider();

        public List<author> getAll()
        {
            List<author> list = new List<author>();
            try
            {
                String query = "SELECT TOP (1000) [id],[name],[lifestory],[nation],[DOB] FROM[Project_Blog].[dbo].[author]";
                DataTable dt = dataProvider.excuteQuery(query);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    author a = new author();
                    a.id = int.Parse(dt.Rows[i]["id"].ToString());
                    a.name = dt.Rows[i]["name"].ToString();
                    a.lifeStory = dt.Rows[i]["lifestory"].ToString();
                    a.national = dt.Rows[i]["nation"].ToString();
                    a.dob = DateTime.Parse(dt.Rows[i]["DOB"].ToString());
                    list.Add(a);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Paging" + ex.Message);
            }

            return list;
        }

        internal void AddAuthorForBook(int aid, int bid)
        {
            try {
                string query = "INSERT INTO [dbo].[book_Author]   ([bookid],[authorid]) VALUES (" + bid + "," + aid + ")";
                dataProvider.ExcuteNonQuery(query);
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            }

        internal void AddAuthor(string author_name, string lifestory, string nation, string dob)
        {
            try
            {
                String query = "INSERT INTO [dbo].[author] ([name],[lifestory],[nation],[DOB])"
                       + "     VALUES('" + author_name + "','" + lifestory + "','" + nation+ "','" + dob + "')";
                dataProvider.ExcuteNonQuery(query);
            }
            catch (Exception e)
            {
                Console.WriteLine("ADD New Book" + e.Message);
            }
        }

        internal int getLastId()
        {
            try
            {
                string query = "SELECT TOP 1 * FROM author ORDER BY ID DESC";
                DataTable dt = dataProvider.excuteQuery(query);
                return int.Parse(dt.Rows[0]["id"].ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }

        internal List<author> getAuthorByBookID(int bid)
        {
            try
            {
                String query = "SELECT author.[id],[name],[lifestory],[nation],[DOB] FROM[Project_Blog].[dbo].[author] join book_Author on author.id=authorid where bookid="+bid;
                DataTable dt = dataProvider.excuteQuery(query);
                List<author> asss = new List<author>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    author a = new author();
                    a.id = int.Parse(dt.Rows[i]["id"].ToString());
                    a.name = dt.Rows[i]["name"].ToString();
                    a.lifeStory = dt.Rows[i]["lifestory"].ToString();
                    a.national = dt.Rows[i]["nation"].ToString();
                    a.dob = DateTime.Parse(dt.Rows[i]["DOB"].ToString());
                    asss.Add(a);
                }
                return asss;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Paging" + ex.Message);
            }

            return null;
        }
    }
}