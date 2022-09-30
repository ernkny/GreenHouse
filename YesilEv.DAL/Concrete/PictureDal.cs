using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Core.Concrete;
using YesilEv.Core.Context;
using YesilEv.DAL.Abstract;

namespace YesilEv.DAL.Concrete
{
    public class PictureDal:EFRepositoryBase<Picture, GreenHouse>, IPictureDal
    {
        public bool UpdatePicturePath(int id, string picturepath)
        {
            using (GreenHouse db = new GreenHouse())
            {
                var pictureResult = db.Picture.Where(x => x.Id == id).FirstOrDefault();
                pictureResult.PicturePath = picturepath;
                var res = db.Entry(pictureResult);
                res.State = EntityState.Modified;
                var s = db.SaveChanges();
            }
            return true;
        }
    }
}
