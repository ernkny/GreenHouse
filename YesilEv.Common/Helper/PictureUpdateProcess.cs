using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesilEv.Core.Context;

namespace YesilEv.Common.Helper
{
    public class PictureUpdateProcess
    {
        public List<Picture> UpdatePictureProcess(List<OpenFileDialog> files, List<Picture> pictures)
        {
            Upload upload = new Upload();
            List<OpenFileDialog> openFiles = new List<OpenFileDialog>();
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    if (!String.IsNullOrEmpty(files[i].Title) && !String.IsNullOrEmpty(files[i].FileName) && !(pictures[i].PicturePath is null))
                    {
                        openFiles.Add(files[i]);
                        upload.DeletePicture(pictures[i].PicturePath.ToString());
                        Picture pic = upload.UploadPicture(openFiles).FirstOrDefault(); ;
                        pictures[i].PicturePath = pic.PicturePath.ToString();
                    }
                    openFiles.Clear();
                }
                return pictures;
            }
            catch (Exception)
            {
                return pictures;
                throw;
            }



        }
    }
}
