using System;
using System.Threading.Tasks;
using log4net;

namespace PolarionPlug
{
    internal class WebSocketRequest
    {
        internal class Data
        {
            internal Data(WebSocketClient ws, string message)
            {
                WebSocket = ws;
                Message = message;
            }

            readonly internal WebSocketClient WebSocket;
            readonly internal string Message;
        }
        
        internal static WebSocketRequest Build(Config config)
        {
            PolarionClient client = null;
            try
            {
                client = PolarionClient.Build(config);
            }
            catch(Exception e)
            {
                mLog.ErrorFormat(
                    "Unable to establish a connection to Polarion services: {0}", e.Message);
                mLog.Error("Disabling requests.");
                mLog.DebugFormat("Stack trace:{0}{1}", Environment.NewLine, e.StackTrace);
            }
            return new WebSocketRequest(client);
        }

        internal WebSocketRequest(PolarionClient polarionClient)
        {
            mPolarionClient = polarionClient;
        }

        internal async Task<string> ProcessMessage(string message)
        {
            string requestId = Messages.GetRequestId(message);
            if (mPolarionClient == null)
                return Messages.BuildErrorResponse(requestId, UNINITIALIZED_ERROR);

            string type = string.Empty;
            try
            {
                type = Messages.GetIssueTrackerActionType(message);
                return await ProcessData(requestId, type, message);
            }
            catch (Exception ex)
            {
                mLog.ErrorFormat("Error processing message '{0}': \nMessage:{1}. Error: {2}",
                    type, message, ex.Message);
                mLog.DebugFormat("StackTrace:{0}{1}", Environment.NewLine, ex.StackTrace);
                return Messages.BuildErrorResponse(requestId, ex.Message);
            }
        }

        async Task<string> ProcessData(string requestId, string type, string message)
        {
            switch (type)
            {
                case "getissueurl":
                    return await ProcessGetIssueUrlMessage(
                        requestId, Messages.ReadGetIssueUrlMessage(message));

                case "getfieldvalue":
                    return await ProcessGetIssueFieldValueMessage(
                        requestId, Messages.ReadGetIssueFieldValueMessage(message));

                case "setfieldvalue":
                    return await ProcessSetIssueFieldValueMessage(
                        requestId, Messages.ReadSetIssueFieldValueMessage(message));

                default:
                    string unsupportedActionMessage = string.Format(
                        "The issue tracker plug action '{0}' is not supported.", type);
                    mLog.Info(unsupportedActionMessage);
                    return Messages.BuildErrorResponse(requestId, unsupportedActionMessage);
            }
        }

        async Task<string> ProcessGetIssueUrlMessage(
           string requestId, GetIssueUrlMessage message)
        {
            string response = await mPolarionClient.GetWorkItemUrl(
                message.ProjectKey, message.TaskNumber);

            if (response == null)
            {
                return Messages.BuildErrorResponse(requestId, string.Format(
                    "Workitem {0} not found in project {1}.",
                    message.TaskNumber,
                    message.ProjectKey));
            }

            return Messages.BuildGetIssueUrlResponse(requestId, response);
        }

        async Task<string> ProcessGetIssueFieldValueMessage(
            string requestId, GetIssueFieldValueMessage message)
        {
            PolarionClient.FieldValue fieldValue = await mPolarionClient.GetWorkItemFieldValue(
                message.ProjectKey, message.TaskNumber, message.FieldName);

            if (fieldValue.Result == PolarionClient.FieldOperationResult.WorkitemNotFound)
            {
                return Messages.BuildWorkitemNotFoundResponse(
                    requestId, message.ProjectKey, message.TaskNumber);
            }

            if (fieldValue.Result == PolarionClient.FieldOperationResult.FieldNotFound)
            {
                return Messages.BuildFieldNotFoundResponse(
                    requestId, message.ProjectKey, message.TaskNumber, message.FieldName);
            }

            return Messages.BuildGetIssueFieldValueResponse(requestId, fieldValue.Value);
        }

        async Task<string> ProcessSetIssueFieldValueMessage(
            string requestId, SetIssueFieldValueMessage message)
        {
            PolarionClient.FieldOperationResult result = await mPolarionClient.TryUpdateFieldAsync(
                message.ProjectKey, message.TaskNumber, message.FieldName, message.NewValue);

            if (result == PolarionClient.FieldOperationResult.WorkitemNotFound)
            {
                return Messages.BuildWorkitemNotFoundResponse(
                    requestId, message.ProjectKey, message.TaskNumber);
            }

            if (result == PolarionClient.FieldOperationResult.FieldNotFound)
            {
                return Messages.BuildFieldNotFoundResponse(
                    requestId, message.ProjectKey, message.TaskNumber, message.FieldName);
            }

            return Messages.BuildSuccessResponse(requestId);
        }

        static string BuildAccessToken(Config config)
        {
            return Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(
                    string.Format("{0}:{1}", config.User, config.Password)));
        }

        PolarionClient mPolarionClient;

        static readonly ILog mLog = LogManager.GetLogger("polarionplug");

        const string UNINITIALIZED_ERROR = "Requests are disabled due to a faulty " +
            "Polarion client initialization. Please check the current plug configuration " +
            "and restart the plug.";
    }
}
