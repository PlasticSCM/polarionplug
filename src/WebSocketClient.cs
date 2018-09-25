using System;
using System.Threading;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using log4net;
using WebSocketSharp;
using System.Threading.Tasks;

namespace PolarionPlug
{
    class WebSocketClient
    {
        internal WebSocketClient(
            string serverUrl,
            string type,
            string name,
            string apikey,
            Func<string, Task<string>> processMessage)
        {
            mName = name;
            mApiKey = apikey;
            mType = type;

            mWebSocket = new WebSocket(serverUrl);
            mWebSocket.OnMessage += OnMessage;
            mWebSocket.OnClose += OnClose;
            mWebSocket.OnError += OnError;
            mWebSocket.Log.Output = LogOutput;
            mWebSocket.SslConfiguration.ServerCertificateValidationCallback += CertificateValidation;

            mProcessMessage = processMessage;
        }

        internal void ConnectWithRetries()
        {
            mbIsConnecting = true;
            try
            {
                while (true)
                {
                    if (Connect())
                        return;

                    Thread.Sleep(5000);
                }
            }
            finally
            {
                mbIsConnecting = false;
            }
        }

        bool Connect()
        {
            mWebSocket.Connect();
            if (!mWebSocket.IsAlive)
                return false;

            mWebSocket.Send(Messages.BuildLoginMessage(mApiKey));
            mWebSocket.Send(Messages.BuildRegisterPlugMessage(mName, mType));

            mLog.Debug(string.Format("Plug ({0}) connected!", mName));
            return true;
        }

        void OnClose(object sender, CloseEventArgs closeEventArgs)
        {
            mLog.ErrorFormat("OnClose was called! Code [{0}]. Reason [{1}]",
                closeEventArgs.Code, closeEventArgs.Reason);

            if (mbIsConnecting)
                return;

            ConnectWithRetries();
        }

        void OnMessage(object sender, MessageEventArgs e)
        {
            Task.Run(async () => mWebSocket.Send(await mProcessMessage(e.Data)));
        }

        void OnError(object sender, ErrorEventArgs e)
        {
            mLog.ErrorFormat("WebSocket error: {0}", e.Message);
            mLog.ErrorFormat("Exception: {0}", e.Exception.Message);
            mLog.DebugFormat(
                "Stack trace:{0}{1}", Environment.NewLine, e.Exception.StackTrace);
        }

        static void LogOutput(LogData arg1, string arg2)
        {
        }

        static bool CertificateValidation(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        readonly WebSocket mWebSocket;

        readonly ILog mLog = LogManager.GetLogger("websocket");
        readonly string mName;
        readonly string mApiKey;
        readonly string mType;
        readonly Func<string, Task<string>> mProcessMessage;

        volatile bool mbIsConnecting = false;
    }
}
