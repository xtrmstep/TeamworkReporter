using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using TeamworkReporter.TwClient.Logging;

namespace TeamworkReporter.TwClient.Api
{
    public partial class TwClient
    {
        private const string TW_URL = ".teamwork.com";
        private const double RATE_LIMIT = 120; // per minute
        private DateTime _lastRequestTime = DateTime.MinValue;
        private bool _requestWasDelayed;
        private double _requestsPerMinute;

        public string SiteName { get; set; }
        public string ApiToken { get; set; }

        public double RequestsPerMinute
        {
            get { return _requestsPerMinute; }
        }

        public bool RequestWasDelayed
        {
            get { return _requestWasDelayed; }
        }

        /// <summary>
        /// Determines whether API has all required settings to interact properly with TeamworkPM
        /// </summary>
        public bool IsInitialized
        {
            get { return !(string.IsNullOrWhiteSpace(SiteName) || string.IsNullOrWhiteSpace(ApiToken)); }
        }

        private TResult Request<TResult>(string requestQuery) where TResult : class
        {
            MaintainRequestRate();

            try
            {
                using (var wc = new WebClient())
                {
                    var uri = CreateRequestUri(requestQuery);

                    #region add authorization HTTP header

                    var credentialsWithToken = string.Format("{0}:{1}", ApiToken, Guid.NewGuid()); // password is not used
                    var credentialsEncripted = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentialsWithToken));
                    var authorizationToken = string.Format("{0} {1}", "Basic", credentialsEncripted);
                    wc.Headers.Add(HttpRequestHeader.Authorization, authorizationToken);

                    #endregion

                    var res = wc.OpenRead(uri);
                    if (res != null)
                    {
                        var ser = new DataContractJsonSerializer(typeof (TResult));
                        var readObject = ser.ReadObject(res);
                        var response = readObject as TResult;
                        return response;
                    }
                }
            }
            catch (Exception err)
            {
                Logger.For<TwClient>().Error(err);
            }
            return null;
        }

        /// <summary>
        ///     Create a full URI for REST call using stable part and variable
        /// </summary>
        /// <param name="requestQuery">Variable part of the URI</param>
        /// <returns></returns>
        private Uri CreateRequestUri(string requestQuery)
        {
            var sb = new StringBuilder("https://" + SiteName + TW_URL + requestQuery);
            return new Uri(sb.ToString());
        }

        /// <summary>
        ///     Check rate limit and wait if necessary
        /// </summary>
        private void MaintainRequestRate()
        {
            // reset last request time if it has not been initialized
            if (_lastRequestTime == DateTime.MinValue)
                _lastRequestTime = DateTime.Now;

            var now = DateTime.Now;
            var seconds = now.Subtract(_lastRequestTime).Seconds;
            if (seconds <= 60)
            {
                _requestsPerMinute++;
                if (_requestsPerMinute > RATE_LIMIT)
                {
                    // wait necessary delay to maintain the rate limit
                    // + 1 second to start counting over
                    Thread.Sleep((60 - seconds + 1)*1000);
                    // tells API that the last request was delayed
                    _requestWasDelayed = true;
                    // reset rate counter
                    _requestsPerMinute = 1;
                }
            }
            else
                // reset rate counter
                _requestsPerMinute = 1;

            _lastRequestTime = now;
        }
    }
}