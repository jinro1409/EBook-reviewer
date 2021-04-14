using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.dal
{
    public class categoryDAO
    {
        DataProvider dataProvider = new DataProvider();
        public List<category> getAll()
        {
            try
            {
                String query = "select * from category";
                DataTable dataTable = dataProvider.excuteQuery(query);

                List<category> list = new List<category>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    category a = new category();
                    a.id =int.Parse(dataTable.Rows[i]["id"].ToString());
                    a.cate = dataTable.Rows[i]["category"].ToString();
                   
                    list.Add(a);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Load cate");
            }
            return null;

        }
        public List<book_categories> getAllss()
        {
            try
            {
                String query = "select * from book_Categories inner join category on category.id=book_Categories.categoryid";
                DataTable dataTable = dataProvider.excuteQuery(query);

                List<book_categories> list = new List<book_categories>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    category a = new category();
                    a.id = int.Parse(dataTable.Rows[i][3].ToString());
                    a.cate = dataTable.Rows[i]["category"].ToString();
                    book b = new book();
                    b.id = int.Parse(dataTable.Rows[i][1].ToString());
                    book_categories bc= new book_categories();
                    bc.book = b;
                    bc.cate = a;


                    list.Add(bc);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Load cate");
            }
            return null;

        }
        internal void removeCateOfBook(int bid)
        {
            try
            {
                string query = "delete from book_Categories where bookid=" + bid;
                dataProvider.ExcuteNonQuery(query);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}