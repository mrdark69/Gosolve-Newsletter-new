using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using TheArtOfDev.HtmlRenderer.WinForms;

/// <summary>
/// Summary description for HtmlToImage
/// </summary>
public class HtmlToImage
{
    public HtmlToImage()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void ConvertHtmlToImage(string Path, string Filename, string html)
    {
     
        //PointF point = new PointF(0, 0);
        //SizeF maxSize = new System.Drawing.SizeF();

        Image img = HtmlRender.RenderToImage(html);
        Bitmap m_Bitmap = new Bitmap(img);

        //HtmlRender.RenderToImage(Graphics.FromImage(m_Bitmap), html,
        //                                         point, maxSize);


       
        string path = HttpContext.Current.Server.MapPath(Path + Filename);

        m_Bitmap.Save(path, ImageFormat.Png);
    }
}