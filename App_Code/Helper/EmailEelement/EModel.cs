using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EModel
/// </summary>
public class EModel
{
    public List<elements> elements { get; set; }
    public string html { get; set; }
    public emailSetting emailSettings { get; set; }
}

public class elements
{
    public string type { get; set; }
    public e_options options { get; set; }
    public string id { get; set; }
    public string component { get; set; }

}

public class e_options
{
    public string align { get; set; }
    public string title { get; set; }
    public string subTitle { get; set; }
    public string[] padding { get; set; }
    public string backgroundColor { get; set; }
    public string text { get; set; }
    public string color { get; set; }
    public string iframeVideo { get; set; }
    public string fullWidth { get; set; }


    public string image { get; set; }
    public string width { get; set; }
    public string buttonText { get; set; }

    public string url { get; set; }
    public string buttonBackgroundColor { get; set; }
    public string image1Hide { get; set; }
    public string image1 { get; set; }
    public string image2Hide { get; set; }
    public string image2 { get; set; }
    public string image3Hide { get; set; }
    public string image3 { get; set; }
    public string width1 { get; set; }
    public string width2 { get; set; }
    public string width3 { get; set; }
    public string text1 { get; set; }
    public string text2 { get; set; }
    public string text3 { get; set; }

    public string html { get; set; }
    public string facebookLink { get; set; }
    public string twitterLink { get; set; }
    public string linkedinLink { get; set; }
    public string youtubeLink { get; set; }
}


public class emailSetting
{
    public e_soptions options { get; set; }
    public string type { get; set; }

}

public class e_soptions
{
    public string paddingTop { get; set; }
    public string paddingLeft { get; set; }
    public string paddingBottom { get; set; }
    public string paddingRight { get; set; }
    public string backgroundColor { get; set; }

}