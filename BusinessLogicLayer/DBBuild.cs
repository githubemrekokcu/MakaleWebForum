using DataLogicLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class DBBuild
    {
        
       
        public DBBuild()
        {
            MakaleWebDB db = new MakaleWebDB();
            //db.Database.CreateIfNotExists();
            db.users.ToList();

            //Repository<Categories> rep_ctg = new Repository<Categories>();
            //List<Categories> list = rep_ctg.List();

        }

        //public void InsertTest() {

        //    Repository<Categories> rep_ctg = new Repository<Categories>();
        //    int InsertCount =  rep_ctg.Insert(new Categories
        //    {
        //        categoryCode = "CTG-06",
        //        categoryName = "Uzay",
        //    });
        //}


        //public void UpdateTest()
        //{

        //    Repository<Login> rep_login = new Repository<Login>();
        //    Login l = rep_login.Find(x => x.loginUserNameID == "emre");
        //    if (l != null)
        //    {
        //        l.loginUserPassword = "emree";
        //        int InsertCount = rep_login.Update();

        //    }
        //}


        //public void InsertTest()
        //{

        //    Repository<Article> rep_art = new Repository<Article>();
        //    Article art1 = (Article) rep_art.Find(x=>x.articleCodeID == "ARTC-000");
        //    art1.comments = new List<ArticleComment>();
        //    art1.comments.Add(new ArticleComment
        //    {
        //        articleComment="Güzel Uygulama",
        //        user = art1.user
        //    });
        //    rep_art.Update();
        //}

        public void InsertUserTest()
        {

            Repository<User> rep_user = new Repository<User>();

        }

    }
}
