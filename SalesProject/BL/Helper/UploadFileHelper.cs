using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.BL.Helper
{
    public class UploadFileHelper
    {

        public static string SaveFile(IFormFile FileUrl, string FolderName)
        {
            // Get Directory
            string FilePath = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName;
            // Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);
            // Merge The Directory with File Name
            string FinalPath = Path.Combine(FilePath, FileName);

            using (var stream = new FileStream(FinalPath, FileMode.Create))
            {
                FileUrl.CopyTo(stream);
            }

            return FileName;
        }

        public static void RemoveFile(string FolderName, string RemovedFileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + RemovedFileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + RemovedFileName);
            }
        }

    }
}
