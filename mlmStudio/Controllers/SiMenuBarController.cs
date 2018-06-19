using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using mlmStudio.Models;
namespace mlmStudio.Controllers
{
    public class SiMenuBarController : Controller
    {
        //
        // GET: /SiMenuBar/ 
        public ActionResult Index()
        {
            ViewBag.bar = GetMenuBarPage(null);
            return PartialView();
        }


        public MvcHtmlString GetMenuBarPage(Nullable<int> ParentId)
        {
            StringBuilder sb = new StringBuilder();
            SIContext db = new SIContext();
            //get role id and role regarding to role bind this
            var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
            var RoleId = Convert.ToInt32(Env.GetUserInfo("roleid"));

            var q = db.MenuPermissions.Where(i => i.RoleId == RoleId || i.UserId == userId).ToArray();
            sb.Append("<ul class=\"sidebar-menu\">");
            sb.Append("<li class=\"active\"> <a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/Home\"> <i class=\"fa fa-dashboard\"></i> <span>Dashboard</span> </a> </li>");
            if (RoleId == 1)
            { 
            }

            sb.Append(GetMenuBar(ParentId, q));
            sb.Append("</ul>");
            return MvcHtmlString.Create(sb.ToString());
        }




        public MvcHtmlString GetMenuBar(Nullable<int> ParentId, MenuPermission[] q)
        {
            StringBuilder sb = new StringBuilder();
            if (q != null)
            {
                foreach (var item in q.Where(i => i.Menu_MenuId.ParentId == ParentId).OrderBy(i=>i.SortOrder))
                {
                    var js = q;

                    if (js.Count(j => j.Menu_MenuId.ParentId == item.Menu_MenuId.Id) > 0)
                    {
                        if (item.Menu_MenuId.ParentId == null)
                        {
                            sb.Append("<li class=\"treeview\"> <a href=\"#\"> <i class=\"fa fa-folder\"></i> <span>" + item.Menu_MenuId.MenuText + "</span> <i class=\"fa fa-angle-left pull-right\"></i>  </a><ul class=\"treeview-menu\">");
                        }
                        else
                        {
                            sb.Append("<li class=\"treeview\"> <a href=\"#\"> <i class=\"fa fa-folder\"></i> <span>" + item.Menu_MenuId.MenuText + "</span> <i class=\"fa fa-angle-left pull-right\"></i>  </a><ul class=\"treeview-menu\">");
                        }
                        sb.Append(GetMenuBar(item.Menu_MenuId.Id, q));
                    }
                    else
                    {
                        if (item.Menu_MenuId.ParentId == null)
                        {
                            sb.Append("<li class=\"\"> <a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/" + item.Menu_MenuId.MenuURL + "\"><i class=\"fa fa-angle-double-right\"></i>  " + item.Menu_MenuId.MenuText + "</a></li>");
                        }
                        else
                        {
                            sb.Append("<li class=\"\"> <a href=\"" + MicrosoftHelper.MSHelper.GetSiteRoot() + "/" + item.Menu_MenuId.MenuURL + "\"><i class=\"fa fa-angle-double-right\"></i>  " + item.Menu_MenuId.MenuText + "</a></li>");
                        }

                    }

                }
                sb.Append("</ul>");
            }


            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
