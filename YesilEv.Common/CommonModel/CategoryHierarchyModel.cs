using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Common.CommonModel
{
    public class CategoryHierarchyModel
    {
        public class menuList
        {
            public List<Items> Items { get; set; } = new List<Items>();
            public int parentID { get; set; }
        }
        public class Items
        {
            public Items()
            {

            }
            public Items(string value, string text)
            {

            }
            public int Value { get; set; }
            public string Text { get; set; }
            public bool? IsSelected { get; set; }

        }
    }
}
