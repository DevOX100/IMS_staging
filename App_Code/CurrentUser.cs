using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Security;
    public  class CurrentUser
    {
        public static string JsonToken
        {
            get
            {
                FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                FormsAuthenticationTicket ticket = identity.Ticket;
                MyFormTicketClass myFormTicket = JsonConvert.DeserializeObject<MyFormTicketClass>((ticket.UserData).ToString());
                return myFormTicket.JsonToken;


            }
        }

        public static DateTime TokenExpireTime
        {
            get
            {
                FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                FormsAuthenticationTicket ticket = identity.Ticket;
                MyFormTicketClass myFormTicket = JsonConvert.DeserializeObject<MyFormTicketClass>((ticket.UserData).ToString());
                return Convert.ToDateTime(  myFormTicket.TokenExpireTime);
            }
        }



        public static string UserId
        {
            get {
                FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                FormsAuthenticationTicket ticket = identity.Ticket;
                MyFormTicketClass myFormTicket = JsonConvert.DeserializeObject<MyFormTicketClass>((ticket.UserData).ToString());
                return myFormTicket.UserId;
            }
        }

        public static string studentName
        {
            get {
                FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                FormsAuthenticationTicket ticket = identity.Ticket;
                MyFormTicketClass myFormTicket = JsonConvert.DeserializeObject<MyFormTicketClass>((ticket.UserData).ToString());
                return myFormTicket.studentName;
            }
        }

        public static string userType
        {
            get
            {
                FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                FormsAuthenticationTicket ticket = identity.Ticket;
                MyFormTicketClass myFormTicket = JsonConvert.DeserializeObject<MyFormTicketClass>((ticket.UserData).ToString());
                return myFormTicket.userType;
            }
        }

        public const string BASE_URL = "http://appapi.ptudocs.com/api/";
        public const string BASEROOT_URL = "http://appapi.ptudocs.com/";
    }