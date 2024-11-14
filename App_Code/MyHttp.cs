using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
public class MyHttp
{

    public static T FetchSingleAPIData<T>(string url, bool isAuthorization = true)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
        request.ContentType = "application/json";
        request.Method = "GET";

        if (isAuthorization)
        {
            request.PreAuthenticate = true;
            string username = "midland_gurpreet_singh1";
            string password = "Admin!1234!";

            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

            request.Headers.Add("Authorization", "Basic " + svcCredentials);
            request.Headers.Add("x-karza-key", "ltck8CVWRHnwouf3d4vy");
            //  request.Headers.Add("Authorization", "bearer " + CurrentUser.JsonToken);
        }


        using (WebResponse response = request.GetResponse())
        {
            //using (Stream stream = response.GetResponseStream())
            //{
            //    JsonValue jsonDoc = JsonObject.Load(stream);
            //    return JsonConvert.DeserializeObject<T>(jsonDoc.ToString());
            //}

            string jsonDoc = "";
            using (Stream outputStream = response.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(outputStream, System.Text.Encoding.ASCII))
                {
                    jsonDoc = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(jsonDoc.ToString());
                }
            }

        }
    }
    
    public static T PostAPIData<T>(string url, string postData, bool isAuthorization, bool IsJson = false)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));

        if (IsJson)
        {
            request.ContentType = "application/json";
        }
        else
        {
            request.ContentType = "application/x-www-form-urlencoded";
        }


        request.Method = "POST";
        // request.Timeout = 1000000;

        if (isAuthorization)
        {
            //request.PreAuthenticate = true;
            //request.Headers.Add("Authorization", "bearer " + DocsSFCApiTokens.SFCAdminToken);
            request.PreAuthenticate = true;
            string username = "midland_gurpreet_singh1";
            string password = "Admin!1234!";

            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

            request.Headers.Add("Authorization", "Basic " + svcCredentials);
            request.Headers.Add("x-karza-key", "ME1J65izme75v5lrnxki");
        }


        byte[] postArray = Encoding.ASCII.GetBytes(postData);
        request.ContentLength = postArray.Length;

        using (var stream = request.GetRequestStream())
        {
            stream.Write(postArray, 0, postArray.Length);
        }

        using (WebResponse response = request.GetResponse())
        {
            //using (Stream stream = response.GetResponseStream())
            //{
            //    JsonValue jsonDoc = JsonObject.Load(stream);
            //    return JsonConvert.DeserializeObject<T>(jsonDoc.ToString());
            //}

            string jsonDoc = "";
            using (Stream outputStream = response.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(outputStream, System.Text.Encoding.ASCII))
                {
                    jsonDoc = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(jsonDoc.ToString());
                }
            }
        }
    }


    //protected void abc()
    //{
    //    var client = new RestClient(https://xnrp4.api.infobip.com/sms/2/text/advanced);

    //    client.Timeout = -1;

    //    var request = new RestRequest(Method.POST);

    //    request.AddHeader("Authorization", "{authorization}");

    //    request.AddHeader("Content-Type", "application/json");

    //    request.AddHeader("Accept", "application/json");

    //    request.AddParameter("application/json", "{\"messages\":[{\"from\":\"InfoSMS\",\"destinations\":[{\"to\":\"41793026727\",\"messageId\":\"MESSAGE-ID-123-xyz\"},{\"to\":\"41793026834\"}],\"text\":\"Artık Ulusal Dil Tanımlayıcısı ile Türkçe karakterli smslerinizi rahatlıkla iletebilirsiniz.\",\"flash\":false,\"language\":{\"languageCode\":\"TR\"},\"transliteration\":\"TURKISH\",\"intermediateReport\":true,\"notifyUrl\":\https://www.example.com/sms/advanced\,\"notifyContentType\":\"application/json\",\"callbackData\":\"DLR callback data\",\"validityPeriod\":720},{\"from\":\"41793026700\",\"destinations\":[{\"to\":\"41793026700\"}],\"text\":\"A long time ago, in a galaxy far, far away... It is a period of civil war. Rebel spaceships, striking from a hidden base, have won their first victory against the evil Galactic Empire.\",\"sendAt\":\"2021-08-25T16:00:00.000+0000\",\"deliveryTimeWindow\":{\"from\":{\"hour\":6,\"minute\":0},\"to\":{\"hour\":15,\"minute\":30},\"days\":[\"MONDAY\",\"TUESDAY\",\"WEDNESDAY\",\"THURSDAY\",\"FRIDAY\",\"SATURDAY\",\"SUNDAY\"]}}],\"bulkId\":\"BULK-ID-123-xyz\",\"tracking\":{\"track\":\"SMS\",\"type\":\"MY_CAMPAIGN\"}}", ParameterType.RequestBody);

    //    IRestResponse response = client.Execute(request);

    //    Console.WriteLine(response.Content);
    //}
}