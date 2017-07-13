using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MediaController
/// </summary>
public class MediaController
{
    public MediaController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static int Update(MediaModel param)
    {
        int ret = 0;
        MediaModel cmedia = new MediaModel();
        MediaTax mt = new MediaTax();
        try
        {
            if (cmedia.model_Update(param))
            {
                mt.model_DeleteMediaTaxAllbyMID(param.MID);

                if (param.MediaTax.Length > 0)
                {
                    foreach (MediaTax i in param.MediaTax)
                    {
                        ret += mt.model_InsertTax(i);
                    }
                }
            }
            ret = 1;
        }
        catch { }
       
        return ret;
    }


    public static int InsertMedia(MediaModel param)
    {
        MediaModel cmedia = new MediaModel();
        return cmedia.model_INsertMedia(param);
    }

    public static  IList<MediaModel> GetMediaAll(int Taxonomy = 0, string Type ="")
    {
        MediaModel cmedia = new MediaModel();
        return cmedia.model_GetMediaAll(Taxonomy, Type);
    }

    public static bool DeleteMedia(MediaModel param)
    {
        MediaModel cmedia = new MediaModel();

        if (cmedia.model_DeleteMedia(param))
        {
            removeFile(param);
        }
        return true;
    }

    public static bool DeleteMedia(List<MediaModel> param)
    {
        MediaModel cmedia = new MediaModel();

        foreach(MediaModel m in param)
        {
            if (cmedia.model_DeleteMedia(m))
            {
                removeFile(m);
            }
        }
       
        return true;
    }


    private static void removeFile(MediaModel param)
    {
        FileInfo file = new FileInfo(HttpContext.Current.Server.MapPath(  param.Path + param.FileName));
        if (file.Exists)
            file.Delete();
    }


    public static int InsertChildTaxonomy(string param)
    {
        MediaTaxonomy mt = new MediaTaxonomy {
            Title = param
        };

       
        return mt.model_InsertChildTaxonomy(mt);
    }


    public static IList<MediaTaxonomy> GetTaxonomyListByRef(int RefID = 1)
    {
        MediaTaxonomy mt = new MediaTaxonomy { KeyRef = RefID };
       

        return mt.model_GetTaxonomyList(mt);
    }


    public static int InsertMediaTax(List<MediaTax> param)
    {
        MediaTax mt = new MediaTax();
        int ret = 0;
        try
        {
           
            foreach (MediaTax m in param)
            {
                ret += mt.model_InsertTax(m);
            }

            ret = 1;
        }
        catch { }
       

        return ret;
    }

}