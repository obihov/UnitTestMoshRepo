using System;
using System.Net;

namespace TestNinja.Mock_UseOnly
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;

        public bool DownloadInstaller(string customerName, string installerName)
        {
            this._setupDestinationFile = String.Empty;
            
            var client = new WebClient();
            try
            {
                var url = $"https://example.com/{customerName}/{installerName}"; //string.Format(@"http://example.com/{0}/{1}", customerName, installerName);
                client.DownloadFile(url, _setupDestinationFile);
                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}