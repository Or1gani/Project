using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebForms
{
    public class Database
    {
        private static readonly string cs = @"Data Source=.\SQLEXPRESS;Initial Catalog=Site1;Integrated Security=True;"; //Строка с данными о подключении

        public static List<Article> Load() //Метод для получения списка статей
        {
            List<Article> articles = new List<Article>(); //Создание пустого списка

            using (SqlConnection connection = new SqlConnection(cs)) //Создание подключения
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM articles", connection); //Команда для получения списка статей

                    using (SqlDataReader reader = command.ExecuteReader()) //Выполнение запроса
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) //Чтение всех полученных записей
                            {
                                articles.Add(new Article(reader.GetInt32(0), reader.GetString(1), reader.GetString(2))); //Добавление статьи в список
                            }
                        }
                    }
                }
                catch (Exception exc)
                {

                }

            }

            return articles; //Возвращение списка
        }

        public static Article Load(int id) //Метод загрузки конкретной статьи
        {
            Article article = new Article();

            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM articles WHERE id = @id", connection);

                    command.Parameters.Add(new SqlParameter("@id", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            article = new Article(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        }
                    }
                }
                catch (Exception exc)
                {

                }

            }
            return article;
        }
    }
}