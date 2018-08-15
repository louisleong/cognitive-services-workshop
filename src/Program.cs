using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Post();
            Console.WriteLine("End");
        }

        static void Post()
        {
            var key = "<insert key here>";
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["returnFaceId"] = "true";
            queryString["returnFaceLandmarks"] = "false";
            queryString["returnFaceAttributes"] = "age,gender";

                        var filebytes = File.ReadAllBytes(@"<local file path directory>");

            var uri = "https://southeastasia.api.cognitive.microsoft.com/face/v1.0/detect?" + queryString;

            HttpResponseMessage response;


            using (var content = new ByteArrayContent(filebytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = client.PostAsync(uri, content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
            }


        }
    }
}
