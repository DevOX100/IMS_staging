using System;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using ClosedXML.Excel;
using Spire.Xls;

/// <summary>
/// Summary description for IP
/// </summary>


public class TrackIP : db
{
    //public string GetIPAddress()
    //{
    //    String address = "";
    //    WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
    //    using (WebResponse response = request.GetResponse())
    //    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
    //    {
    //        address = stream.ReadToEnd();
    //    }

    //    int first = address.IndexOf("Address: ") + 9;
    //    int last = address.LastIndexOf("</body>");
    //    address = address.Substring(first, last - first);

    //    return address;
    //}

    public string GetIp()
    {
        string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(ip))
        {
            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        return ip;
    }

    public string GetMacAddress()
    {
        string macAddresses = string.Empty;

        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.OperationalStatus == OperationalStatus.Up)
            {
                macAddresses += nic.GetPhysicalAddress().ToString();
                break;
            }
        }

        return macAddresses;
    }
}