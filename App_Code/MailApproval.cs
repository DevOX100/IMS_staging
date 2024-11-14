using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for MailApproval
/// </summary>
public class MailApproval :db
{
    public void SendMailFromCreatorToApproval(string Email, string AccountName, string UserName, string UserCode, string LastPaymentDate, string InvoiceNo)
    {
        try
        {
            // Go to Gmail/Accounts/Security/Access for less secure apps=true;

            //string mailBody = "Hi <strong>" + AccountName + " ,</strong><br />" + " is your UserName & " + "<b>" + Password + "</b>" + " is your password."
            //    + "<font color=red>" + "NEVER share your Credentials with anyone." + "</font>"
            //    + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";


            string mailBody = "Dear " + AccountName + " ,<br /><br />" + "This Invoice is created by " + "<b>" + UserName + " ( " + UserCode + " ) </b>" + " and Payment Due Date is "
                + "<b>" + LastPaymentDate + "</b>" + ".<br/> Kinldy Approve Invoice" + "<b> ( " + InvoiceNo + " ) </b>" + ".<br></br>"
                + "<br/><a style='color:red;font-family:Georgia;font-size:145%;' href ='https://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Approve</a>"
                + "<br/><hr/>";

            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(Email); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Quick Bill Invoice (" + InvoiceNo + " ) for Approval";
            //newmsg.Body =  AccountName  + " is your UserName & " + Password + " is your password. NEVER share your Credentials with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
            newmsg.Body = mailBody;
            newmsg.IsBodyHtml = true;

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

    public void SendMailForForwardApproval(string Email, string AccountName, string UserName, string UserCode, string LastPaymentDate, 
        string InvoiceNo, string ReasonOfForward)
    {
        try
        {

            string mailBody = "Dear " + AccountName + " ,<br /><br />" + "This Invoice is Forwarded by " + "<b>" + UserName + " ( " + UserCode + " ) </b>" + " and Payment Due Date is "
                + "<b>" + LastPaymentDate + "</b>" + ".<br/> <b>Reason of Forward : </b>" + ReasonOfForward + "<br></br>"+
                "<br/> Kinldy Approve Invoice" + "<b> ( " + InvoiceNo + " ) </b>" + "<br></br>"
                + "<br/><a style='color:red;font-family:Georgia;font-size:145%;' href ='https://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Approve</a>"
                + "<br/><hr/>";

            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(Email); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Quick Bill Invoice (" + InvoiceNo + " ) for Forward Approval";
            //newmsg.Body =  AccountName  + " is your UserName & " + Password + " is your password. NEVER share your Credentials with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
            newmsg.Body = mailBody;
            newmsg.IsBodyHtml = true;

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

    //public void SendMailFromApprovalToPayment(string Email, string Create, string Approval, string LastPaymentDate, string InvoiceNo)
    //{
    //    try
    //    {
    //        string mailBody = "Dear Account Team,<br /><br />" + "This Invoice is created by " + "<b>" + Create + "</b>"
    //            + " and Approved by " + "<b>" + Approval + "</b>"
    //            + ". It's Payment Due Date is "
    //            + "<b>" + LastPaymentDate + "</b>" + ".<br/> Please do the Payment before the Due Date.<br></br>"
    //            + "<br/><a style='color:red;font-family:Georgia;font-size:145%;' href ='http://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Payment</a>"
    //            + "<br/><hr/>";

    //        System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
    //        System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(Email); // ToMail
    //        System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
    //        newmsg.Subject = "Quick Bill Invoice (" + InvoiceNo + " ) for Payment";
    //        //newmsg.Body =  AccountName  + " is your UserName & " + Password + " is your password. NEVER share your Credentials with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
    //        newmsg.Body = mailBody;
    //        newmsg.IsBodyHtml = true;

    //        System.Net.Mail.SmtpClient smtps = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
    //        smtps.UseDefaultCredentials = false;
    //        smtps.Credentials = new System.Net.NetworkCredential("alerts@midlandmicrofin.com", "Alert.garry$#21");
    //        smtps.EnableSsl = true;
    //        smtps.Send(newmsg);
    //    }

    //    catch
    //    {

    //    }
    //}

    public void SendMailFromPaymentToCreator(string Email, string AccountName, string InvoiceNo, string InvoiceAmt, string DateofInvoice,
        string PaymentDueDate, string DateofPayment, string UTRNo, string DepartmentName, string VendorName, string InvoiceAttatchment, string TransactionDate)
    {
        try
        {

            string mailBody = "Dear " + AccountName + " ,<br /><br />" + "Payment successfully paid by Account Team. Now you can Track your Invoice.<br></br>"
                + "<br/>" +
                "<table border=" + 5 + " cellpadding=" + 2 + " cellspacing=" + 0 + "><tr>" +
                 "<th> Invoice No. </th>" + 
                 "<th> Date of Invoice </th>" +
                 "<th> Vendor Name </th>" +
                 "<th> Department Name </th>" +
                 "<th>Payment Due Date</th>" +
                  "<th>Date of Payment</th>" +
                  "<th>Transaction Date</th>" +
                  "<th>Invoice Total Amount</th>" +
                   "<th>UTR No.</th>" +
                 "<tr/><tr>" +
                 "<td>" + InvoiceNo + "</td>" + 
                 "<td>" + DateofInvoice + "</td>" +
                 "<td>" + VendorName + "</td>" +
                 "<td>" + DepartmentName + "</td>" +
                 "<td>" + PaymentDueDate + "</td>" +
                 "<td>" + DateofPayment + "</td>" +
                 "<td>" + TransactionDate + "</td>" +
                 "<td>" + InvoiceAmt + "</td>" +
                 "<td>" + UTRNo + "</td>" +
              "</tr></table>" +
            "<br/><b><a style='font-family:Georgia;font-size:145%;' href ='https://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Track.</a></b>"
                + "<br/>"+
                  "<br/><br/><span style='color:red;font-family:Georgia;font-size:120%;'>" +
                  "Note : If you face any issue regarding payment then Kindly contact with Account Team.</span>"
                + "<br/><hr/>";

            
            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(Email); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Quick Bill Invoice (" + InvoiceNo + " ) Payment Successfully Done";
            //newmsg.Body =  AccountName  + " is your UserName & " + Password + " is your password. NEVER share your Credentials with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
            newmsg.Body = mailBody;
            newmsg.IsBodyHtml = true;
            //newmsg.Attachments.Add(new Attachment(Microsoft.SqlServer.Server.Map("~\\Upload\\Invoice\\" + InvoiceAttatchment)));
            System.Net.Mail.SmtpClient smtps = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtps.UseDefaultCredentials = false;
            smtps.Credentials = new System.Net.NetworkCredential("alerts@midlandmicrofin.com", "Alert.garry$#21");
            smtps.EnableSsl = true;
            smtps.Send(newmsg);
        }

        catch(Exception ex)
        {

        }
    }


    public void SendMailFromApprovalToSendBack(string SendBackEmail, string AccountName, string UserName, string UserCode, string LastPaymentDate, string SendBackReason,
        string InvoiceNo)
    {
        try
        {
            // Go to Gmail/Accounts/Security/Access for less secure apps=true;

            //string mailBody = "Hi <strong>" + AccountName + " ,</strong><br />" + " is your UserName & " + "<b>" + Password + "</b>" + " is your password."
            //    + "<font color=red>" + "NEVER share your Credentials with anyone." + "</font>"
            //    + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";


            string mailBody = "Dear " + AccountName + " ,<br /><br />" + "This Invoice is Send Back by " + "<b>" + UserName + 
                " ( " + UserCode + " ) </b>" + " with " + "<b>" + SendBackReason + "</b> Reason" +". Kindly check and do the Rectification Before Payment Due Date." + "<br/>" +
                " Payment Due Date is " + "<b>" + LastPaymentDate + "</b>" + ". Kinldy Do the Rectification of Invoice" + "<b> " + "( " + InvoiceNo + " ) </b>" + ".<br></br>"
                + "<br/><a style='color:red;font-family:Georgia;font-size:145%;' href ='https://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Rectification</a>"
                + "<br/><hr/>";

            
            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(SendBackEmail); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Quick Bill Invoice (" + InvoiceNo + " ) for Rectification";
            //newmsg.Body =  AccountName  + " is your UserName & " + Password + " is your password. NEVER share your Credentials with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
            newmsg.Body = mailBody;
            newmsg.IsBodyHtml = true;

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

    public void SendMailFromCreatorToApprovalAfterSendBack(string Email, string AccountName, string UserName, string UserCode, 
        string LastPaymentDate, string InvoiceNo, string RectificationRemarks)
    {
        try
        {
            // Go to Gmail/Accounts/Security/Access for less secure apps=true;

            //string mailBody = "Hi <strong>" + AccountName + " ,</strong><br />" + " is your UserName & " + "<b>" + Password + "</b>" + " is your password."
            //    + "<font color=red>" + "NEVER share your Credentials with anyone." + "</font>"
            //    + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";


            string mailBody = "Dear " + AccountName + " ,<br /><br />" + "This Invoice is created by " + "<b>" + UserName + " ( " + UserCode + " ) </b>" + " and Payment Due Date is "
                + "<b>" + LastPaymentDate + "</b>" + ".<br/> Invoice Rectifications also done by " + UserName + " with <b>" + RectificationRemarks + "</b> Remarks. Kinldy Approve Invoice" + "<b> ( " + InvoiceNo + " ) </b>" + ".<br></br>"
                + "<br/><a style='color:red;font-family:Georgia;font-size:145%;' href ='https://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Approve</a>"
                + "<br/><hr/>";

            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(Email); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Quick Bill Invoice (" + InvoiceNo + " ) for Approval";
            //newmsg.Body =  AccountName  + " is your UserName & " + Password + " is your password. NEVER share your Credentials with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
            newmsg.Body = mailBody;
            newmsg.IsBodyHtml = true;

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

    //Baljinder Kaur  Confirmation Or Recommendation
    public void SendMailFromApprovalToRecommendation(string ApprovalUserEmail, string ApprovalUserName, string UserName, string UserCode,
        string LastPaymentDate, string InvoiceNo, string ConfirmationRemarks, string RecommendedBy)
    {
        try
        {


            string mailBody = "Dear " + ApprovalUserName + " ,<br /><br />" + "This Invoice is Created By " + "<b>" + UserName + " ( " + UserCode + " ) </b>" + 
                " and Recommended to you By " + "<b>" + RecommendedBy + "</ b >" + " with <br/> <b>" + ConfirmationRemarks + "</b> Remarks. Payment Due Date is "
                + "<b>" + LastPaymentDate + "</b>." + " Kinldy Approve Invoice" + "<b> ( " + InvoiceNo + " ) </b>" + ".<br></br>"
                + "<br/><a style='color:red;font-family:Georgia;font-size:145%;' href ='https://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Approve</a>"
                + "<br/><hr/>";

            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(ApprovalUserEmail); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Quick Bill Invoice (" + InvoiceNo + " ) for Confirmation";

            newmsg.Body = mailBody;
            newmsg.IsBodyHtml = true;

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


    public void SendMailFromApprovalToVerfication(string Email, string Create, string Approval, string LastPaymentDate, string InvoiceNo)
    {
        try
        {
            string mailBody = "Dear Account Verification Team,<br /><br />" + "This Invoice is created by " + "<b>" + Create + "</b>"
                + " and Approved by " + "<b>" + Approval + "</b>"
                + ". It's Payment Due Date is "
                + "<b>" + LastPaymentDate + "</b>" + ".<br/> Please do the verification before the Payment Due Date.<br></br>"
                + "<br/><a style='color:red;font-family:Georgia;font-size:145%;' href ='https://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Verification</a>"
                + "<br/><hr/>";

            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(Email); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Quick Bill Invoice (" + InvoiceNo + " ) for Verification";
            //newmsg.Body =  AccountName  + " is your UserName & " + Password + " is your password. NEVER share your Credentials with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
            newmsg.Body = mailBody;
            newmsg.IsBodyHtml = true;

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


    public void SendMailFromConfirmationToVerfication(string Email, string Create, string Approval, string Confirmed, string ConfirmedRemarks,
        string LastPaymentDate, string InvoiceNo)
    {
        try
        {
            string mailBody = "Dear Account Verification Team,<br /><br />" + "This Invoice is created by " + "<b>" + Create + "</b>"
                + " and Approved by " + "<b>" + Approval + "</b>"
                + " and Confirmed by " + "<b>" + Confirmed + "</b>" + " with " + "<b>" + ConfirmedRemarks + "</b>" + " Remarks. "
                + ". Invoice Payment Due Date is "
                + "<b>" + LastPaymentDate + "</b>" + ".<br/> Please do the verification before the Payment Due Date.<br></br>"
                + "<br/><a style='color:red;font-family:Georgia;font-size:145%;' href ='https://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Verification</a>"
                + "<br/><hr/>";

            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(Email); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Quick Bill Invoice (" + InvoiceNo + " ) for Verification";
            //newmsg.Body =  AccountName  + " is your UserName & " + Password + " is your password. NEVER share your Credentials with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
            newmsg.Body = mailBody;
            newmsg.IsBodyHtml = true;

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



    public void SendMailFromVerificationToPayment(string Email, string Create, string Approval, string LastPaymentDate, string InvoiceNo, 
        string Confirmed, string Verified, string VerifiedRemarks)
    {
        try
        {
            string mailBody = "Dear Account Payment Team,<br /><br />" + "This Invoice is created by " + "<b>" + Create + "</b>"
                + " and Approved by " + "<b>" + Approval + "</b>" + " and Confirmed by " + "<b>" + Confirmed + "</b>"
                + " and Verified by " + "<b>" + Verified + "</b> with " + VerifiedRemarks 
                + " Remarks. It's Payment Due Date is "
                + "<b>" + LastPaymentDate + "</b>" + ".<br/> Please do the Payment before the Due Date.<br></br>"
                + "<br/><a style='color:red;font-family:Georgia;font-size:145%;' href ='https://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Payment</a>"
                + "<br/><hr/>";

            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(Email); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Quick Bill Invoice (" + InvoiceNo + " ) for Payment";
            //newmsg.Body =  AccountName  + " is your UserName & " + Password + " is your password. NEVER share your Credentials with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
            newmsg.Body = mailBody;
            newmsg.IsBodyHtml = true;

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

    public void SendMailFromApprovalToFinalRecommendation(string ApprovalUserEmail, string ApprovalUserName, string UserName, string UserCode,
    string LastPaymentDate, string InvoiceNo, string Remarks, string RecommendedBy)
    {
        try
        {


            string mailBody = "Dear " + ApprovalUserName + " ,<br /><br />" + "This Invoice is created by " + "<b>" + UserName + " ( " + UserCode + " ) </b>" +
              " and Recommended to you by " + "<b>" + RecommendedBy + "</b>" + " with <br/> <b>" + Remarks + "</b> Remarks. Invoice payment due date is "
              + "<b>" + LastPaymentDate + "</b>." + " Kinldy approve the invoice" + "<b> ( " + InvoiceNo + " ) </b>" + " before its due date.<br></br>"
              + "<br/><a style='color:red;font-family:Georgia;font-size:145%;' href ='https://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Approve</a>"
              + "<br/><hr/>";

            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(ApprovalUserEmail); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Quick Bill Invoice (" + InvoiceNo + " ) for Final Approval";

            newmsg.Body = mailBody;
            newmsg.IsBodyHtml = true;

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

 public void SendMailFromFinalConfirmationToVerfication(string Email, string Create, string Approval, string Confirmed, string FinalConfirmed, 
        string FinalConfirmedRemarks, string LastPaymentDate, string InvoiceNo)
    {
        try
        {
            string mailBody = "Dear Account Verification Team,<br /><br />" + "This Invoice is" +
                "<br/> " +
                "<table border=" + 5 + " cellpadding=" + 2 + " cellspacing=" + 0 + "><tr>" +
                 "<th> Created by </th>" +
                 "<th> Approved by </th>" +
                 "<th> Confirmed by </th>" +
                 "<th> Final Confirmed by </th>" +
                 "<th>Final Confirmation Remarks</th>" +
                  "<th>Date of Payment</th>" +
                 "<tr/><tr>" +
                 "<td>" + Create + "</td>" +
                 "<td>" + Approval + "</td>" +
                 "<td>" + Confirmed + "</td>" +
                 "<td>" + FinalConfirmed + "</td>" +
                 "<td>" + FinalConfirmedRemarks + "</td>" +
                 "<td>" + LastPaymentDate + "</td>" +
              "</tr></table> <br/>" +
              //"created by " + "<b>" + Create + "</b>"
              //  + " and Approved by " + "<b>" + Approval + "</b>"+ " and Confirmed by (Recommended 1)" + "<b>" + Confirmed + "</b>"
              //  + " and Final Confirmed by " + "<b>" + FinalConfirmed + "</b>"+ " with " + "<b>" + FinalConfirmedRemarks + "</b>" + " Remarks. "
              //  + ". Invoice Payment Due Date is "
              //  + "<b>" + LastPaymentDate + "</b>" + ".<br/> 
              "Please do the verification before the payment due date.<br></br>"
                + "<br/><a style='color:red;font-family:Georgia;font-size:145%;' href ='https://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Verification</a>"
                + "<br/><hr/>";

            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(Email); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Quick Bill Invoice (" + InvoiceNo + " ) for Verification";
            //newmsg.Body =  AccountName  + " is your UserName & " + Password + " is your password. NEVER share your Credentials with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
            newmsg.Body = mailBody;
            newmsg.IsBodyHtml = true;

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


    public void SendMailFromOnBoardingVendorToDepartment(string Email, string DeptName, string Vname)
    {
        try
        {
            // Go to Gmail/Accounts/Security/Access for less secure apps=true;

            //string mailBody = "Hi <strong>" + AccountName + " ,</strong><br />" + " is your UserName & " + "<b>" + Password + "</b>" + " is your password."
            //    + "<font color=red>" + "NEVER share your Credentials with anyone." + "</font>"
            //    + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";


            string mailBody = "Dear " + DeptName + " Team," + "<br /><br />" + " The Vendor has successfully complete their onboarding form, So kindly check the same in the portal and do the further process."
                + "<br/><a style='color:red;font-family:Georgia;font-size:145%;' href ='https://eport.midlandmicrofin.co.in/QuickBill/Account/Login.aspx'>Click Here for Track Vendor</a>"
                + "<br/><hr/>";

            System.Net.Mail.MailAddress mailfrom = new System.Net.Mail.MailAddress("alerts@midlandmicrofin.com"); //from Email
            System.Net.Mail.MailAddress mailto = new System.Net.Mail.MailAddress(Email); // ToMail
            System.Net.Mail.MailMessage newmsg = new System.Net.Mail.MailMessage(mailfrom, mailto);
            newmsg.Subject = "Request For Vendor Approval (" + Vname + ")";
            //newmsg.Body =  AccountName  + " is your UserName & " + Password + " is your password. NEVER share your Credentials with anyone." + "\n" + "For any help please contact us at (itsupport@midlandmicrofin.com)";
            newmsg.Body = mailBody;
            newmsg.IsBodyHtml = true;

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
}