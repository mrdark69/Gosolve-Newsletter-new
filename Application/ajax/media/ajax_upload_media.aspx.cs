using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MVCDatatableApp;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNet.Identity;
using Excel;
using System.Data;
using System.Data.OleDb;
using Newtonsoft.Json.Linq;
using System.Threading;


public partial class Application_ajax_upload_media : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        DateTime Date = DatetimeHelper._UTCNow();

        int intYear = Date.Year;
        int intmonth = Date.Month;

        string strath = AppTools.UploadMediaPath();
        string FullPath = strath + intYear + "/" + intmonth.ToString().PadLeft(2, '0') + "/";
        string ServerPath = HttpContext.Current.Server.MapPath(FullPath);
        DirectoryInfo cd = new DirectoryInfo(ServerPath);

        if (!cd.Exists)
            cd.Create();



        foreach (string s in Request.Files)
        {
            string strfileName = string.Empty;
            string strExtension = string.Empty;
            string strTitle = string.Empty;

            string strFileSize = string.Empty;
            string strFileType = string.Empty;
            string FileDimension = string.Empty;


            try
            {
                HttpPostedFile file = Request.Files[s];
                int fileSizeInBytes = file.ContentLength;



                strFileType = file.ContentType;
                strFileSize = file.ContentLength.ToString();

                string FileFullPath = ServerPath + "/" + file.FileName;

                //get filename only
                string fileNameOnly = Path.GetFileNameWithoutExtension(FileFullPath);
                string extension = Path.GetExtension(FileFullPath);

                strTitle = fileNameOnly;

                fileNameOnly = fileNameOnly.Replace('-', ' ');
                fileNameOnly = fileNameOnly.Replace(' ', '-');

                strExtension = extension;

                string FileFullPath_replace = ServerPath + "/" + fileNameOnly + extension;
                FileInfo fileinfo = new FileInfo(FileFullPath_replace);

                string savedFileName = FileFullPath_replace;
                if (fileinfo.Exists)
                {
                    int count = 1;



                    string path = Path.GetDirectoryName(FileFullPath_replace);


                    while (File.Exists(savedFileName))
                    {
                        string tempFileName = string.Format("{0}-{1}", fileNameOnly, count++);
                        strfileName = tempFileName;
                        savedFileName = Path.Combine(path, tempFileName + extension);
                    }
                }
                else
                {
                    strfileName = fileNameOnly;
                    savedFileName = Path.Combine(ServerPath, fileNameOnly + extension);
                }




                file.SaveAs(savedFileName);

                if (strFileType.Contains("image"))
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(savedFileName);
                    FileDimension = img.Width + "-" + img.Height;
                }
            }
            catch { throw; }



            MediaController.InsertMedia(new MediaModel
            {
                FileName = strfileName + strExtension,
                Extension = strExtension,
                Alt = "",
                FileType = strFileType,
                Path = FullPath,
                Slug = "",
                Priority = 1,
                Title = strTitle,
                Dimensions = FileDimension,
                FileSize = strFileSize
            });
        }
    }







}