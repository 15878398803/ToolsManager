using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToolsManager
{
    public class HttpHelper
    {
        //private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        /** 下面为 http post 报文格式
     POST/logsys/home/uploadIspeedLog!doDefault.html HTTP/1.1 
　　 Accept: text/plain, 
　　 Accept-Language: zh-cn 
　　 Host: 192.168.24.56
　　 Content-Type:multipart/form-data;boundary=-----------------------------7db372eb000e2
　　 User-Agent: WinHttpClient 
　　 Content-Length: 3693
　　 Connection: Keep-Alive   注：上面为报文头
　　 -------------------------------7db372eb000e2
　　 Content-Disposition: form-data; name="file"; filename="kn.jpg"
　　 Content-Type: image/jpeg
　　 (此处省略jpeg文件二进制数据...）
　　 -------------------------------7db372eb000e2--
         * 
         * */


        public static HttpWebResponse CreateGetHttpResponse(string url)
        {
            return CreateGetHttpResponse(url, null, "", null);
        }
        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        public static HttpWebResponse CreateGetHttpResponse(string url, int? timeout, string userAgent, CookieCollection cookies)
        {
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                //对服务端证书进行有效性校验（非第三方权威机构颁发的证书，如自己生成的，不进行验证，这里返回true）
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;    //http版本，默认是1.1,这里设置为1.0
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "GET";

            //设置代理UserAgent和超时
            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            if (timeout.HasValue)
                request.Timeout = timeout.Value;
            else
                request.Timeout = 30 * 1000;

            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }

            //Thread.Sleep(3000);//测试服务器延时

            //将请求发出，同时等待服务器返回后返回
            return request.GetResponse() as HttpWebResponse;
        }

        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, int timeout, string userAgent, CookieCollection cookies)
        {
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                //request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            //设置代理UserAgent和超时
            //request.UserAgent = userAgent;
            //request.Timeout = timeout; 

            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            //发送POST数据  
            if (!( parameters == null || parameters.Count == 0 ))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        i++;
                    }
                }
                byte[] data = Encoding.ASCII.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            string[] values = request.Headers.GetValues("Content-Type");
            return request.GetResponse() as HttpWebResponse;
        }

        /// <summary>
        /// 以Post 形式提交数据到 uri
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="files"></param>
        /// <param name="values"></param>
        /// <returns></returns>

        public static HttpWebResponse CreatePostHttpResponseFile(string url, Byte[] file)
        {
            string bund = "-------------------------------7db372eb000e2";
            string bundF = "\r\n-------------------------------7db372eb000e2--";

            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            //if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            //{
            //    //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            //    request = WebRequest.Create(url) as HttpWebRequest;
            //    //request.ProtocolVersion = HttpVersion.Version10;
            //}
            //else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            MemoryStream mStream = new MemoryStream();
            //设置代理UserAgent和超时
            //request.UserAgent = userAgent;
            //request.Timeout = timeout; 

            //发送POST数据  

            string fformat = "Content-Disposition: form-data; name=\"img\" Content-Type: image/jpeg\r\n\r\n";

            byte[] data = Encoding.UTF8.GetBytes(fformat);
            byte[] a = Encoding.UTF8.GetBytes(bund);
            byte[] b = Encoding.UTF8.GetBytes(bundF);

            mStream.Write(a, 0, a.Length);
            mStream.Write(data, 0, data.Length);
            mStream.Write(file, 0, file.Length);
            mStream.Write(b, 0, b.Length);
            request.ContentLength = mStream.Length;

            using (Stream stream = request.GetRequestStream())
            {
                mStream.CopyTo(stream);
                //stream.Write(a, 0, a.Length);
                //stream.Write(data, 0, data.Length);
                //stream.Write(file, 0, file.Length);
                //stream.Write(b, 0, b.Length);
                //request.ContentLength = mStream.Length;
            }

            //string[] values = request.Headers.GetValues("Content-Type");
            return request.GetResponse() as HttpWebResponse;
        }
        /// <summary>
        /// 获取请求的数据
        /// </summary>
        public static string GetResponseString(HttpWebResponse webresponse)
        {
            using (Stream s = webresponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// 验证证书
        /// </summary>
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors == SslPolicyErrors.None)
                return true;
            return false;
        }
    }
}
