using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for OTP
/// </summary>
public class OTP :db
{
    public void SendEmailOTP(string Email, string AccountName, string OTP)
    {
        try
        {
            // Go to Gmail/Accounts/Security/Access for less secure apps=true;


            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(Email); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "MIS OTP for (" + AccountName + " )";
            newmsg.Body = OTP + " is your one time password(OTP) for Email Verification. NEVER share OTP with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
            System.Net.Mail.SmtpClient smtps = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtps.UseDefaultCredentials = false;
            smtps.Credentials = new System.Net.NetworkCredential("alerts@midlandmicrofin.com", "Alert.garry$#21");
            smtps.EnableSsl = true;
            smtps.Send(newmsg);
        }


        catch
        {

        }
    }

    public void SendEmailCredential(string Email, string AccountName, string Password)
    {
        try
        {
            // Go to Gmail/Accounts/Security/Access for less secure apps=true;


            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(Email); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Quick Bill Credentials for (" + AccountName + " )";
            newmsg.Body = AccountName + " is your UserName & " + Password + " is your password. NEVER share your Credentials with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
            System.Net.Mail.SmtpClient smtps = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtps.UseDefaultCredentials = false;
            smtps.Credentials = new System.Net.NetworkCredential("alerts@midlandmicrofin.com", "Alert.garry$#21");
            smtps.EnableSsl = true;
            smtps.Send(newmsg);
        }


        catch
        {

        }
    }

    //public void SendSMS(string MblNo, string Msg)
    //{
    //    string MainUrl = "https://xnrp4.api.infobip.com/sms/1/text/query?"; //Here need to give SMS API URL
    //    string UserName = "midland1234"; //Here need to give username
    //    string Password = "Midland@2468"; //Here need to give Password
    //    //string SenderId = "1";
    //    string strMobileno = MblNo; 
    //    string from = "MMFLtd";
    //    string indiaDltPrincipalEntityId = "1601100000000007265";
    //    string indiaDltContentTemplateId = "1107163706052077082";
    //    string URL = "";
    //    URL = MainUrl + "username=" + UserName + "&password=" + Password + "&to=" + MblNo + "&Text=" + HttpUtility.UrlEncode(Msg).Trim() +
    //        "&indiaDltPrincipalEntityId=" + indiaDltPrincipalEntityId + "&from" + from + "&indiaDltContentTemplateId" + indiaDltContentTemplateId + "";
    //    string strResponce = GetResponse(URL);
    //    string msg = "OTP is";
    //    if (strResponce.Equals("Fail"))
    //    {
    //        msg = "Fail";
    //    }
    //    else
    //    {
    //        msg = strResponce;
    //    }
    //  //  return msg;
    //}
    //// End SMS Sending function
    //// Get Response function
    //public static string GetResponse(string smsURL)
    //{
    //    try
    //    {
    //        WebClient objWebClient = new WebClient();
    //        System.IO.StreamReader reader = new System.IO.StreamReader(objWebClient.OpenRead(smsURL));
    //        string ResultHTML = reader.ReadToEnd();
    //        return ResultHTML;
    //    }
    //    catch (Exception ex)
    //    {
    //        return "Fail";
    //    }
    //}

}