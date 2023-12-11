using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms
{
    public class Article
    {
        public int ID;
        public string Title;
        public string Text;

        public Article()
        {
            this.ID = 0;
            this.Title = "No such article";
            this.Text = "Wrong article ID!";
        }

        public Article(int id, string title, string text)
        {
            this.ID = id;
            this.Title = title;
            this.Text = text;
        }
    }
}