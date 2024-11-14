public class JsonResponse
{
    public bool success { get; set; }

    public dynamic data { get; set; }

    public string message { get; set; }

    public string request_id { get; set; }
}
