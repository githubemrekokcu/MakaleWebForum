using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities;

namespace DataLogicLayer
{
    class BindFakeData : CreateDatabaseIfNotExists<MakaleWebDB>
    {

        protected override void Seed(MakaleWebDB context)
        {
            //User _user = new User()
            //{
            //    userCodeID = "USR-0000",
            //    userFirstName = "Emre",
            //    userLastName = "Kökçü",
            //    userDateOfBirth = DateTime.Parse("23/11/1994"),


            //};
            //_user.login = new List<Login>();
            //_user.login.Add(new Login { loginUserNameID = "emre", loginUserPassword = "emre" });
            //context.users.Add(_user);
            //User _user2 = new User()
            //{
            //    userCodeID = "USR-0001",
            //    userFirstName = "Esmanur",
            //    userLastName = "Kökçü",
            //    userDateOfBirth = DateTime.Parse("01/08/2005"),


            //};
            //_user2.login = new List<Login>();
            //_user2.login.Add(new Login { loginUserNameID = "esmanur", loginUserPassword = "esmanur" });
            //context.users.Add(_user2);

            Categories ctg;
            string _categoryCode = "CTG-0";
            string[] ArticleCategories = { "Kişisel", "Spor", "Teknoloji", "AR-GE", "Edebiyat", "Ekonami", "Siyasi", "Otomobil", "Yazılım" };
            for (int i = 0; i < ArticleCategories.Length; i++)
            {
                ctg = new Categories
                {
                    categoryCode = _categoryCode + (i),
                    categoryName = ArticleCategories[i],
                };
                ctg.article = new List<Article>();
                //for (int j = 0; j < 5; j++)
                //{
                //    ctg.article.Add(new Article
                //    {
                //        articleCodeID = "ARTC-00" + articleIndex,
                //        articleTitle = FakeData.PlaceData.GetCountry(),
                //        articleContent = FakeData.PlaceData.GetAddress(),
                //        articleSharedDate = DateTime.Now,
                //        user = _user
                       
                //    });
                //    articleIndex++;


                //}
                context.categorys.Add(ctg);
            }
            context.SaveChanges();

        }

    }

}
