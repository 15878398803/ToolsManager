using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ToolsManager
{
    public class HttpHelper
    {
        //private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

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
        public static HttpWebResponse PostImage(string url, string ImagePath)
        {
            FileStream fs = new FileStream(ImagePath, FileMode.Open);
            var r = PostImage(url, fs);
            fs.Close();
            return r;
        }
        public static HttpWebResponse PostImage(string url, FileStream fs)
        {
            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            StringBuilder sb = new StringBuilder();
            sb.Append("--" + boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"img\";filename=\"img.jpg\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: image/jpeg");
            sb.Append("\r\n");//在二进制数据前必须有且仅有两个回车，多了会算进二进制数据部分，造成数据错误
            sb.Append("\r\n");
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sb.ToString());
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");//结尾要多出来的两个--，而且必须放在原来的boundary前面，否则服务器会返回非法访问

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";

            MemoryStream mStream = new MemoryStream();
            //读入内存区域进行缓存，避免中途读文件所需的时间对整体的影响，保证比较连续地写入Request
            mStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            fs.CopyTo(mStream);
            mStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            //切记，MemoryStream 在写完数据进去后，位置会停留在最后写入的地方，下一次读出来时会从最后开始读，也就会造成什么都读不到。读之前把位置归零
            mStream.Position = 0;
            mStream.Flush();

            //byte[] ttt = new byte[100];
            //mStream.Read(ttt, 0, 100);

            //byte[] fsByte = new byte[checked((uint)Math.Min(4096, (int)fs.Length))];
            //int bytesRead = 0;
            //while ((bytesRead = fs.Read(fsByte, 0, fsByte.Length)) != 0)
            //{
            //    stream.Write(fsByte, 0, bytesRead);
            //}
            request.ContentLength = mStream.Length;//postHeaderBytes.Length + fs.Length + boundaryBytes.Length;

            var stream = request.GetRequestStream();
            mStream.CopyTo(stream);
            mStream.Close();
            //stream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            //fs.CopyTo(stream);
            //stream.Write(boundaryBytes, 0, boundaryBytes.Length);

            stream.Flush();
            stream.Close();
            //fs.Close();
            return request.GetResponse() as HttpWebResponse;
            //var reader = new StreamReader(mStream, Encoding.UTF8);
            //Debug.WriteLine(reader.ReadToEnd());
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
