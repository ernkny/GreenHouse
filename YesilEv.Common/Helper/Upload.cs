using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using YesilEv.Core.Context;
using System.Windows.Forms;

namespace YesilEv.Common.Helper
{
    public class Upload
    {
        public List<Picture> UploadPicture(List<OpenFileDialog> _opfiles)
        {
            List<Picture> PictureResult = new List<Picture>();
            string appPath = Path.GetDirectoryName(Directory.GetCurrentDirectory()) + @"\Upload\Pictures\";
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }
            foreach (var opfile in _opfiles)
            {
                try
                {
                    string iName = Guid.NewGuid().ToString();
                    string filepath = opfile.FileName;
                    string picturePath = Path.Combine(filepath, appPath, iName);
                    File.Copy(filepath, appPath + iName);
                    Picture pic = new Picture();
                    pic.PicturePath = picturePath;
                    PictureResult.Add(pic);

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Dosya yüklenemedi " + exp.Message);
                    return null;
                }
            }
            return PictureResult;
        }

        public bool DeletePicture(string picturePath)
        {
            try
            {
                System.IO.File.Delete(picturePath);
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

    }
}
