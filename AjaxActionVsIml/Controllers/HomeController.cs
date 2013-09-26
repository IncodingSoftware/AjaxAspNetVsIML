namespace AjaxActionVsIml.Controllers
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Incoding.MvcContrib;

    #endregion

    public class HomeController : Controller
    {
        #region Static Fields

        public static Dictionary<string, KeyValueVm> data = GetData();

        #endregion

        #region Http action

        [HttpPost]
        public ActionResult Delete(string id)
        {
            data.Remove(id);
            return IncodingResult.Success();
        }

        [HttpPost]
        public ActionResult DeleteAsp(string id)
        {
            data.Remove(id);
            return PartialView("Index_Asp_Tbody", data.Select(r => r.Value)
                                                      .ToList());
        }

        [HttpGet]
        public ActionResult Fetch()
        {
            return IncodingResult.Success(data.Select(r => r.Value)
                                              .ToList());
        }

        [HttpGet]
        public ActionResult Index()
        {
            data = GetData();
            return View();
        }

        [HttpGet]
        public ActionResult Index_Asp()
        {
            return View(data.Select(r => r.Value)
                            .ToList());
        }

        [HttpGet]
        public ActionResult Index_Iml()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index_Extend_Iml()
        {
            return View();
        }

        #endregion

        static Dictionary<string, KeyValueVm> GetData()
        {
            return new Dictionary<string, KeyValueVm>
                       {
                               { "1", new KeyValueVm("1", "Vlad") }, 
                               { "2", new KeyValueVm("2", "Vlad") }, 
                               { "3", new KeyValueVm("3", "Vlad") }, 
                       };
        }
    }
}