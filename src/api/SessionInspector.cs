using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace PolarionPlug.Api
{
    class SessionInspector : IClientMessageInspector
    {
        void IClientMessageInspector.AfterReceiveReply(ref Message reply, object correlationState)
        {
            mSessionId = GetSessionIdFromHeaders(reply) ?? mSessionId;
        }

        object IClientMessageInspector.BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            if (mSessionId != null)
                request.Headers.Add(new SessionHeader(mSessionId));

            return null;
        }

        static string GetSessionIdFromHeaders(Message reply)
        {
            int headerIndex = reply.Headers.FindHeader(SESSION_NAME, SESSION_NS);
            if (headerIndex == -1)
                return null;

            return reply.Headers.GetReaderAtHeader(headerIndex).ReadElementContentAsString();
        }

        class SessionHeader : MessageHeader
        {
            public override string Name { get { return SESSION_NAME; } }
            public override string Namespace { get { return SESSION_NS; } }

            internal SessionHeader(string sessionId)
            {
                mSessionId = sessionId;
            }

            protected override void OnWriteHeaderContents(
                XmlDictionaryWriter writer, MessageVersion messageVersion)
            {
                writer.WriteValue(mSessionId);
            }

            string mSessionId;
        }

        string mSessionId;

        const string SESSION_NS = "http://ws.polarion.com/session";
        const string SESSION_NAME = "sessionID";
    }
}
