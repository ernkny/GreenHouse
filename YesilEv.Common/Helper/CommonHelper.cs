using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Core.Context;
using YesilEv.DAL.Concrete;
using static YesilEv.Common.CommonModel.CategoryHierarchyModel;

namespace YesilEv.Common.Helper
{
    
    public class CommonHelper
    {
        public enum BlokFavType
        {
            favori = 2,
            blok = 1
        }
        public menuList menuLists { get; set; }
        public CommonHelper()
        {
            menuLists = new menuList();
            CategoriesBind();
        }
        private void CategoriesBind()
        {
            CategoryDal catDal = new CategoryDal();
            List<Category> Categories = catDal.GetAll().ToList();
            CategoriesBinder(Categories, 0, 0, menuLists);
        }

        private void CategoriesBinder(List<Category> lst, int parentID, int level, menuList menuLists)
        {
            level++;
            List<Category> pagehiearachy = lst.Where(a => a.ParentId == parentID).ToList<Category>();
            string name, emptyChar;
            int SiradakiUstID;
            foreach (var item in pagehiearachy)
            {
                SiradakiUstID = item.Id;
                name = item.Name;
                emptyChar = new string('-', level * 2);
                Items lstItem = new Items();
                lstItem.Text = emptyChar + name;
                lstItem.Value = item.Id;
                menuLists.Items.Add(lstItem);
                CategoriesBinder(lst, SiradakiUstID, level, menuLists);
            }
        }
    }
}
