using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.dal
{
    public class BookDAO
    {
        DataProvider dataProvider = new DataProvider();
        public List<book> getAll(int size, int page)
        {
            try
            {
                String query = "SELECT book.id, name, shortdes,description,language,image,published,uppoint,downpoint,account.userName,account.displayName\n"
                        + "       FROM [book] inner join account account on book.createby=account.userName ORDER BY (uppoint-downpoint) desc \n"
                        + " OFFSET (" + page + "*" + size + "-" + size + ") ROWS FETCH NEXT " + size + " ROWS ONLY";
                string query2 = "SELECT book.id, name, shortdes,description,language,image,published,uppoint,downpoint,account.userName,account.displayName FROM [book] inner join account account on book.createby = account.userName ORDER BY (uppoint-downpoint) desc OFFSET (" + page + "*" + size + "-" + size + ") ROWS FETCH NEXT " + size + " ROWS ONLY";
                DataTable dataTable = dataProvider.excuteQuery(query2);

                List<book> list = new List<book>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    account a = new account();
                    a.username = dataTable.Rows[i]["userName"].ToString();
                    a.fullname = dataTable.Rows[i]["displayName"].ToString();
                    book S = new book();
                    S.id = int.Parse(dataTable.Rows[i]["id"].ToString());
                    S.shortDes = dataTable.Rows[i]["shortdes"].ToString();
                    S.name = dataTable.Rows[i]["name"].ToString();
                    S.des = dataTable.Rows[i]["description"].ToString();
                    S.language = dataTable.Rows[i]["language"].ToString();
                    S.img = dataTable.Rows[i]["image"].ToString();
                    S.upPoint = Int32.Parse(dataTable.Rows[i]["uppoint"].ToString());
                    S.downPoint = Int32.Parse(dataTable.Rows[i]["downpoint"].ToString());
                    S.createdby = a;
                    S.pulishedDate = DateTime.Parse(dataTable.Rows[i]["published"].ToString());
                    list.Add(S);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Paging" + ex.Message);
            }

            return null;
        }
        public void addBook(String name, String des, String cr, String languge, String img)
        {

            try
            {
                string query = "INSERT INTO [dbo].[book] ([name] ,[description] ,[createby] ,[language] ,[image],[shortDes],[published])"
                       + "     VALUES('" + name + "','" + des + "','" + cr + "','" + languge + "','" + img + "','" + des + "',GETDATE())";
                dataProvider.ExcuteNonQuery(query);
            }
            catch (Exception e)
            {
                Console.WriteLine("ADD New Book" + e.Message);
            }
        }
        public List<book> getbyname(String txt,int page, int size)
        {
            try
            {
                String query = "SELECT book.id, name,shortDes,description,language,image,published,account.userName,account.displayName\n"
                        + " FROM [book] inner join account account on book.createby=account.userName where name like '%" + txt + "%' "
                +"ORDER BY book.id OFFSET (" + page + "*" + size + "-" + size + ") ROWS FETCH NEXT " + size + " ROWS ONLY";
                DataTable dataTable = dataProvider.excuteQuery(query);

                List<book> list = new List<book>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    account a = new account();
                    a.username = dataTable.Rows[i]["userName"].ToString();
                    a.fullname = dataTable.Rows[i]["displayName"].ToString();
                    book S = new book();
                    S.id = int.Parse(dataTable.Rows[i]["id"].ToString());
                    S.shortDes = dataTable.Rows[i]["shortdes"].ToString();
                    S.name = dataTable.Rows[i]["name"].ToString();
                    S.des = dataTable.Rows[i]["description"].ToString();
                    S.language = dataTable.Rows[i]["language"].ToString();
                    S.img = dataTable.Rows[i]["image"].ToString();
                    S.createdby = a;
                    S.pulishedDate = DateTime.Parse(dataTable.Rows[i]["published"].ToString());
                    list.Add(S);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Searching" + ex.Message);
            }

            return null;
        }
        public List<book> getbycid(int cid, int page,int size)
        {
            try
            {
                String query = "SELECT * FROM book inner join book_categories on book.id=book_categories.bookid\n"
                        + "inner join account account on account.userName=book.createby where book_categories.categoryid='" + cid + "'\n"
                         + "ORDER BY book.id OFFSET (" + page + "*" + size + "-" + size + ") ROWS FETCH NEXT " + size + " ROWS ONLY";


                DataTable dataTable = dataProvider.excuteQuery(query);

                List<book> list = new List<book>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    account a = new account();
                    a.username = dataTable.Rows[i]["userName"].ToString();
                    a.fullname = dataTable.Rows[i]["displayName"].ToString();
                    book S = new book();
                    S.id = int.Parse(dataTable.Rows[i]["id"].ToString());
                    S.shortDes = dataTable.Rows[i]["shortdes"].ToString();
                    S.name = dataTable.Rows[i]["name"].ToString();
                    S.des = dataTable.Rows[i]["description"].ToString();
                    S.language = dataTable.Rows[i]["language"].ToString();
                    S.img = dataTable.Rows[i]["image"].ToString();
                    S.createdby = a;
                    S.pulishedDate = DateTime.Parse(dataTable.Rows[i]["published"].ToString());
                    list.Add(S);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Searching" + ex.Message);
            }
            return null;
        }
        public book getOne(int id)
        {
            try
            {
                String query = "SELECT book.id, name, shortDes,description,language,image,published,account.userName,account.displayName\n"
                        + "  FROM [book] inner join account account on book.createby=account.userName\n"
                        + "where book.id='"+id+"'";
                DataTable dataTable = dataProvider.excuteQuery(query);


                account a = new account();
                a.username = dataTable.Rows[0]["userName"].ToString();
                a.fullname = dataTable.Rows[0]["displayName"].ToString();
                book S = new book();
                S.id = int.Parse(dataTable.Rows[0]["id"].ToString());
                S.shortDes = dataTable.Rows[0]["shortdes"].ToString();
                S.name = dataTable.Rows[0]["name"].ToString();
                S.des = dataTable.Rows[0]["description"].ToString();
                S.language = dataTable.Rows[0]["language"].ToString();
                S.img = dataTable.Rows[0]["image"].ToString();
                S.createdby = a;
                S.pulishedDate = DateTime.Parse(dataTable.Rows[0]["published"].ToString());


                return S;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Searching" + ex.Message);
            }
            return null;
        }

        public void addCforlast(int c, int b)
        {
            String query = "INSERT INTO [dbo].[book_Categories]\n" +
    "           ([bookid]\n" +
    "           ,[categoryid])\n" +
    "     VALUES\n" +
    "           ("+b+"\n" +
    "           ,"+c
    
    
    +")";
            dataProvider.ExcuteNonQuery(query);
        }
        public book getLast()
        {
            try
            {
                String query = "SELECT TOP 1 * FROM book ORDER BY ID DESC";
                DataTable dataTable = dataProvider.excuteQuery(query);


                account a = new account();
                a.username = dataTable.Rows[0]["userName"].ToString();
                a.fullname = dataTable.Rows[0]["displayName"].ToString();
                book S = new book();
                S.id = int.Parse(dataTable.Rows[0]["id"].ToString());
                S.shortDes = dataTable.Rows[0]["shortdes"].ToString();
                S.name = dataTable.Rows[0]["name"].ToString();
                S.des = dataTable.Rows[0]["description"].ToString();
                S.language = dataTable.Rows[0]["language"].ToString();
                S.img = dataTable.Rows[0]["image"].ToString();
                S.createdby = a;
                S.pulishedDate = DateTime.Parse(dataTable.Rows[0]["published"].ToString());


                return S;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Searching" + ex.Message);
            }
            return null;
        }

        public int countPage(int pageSize)
        {
            try
            {
                String query = "select Count(*)  from book ";

                DataTable dataTable = dataProvider.excuteQuery(query);
                int count = int.Parse(dataTable.Rows[0][0].ToString());

                int numOfPage = count / pageSize;
                if (count % pageSize != 0)
                {
                    numOfPage++;
                }
                return numOfPage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "");
            }
            return 0;
        }
        public void delete(int id)
        {

            String query = "delete from book_Categories where bookid="+id+"\n"
                + "delete from book_Author where bookid="+id+"\n"
                + "delete from comment where bookid="+id+"\n"
                + "delete from book where book.id="+id+"";

            dataProvider.ExcuteNonQuery(query);
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
        public int upPoint(int bookid, int upPoint)
        {
            string strAdd = "update book set uppoint=" + (upPoint + 1) + " where id=" + bookid;
            return new DataProvider().ExcuteNonQuery2(strAdd);
        }
        public int downPoint(int bookid, int downPoint)
        {
            string strAdd = "update book set downpoint=" + (downPoint + 1) + " where id=" + bookid;
            return new DataProvider().ExcuteNonQuery2(strAdd);
        }
        public void updateBook(book b)
        {
            try
            {
                String query = "UPDATE [dbo].[book] SET [name] = '" + b.name + "'" +
                    ",[description] = '" + b.des + "'" +
                    ",[language] = '" + b.language + "'" +
                    ",[image] = '" + b.img + "'" +
                    " WHERE id=" + b.id;
                dataProvider.ExcuteNonQuery(query);
            }
            catch (Exception e)
            {
                Console.WriteLine("ADD New Book" + e.Message);
            }
        }
    }
}

