using BusinessLogicLayer;
using DataLogicLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakaleWeb.Controllers
{
    public class HomeController : Controller
    {
        MakaleWebDB dbContext;
        public HomeController()
        {
            dbContext = new MakaleWebDB();
        }
        // GET: Home
        public ActionResult Index()
        {
            //DBBuild CreateDB = new DBBuild(); // Database Create et.
            //CreateDB.InsertTest();
            try
            {
                if (Session["LoginUser"] != null)
                {
                    Login login = (Login)Session["LoginUser"];
                    User user = login.user;
                    ViewBag.FullName = user.userFirstName + " " + user.userLastName;
                }
            }
            catch (Exception) { }
            //  CreateDB.InsertTest(); // 1 kere çelıştırıldı primary key hata verir sonraki çalıştırılmalarda..
            //CreateDB.UpdateTest();
            BLLRepository<Article> rep_Artc = new BLLRepository<Article>();

            return View(rep_Artc.List().OrderByDescending(x=>x.articleSharedDate).ToList());
        }

        // GET: Home
        public ActionResult Article(string id)
        {
            DBBuild CreateDB = new DBBuild(); // Database Create et.
            //CreateDB.InsertTest();
            try
            {
                if (Session["LoginUser"] != null)
                {
                    Login login = (Login)Session["LoginUser"];
                    User user = login.user;
                    ViewBag.FullName = user.userFirstName + " " + user.userLastName;
                }
            }
            catch (Exception) { }

            BLLRepository<Article> rep_Artc = new BLLRepository<Article>();
            // ViewBag.ArticleDetail = rep_Artc.List(x => x.category.categoryName == id);

            return View("Index", rep_Artc.List(x => x.category.categoryName == id));


        }


        // GET: Login
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        // GET: Login
        [HttpPost]
        public string SignUp(string userFirstName, string userLastName, string userDateOfBirth,
            string userName, string userPassword, string userTryPassword)
        {
            BLLRepository<User> rep_createdUser = new BLLRepository<Entities.User>();
            BLLRepository<Login> rep_Login = new BLLRepository<Login>();
            Entities.User lastUser = new Entities.User();
            try
            {
                lastUser = rep_createdUser.List().OrderByDescending(x => x.userCodeID).First();
            }
            catch (Exception) { }
            try
            {
                string userCodeID = getNewArticleCodeID(lastUser.userCodeID, "USER-00000");
                rep_createdUser.Insert(new Entities.User {
                    userCodeID=userCodeID,
                    userFirstName=userFirstName,
                    userLastName=userLastName,
                    userDateOfBirth = DateTime.Parse(userDateOfBirth),
                    Articles = new List<Article>(),
                    login = new List<Login>()
                });
                rep_Login.Insert(new Entities.Login {
                    loginUserNameID=userName,
                    loginUserPassword = userPassword,
                    user = rep_createdUser.Find(x=>x.userCodeID==userCodeID)
                });
                return "success";
            }
            catch (Exception)
            {

                return "error";
            }
           
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: Login
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }



        // GET: Comment
        public ActionResult Comment(string id)
        {
            BindInfo();
            BLLRepository<Article> rep_Artc = new BLLRepository<Article>();
            List<Article> Article = rep_Artc.List(x => x.articleCodeID == id);
            ViewBag.ArticleDetail = Article[0];
            return View("Index", rep_Artc.List(x => x.articleCodeID == id));
        }

        // GET: Comment
        [HttpPost]
        public string sentComment(string comment, string usercode, string articlecode)
        {
            try
            {
                BLLRepository<ArticleComment> rep_Artc_Comment = new BLLRepository<ArticleComment>();
                BLLRepository<User> rep_User = new BLLRepository<User>();
                BLLRepository<Article> rep_Artc = new BLLRepository<Article>();
                User _user = rep_User.Find(x => x.userCodeID == usercode);
                Article article = rep_Artc.Find(x => x.articleCodeID == articlecode);

                int insertCount = rep_Artc_Comment.Insert(new ArticleComment
                {
                    articleComment = comment,
                    articleCommentRefArticleCode = article.articleCodeID,
                    article = article,
                    user = _user
                });
                if (insertCount > 0)
                    return "success";
                else
                    return "error";


            }
            catch (Exception)
            {

                return "error";
            }

        }

        [HttpPost]
        public string setLike(string userCode,string articleCode, bool like)
        {
            try
            {
                BLLRepository<User> rep_user = new BLLRepository<User>();
                BLLRepository<Article> rep_article = new BLLRepository<Article>();
                Entities.User user = rep_user.Find(x => x.userCodeID == userCode);
                Entities.Article article = rep_article.Find(x => x.articleCodeID == articleCode);
                if (like) //Like işlemi yapılacak
                {
                    BLLRepository<ArticleLikes> rep_artLike = new BLLRepository<ArticleLikes>();
                    rep_artLike.Insert(new ArticleLikes {
                        article = article,
                        user = user
                    });
                    return "liked";
                }
                else // Unlike işlemi yapılacak
                {
                    BLLRepository<ArticleLikes> rep_artLike = new BLLRepository<ArticleLikes>();
                    ArticleLikes articlelike = new ArticleLikes();
                    List<ArticleLikes> artLikeLİst = rep_artLike.List();
                    try
                    {
                        articlelike = rep_artLike.List(x => x.article.articleCodeID == article.articleCodeID & x.user.userCodeID==user.userCodeID).First();
                    }
                    catch (Exception) { }
                    if (articlelike.articleLikesID != null) // like kaydı bulunmuş ise
                    {
                        rep_artLike.Remove(articlelike);
                    }
                    return "unliked";

                }

            }
            catch (Exception)
            {

                return "error";
            }

        }

        [HttpPost]
        public string sendArticle(string title, string articlecontent, string loginUserCode, string categoryCode)
        {
            try
            {
                BLLRepository<User> rep_user = new BLLRepository<Entities.User>();
                BLLRepository<Categories> rep_ctg = new BLLRepository<Entities.Categories>();
                BLLRepository<Article> rep_artc = new BLLRepository<Entities.Article>();
                Entities.User user = rep_user.Find(x => x.userCodeID == loginUserCode);
                Entities.Categories ctg = rep_ctg.Find(x => x.categoryCode == categoryCode);
                
                Article lastArticle = null;
                string LastArticleCodeID="";
                try
                {
                    lastArticle = rep_artc.List().OrderByDescending(x => x.articleCodeID).First();
                    LastArticleCodeID = lastArticle.articleCodeID;
                }
                catch (Exception) { }
                string ArticleCodeID;
                ArticleCodeID = getNewArticleCodeID(LastArticleCodeID, "ARTC-00000");
                int insertCount = rep_artc.Insert(new Entities.Article
                {
                    articleCodeID = ArticleCodeID,
                    articleContent = articlecontent,
                    articleSharedDate = DateTime.Now,
                    articleTitle = title,
                    category = ctg,
                    user = user,
                    comments = new List<ArticleComment>(),
                    likes = new List<ArticleLikes>()
                });
                //BLLRepository<ArticleComment> rep_artCommt = new BLLRepository<Entities.ArticleComment>();
                //BLLRepository<ArticleLikes> rep_artLike = new BLLRepository<Entities.ArticleLikes>();
                //rep_artCommt.Insert()

                return "success";
            }
            catch (Exception)
            {

                return "error";
            }

        }

        [HttpPost]
        public string updateArticle(string title, string articlecontent, string articleCode)
        {
            try
            {
                BLLRepository<Article> rep_artc = new BLLRepository<Entities.Article>();
                Article findArticle = null;
                try
                {
                    findArticle = rep_artc.Find(x=>x.articleCodeID== articleCode);
                }
                catch (Exception) { }
                findArticle.articleContent = articlecontent;
                findArticle.articleTitle = title;
                int updateCount = rep_artc.Update();
                return "success";
            }
            catch (Exception)
            {

                return "error";
            }

        }

        private string getNewArticleCodeID(string articleCodeID, string DefaultCode)
        {
            if (!string.IsNullOrEmpty(articleCodeID))
            {
                string articleCodeHead = articleCodeID.Substring(0, 5);
                string articleCodeNumber = articleCodeID.Substring(5, 5);
                int IntarticleCodeNumber = int.Parse(articleCodeNumber);
                IntarticleCodeNumber++;
                articleCodeID = MergeCode(articleCodeHead, IntarticleCodeNumber);
                return articleCodeID;
            }
            else
                return DefaultCode;

        }

        private string MergeCode(string articleCodeHead, int ıntarticleCodeNumber)
        {
            string StringArticleCodeNumber = "";
            if (ıntarticleCodeNumber.ToString().Length <5)
            {
                for (int i = 0; i < 5- ıntarticleCodeNumber.ToString().Length; i++)
                {
                    StringArticleCodeNumber += "0";
                }
                StringArticleCodeNumber += ıntarticleCodeNumber.ToString();
                return articleCodeHead + StringArticleCodeNumber;
            }
            return articleCodeHead + ıntarticleCodeNumber.ToString();
        }

        private void BindInfo()
        {
            try
            {
                if (Session["LoginUser"] != null)
                {
                    Login login = (Login)Session["LoginUser"];
                    User user = login.user;
                    ViewBag.FullName = user.userFirstName + " " + user.userLastName;
                }
            }
            catch (Exception) { }
        }

        [HttpPost]
        public string LoginControl(string username, string password) // Login kontrol işlemini yapan method.
        {
            if (!string.IsNullOrEmpty(username) & !string.IsNullOrEmpty(password)) // kullanıcı adı ve şifre boş değil ise.
            {
                List<Login> Login = dbContext.logins.Where(u => u.loginUserNameID == username & u.loginUserPassword == password).ToList();//Login tanlosuda bu kayıt ver mı?
                if (Login.Count > 0) // Kayıt varsa
                {
                    BindLoginSession(Login[0]); // Kullanıcıya Sessionı yükle
                    return "success"; // Başarılı işlem dönüşü
                }
            }
            return "error";// Başarısız işlem dönüşü
        }

        private void BindLoginSession(Login login) // Sessionu doldur
        {
            Session.Clear(); // sessionu temizle.
            Session["LoginUser"] = login; // Gelen nesneyi sessiona set et.
            Session.Timeout = 30; // session kill süresi 30 dakika olarak ayarlandı
        }
    }
}