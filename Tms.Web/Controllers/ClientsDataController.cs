
using Tms.Application.SystemManage;
using Tms.Code;
using Tms.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Tms.Web.Controllers
{
    [HandlerLogin]
    public class ClientsDataController : Controller
    {
        private RoleAuthorizeApp roleAuthorizeApp = new RoleAuthorizeApp();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();
        [HttpGet]
        //[HandlerAjaxOnly]
        public ActionResult GetClientsDataJson()
        {
           
            var data = new
            {
                dataItems = this.GetDataItemList(),
                organize = this.GetOrganizeList(),
                role = this.GetRoleList(),
                duty = this.GetDutyList(),
                user = "",
                // 查出具有的功能菜单和url
                authorizeMenu = this.GetMenuList(),
                // 查出具有的按钮和url
                authorizeButton = this.GetMenuButtonList(),
            };
            var dataTest = new
            {
                roles = "",
                name = "屠圣涛",
                avatar="/avatar.jpg",
                introduction="7777777777"
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        //[HandlerAjaxOnly]
        // 在登录界面 不验证登录是否超时
        [HandlerLogin(false)]
        public ActionResult GetUserInfo()
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();//session里的用户信息
            string roleId = operatorProvider.RoleId;  //用户角色Id

            var moduledata = moduleApp.GetList();
            var buttondata = moduleButtonApp.GetList();
            var authorizedata = new List<RoleAuthorizeEntity>();
            if (!string.IsNullOrEmpty(roleId))
            {
                authorizedata = roleAuthorizeApp.GetList(roleId);
            }
            // 给前端返回一个当前角色的权限Id数组
            List<string> roles = new List<string>();

            // 把模块的id加进去
            foreach (ModuleEntity item in moduledata)
            {
                if (authorizedata.Count(t => t.F_ItemId == item.F_Id) == 1 ? true : false)
                {
                    roles.Add(item.F_Id);
                }
            }

            // 把按钮的id加进去
            foreach (ModuleButtonEntity item in buttondata)
            {
                if (authorizedata.Count(t => t.F_ItemId == item.F_Id) == 1 ? true : false)
                {
                    roles.Add(item.F_Id);
                }
            }
            roles.Add("admin");  //后期删除
            roles.Add("tms"); // 后期删除 
            var dataTest = new
            {
                roles = roles,
                name = "屠圣涛",
                avatar = "https://wpimg.wallstcn.com/f778738c-e4f8-4870-b634-56703b4acafe.gif",
                introduction = "后台模拟的用户信息描述！"
            };
            return Content(dataTest.ToJson());
        }

        private object GetDataItemList()
        {
            var itemdata = new ItemsDetailApp().GetList();
            Dictionary<string, object> dictionaryItem = new Dictionary<string, object>();
            foreach (var item in new ItemsApp().GetList())
            {
                var dataItemList = itemdata.FindAll(t => t.F_ItemId.Equals(item.F_Id));
                Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();
                foreach (var itemList in dataItemList)
                {
                    dictionaryItemList.Add(itemList.F_ItemCode, itemList.F_ItemName);
                }
                dictionaryItem.Add(item.F_EnCode, dictionaryItemList);
            }
            return dictionaryItem;
        }
        private object GetOrganizeList()
        {
            OrganizeApp organizeApp = new OrganizeApp();
            var data = organizeApp.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (OrganizeEntity item in data)
            {
                var fieldItem = new
                {
                    encode = item.F_EnCode,
                    fullname = item.F_FullName
                };
                dictionary.Add(item.F_Id, fieldItem);
            }
            return dictionary;
        }
        private object GetRoleList()
        {
            RoleApp roleApp = new RoleApp();
            var data = roleApp.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity item in data)
            {
                var fieldItem = new
                {
                    encode = item.F_EnCode,
                    fullname = item.F_FullName
                };
                dictionary.Add(item.F_Id, fieldItem);
            }
            return dictionary;
        }
        private object GetDutyList()
        {
            DutyApp dutyApp = new DutyApp();
            var data = dutyApp.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity item in data)
            {
                var fieldItem = new
                {
                    encode = item.F_EnCode,
                    fullname = item.F_FullName
                };
                dictionary.Add(item.F_Id, fieldItem);
            }
            return dictionary;
        }
        private object GetMenuList()
        {
            var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            return ToMenuJson(new RoleAuthorizeApp().GetMenuList(roleId), "0");
        }
        private string ToMenuJson(List<ModuleEntity> data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<ModuleEntity> entitys = data.FindAll(t => t.F_ParentId == parentId);
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = item.ToJson();
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.F_Id) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }
        private object GetMenuButtonList()
        {
            var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            var data = new RoleAuthorizeApp().GetButtonList(roleId);
            var dataModuleId = data.Distinct(new ExtList<ModuleButtonEntity>("F_ModuleId"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (ModuleButtonEntity item in dataModuleId)
            {
                var buttonList = data.Where(t => t.F_ModuleId.Equals(item.F_ModuleId));
                dictionary.Add(item.F_ModuleId, buttonList);
            }
            return dictionary;
        }
    }
}
