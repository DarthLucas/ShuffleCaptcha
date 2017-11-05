using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ShuffleCaptcha
{
    class Recaptcha
    {
        public string APIToken { private get; set; }
        public string WebsiteUrl { protected get; set; }
        public string WebsiteKey { protected get; set; }

        public Recaptcha(string _APIToken, string _WebsiteUrl, string _WebsiteKey)
        {
            APIToken = _APIToken;
            WebsiteUrl = _WebsiteUrl;
            WebsiteKey = _WebsiteKey;
        }

        public decimal GetBalance()
        {
            List<KeyValuePair<string, string>> content = new List<KeyValuePair<string, string>>();
            content.Add(new KeyValuePair<string, string>("token", APIToken));
            using (HttpClient client = new HttpClient())
            {
                return decimal.Parse(client.PostAsync("http://captcha.shuffletanker.com/api/Captcha/APIGetBalance", new FormUrlEncodedContent(content)).Result.Content.ReadAsStringAsync().Result);
            }

        }


        public CaptchaReturn GetResponse()
        {
            List<KeyValuePair<string, string>> content = new List<KeyValuePair<string, string>>();
            content.Add(new KeyValuePair<string, string>("API", APIToken));
            content.Add(new KeyValuePair<string, string>("WebsiteUrl", WebsiteKey));
            content.Add(new KeyValuePair<string, string>("WebsiteKey", WebsiteKey));
            using (HttpClient client = new HttpClient())
            {
                CaptchaReturn response = null;
                try
                {
                    response = JsonConvert.DeserializeObject<CaptchaReturn>(client.PostAsync("http://captcha.shuffletanker.com/api/Captcha/GetResponse", new FormUrlEncodedContent(content)).Result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception e)
                {
                    throw e;
                }
                if (!response.status)
                {
                    throw new Exception(response.captcha_response);
                }
                else
                {
                    return response;
                }
            }
        }


    }
}
