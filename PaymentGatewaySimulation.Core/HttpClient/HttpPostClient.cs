using Newtonsoft.Json.Linq;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGatewaySimulation.Core
{
    public class HttpPostClient : IHttpPostClient
    {
        /// <summary>
        /// Post for a REST api
        /// </summary>
        /// <param name="headers">headers</param>
        /// <param name="url">REST url for the resource</param>
        /// <param name="content">content</param>
        /// <returns>response from the rest url</returns>
        public async Task<JObject> PostAsync(Hashtable headers, string url, string content)
        {
            byte[] data = Encoding.UTF8.GetBytes(content);
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            foreach (DictionaryEntry item in headers)
            {
                request.Headers.Add(item.Key.ToString(), item.Value.ToString());
            }
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseContent = reader.ReadToEnd();
                JObject adResponse =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(responseContent);
                return adResponse;
            }
        }
    }
}