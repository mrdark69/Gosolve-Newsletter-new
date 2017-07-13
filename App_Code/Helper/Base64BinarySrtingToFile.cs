using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Base64BinarySrtingToFile
/// </summary>
public class Base64BinarySrtingToFile
{
    public string Path { get; set; }
    public string FileName { get; set; }
    public string Format { get; set; }
    public string FilePrefix { get; set; }
    public bool IsSaved { get; set; }
    public string  Error { get; set; }
    public string ErrorDetail { get; set; }

    public Base64BinarySrtingToFile()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void SaveFileNew(string Key)
    {
        try
        {

            this.Path = AppTools.ImportPath();
            string path = HttpContext.Current.Server.MapPath(this.Path);


            HttpPostedFile filedata = HttpContext.Current.Request.Files[Key];
            
            FileInfo file = new FileInfo(path + filedata.FileName);

            string extension = file.Extension;
          

            if (file.Exists)
                file.Delete();


            // string name = DateTime.Now.ToString("hhmmss");

            if (extension.Contains("xlsx"))
            {
                this.Format = "excel";
            }
            
            if (extension.Contains("csv"))
            {
                this.Format = "csv";
            }
            
            

            switch (this.Format)
            {
                case "csv":
                    this.FileName = "csv_" + (String.IsNullOrEmpty(this.FilePrefix) ? "" : this.FilePrefix) + ".csv";


                    break;
                case "excel":
                    this.FileName = "excel_" + (String.IsNullOrEmpty(this.FilePrefix) ? "" : this.FilePrefix) + ".xlsx";
                    break;
            }

            //string savedFileName = Path.Combine(ServerPath, fileNameOnly + extension);
            string paths = HttpContext.Current.Server.MapPath(this.Path + this.FileName);

            filedata.SaveAs(paths);

         

            this.IsSaved = true;

        }
        catch (Exception ex)
        {
            // result = "Error : " + ex;
            this.IsSaved = false;
            this.Error = this.FileName + ":" + this.Format + ":" + ex.Message;
            this.ErrorDetail = ex.StackTrace;

        }
    }

    public void SaveFile(string Based64BinaryString)
    {
  
      
        try
        {
           
            this.Path = AppTools.ImportPath();
            string path = HttpContext.Current.Server.MapPath(this.Path);

            FileInfo file = new FileInfo(path + this.FileName);

            if (file.Exists)
                file.Delete();
            // string name = DateTime.Now.ToString("hhmmss");

            if (Based64BinaryString.Contains("data:application/zip;base64,"))
            {
                this.Format = "zip";
            }
            if (Based64BinaryString.Contains("data:;base64,"))
            {
                this.Format = "zip";
            }
            if (Based64BinaryString.Contains("data:image/jpeg;base64,"))
            {
                this.Format = "jpg";
            }
            if (Based64BinaryString.Contains("data:image/png;base64,"))
            {
                this.Format = "png";
            }
            if (Based64BinaryString.Contains("data:text/plain;base64,"))
            {
                this.Format = "txt";
            }
            if (Based64BinaryString.Contains("data:text/csv;base64,"))
            {
                this.Format = "csv";
            }
            if (Based64BinaryString.Contains("data:application/vnd.ms-excel;base64,"))
            {
                this.Format = "csv";
            }

            if (Based64BinaryString.Contains("data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,"))
            {
                this.Format = "excel";
            }

            string str = Based64BinaryString.Replace("data:image/jpeg;base64,", " ");//jpg check
            str = str.Replace("data:image/png;base64,", " ");//png check
            str = str.Replace("data:text/plain;base64,", " ");//text file check
            str = str.Replace("data:;base64,", " ");//zip file check
            str = str.Replace("data:application/zip;base64,", " ");//zip file check
            str = str.Replace("data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,", " ");//Excel file check
            str = str.Replace("data:text/csv;base64,", " ");//text file check
            str = str.Replace("data:application/vnd.ms-excel;base64,", " ");//text file check




            switch (this.Format)
            {
                case "csv":
                    this.FileName = "csv_" +  (String.IsNullOrEmpty(this.FilePrefix) ? "" : this.FilePrefix) + ".csv";

                  
                    break;
                case "excel":
                    this.FileName = "excel_" + (String.IsNullOrEmpty(this.FilePrefix) ? "" : this.FilePrefix) + ".xlsx";
                    break;
            }


            string paths = HttpContext.Current.Server.MapPath(this.Path + this.FileName);

            byte[] data = Convert.FromBase64String(str);
            File.WriteAllBytes(paths, data);





          
            //result = "image uploaded successfully";

            //if (format == "zip")
            //{
            //    using (MemoryStream stream = new MemoryStream(data))
            //    {
            //        using (ZipFile zip = new ZipFile("66"))
            //        {
            //            zip.AddEntry("mainContent.zip", stream);
            //            zip.Save(path + "/file" + name + ".zip");
            //            result = "file uploaded succesfully";
            //        }
            //    }
            //}
            //else
            //{
            //    MemoryStream ms = new MemoryStream(data, 0, data.Length);
            //    ms.Write(data, 0, data.Length);
            //    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            //    image.Save(path + "/Image" + name + ".jpg");
            //    result = "image uploaded successfully";
            //}

            this.IsSaved = true;
            
        }
        catch (Exception ex)
        {
            // result = "Error : " + ex;
             this.IsSaved = false;
            this.Error = this.FileName + ":" +  this.Format  + ":"+  ex.Message;
            this.ErrorDetail = ex.StackTrace;
           
        }
    }

    static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

    public static string SizeSuffix(Int64 value, int decimalPlaces = 1)
    {
        if (value < 0) { return "-" + SizeSuffix(-value); }
        if (value == 0) { return "0.0 bytes"; }

        // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
        int mag = (int)Math.Log(value, 1024);

        // 1L << (mag * 10) == 2 ^ (10 * mag) 
        // [i.e. the number of bytes in the unit corresponding to mag]
        decimal adjustedSize = (decimal)value / (1L << (mag * 10));

        // make adjustment when the value is large enough that
        // it would round up to 1000 or more
        if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
        {
            mag += 1;
            adjustedSize /= 1024;
        }

        return string.Format("{0:n" + decimalPlaces + "} {1}",
            adjustedSize,
            SizeSuffixes[mag]);
    }
}