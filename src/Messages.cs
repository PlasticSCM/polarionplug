using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PolarionPlug
{
    public class GetIssueUrlMessage
    {
        public string ProjectKey;
        public string TaskNumber;
    }

    public class GetIssueFieldValueMessage
    {
        public string ProjectKey;
        public string TaskNumber;
        public string FieldName;
    }

    public class SetIssueFieldValueMessage
    {
        public string ProjectKey;
        public string TaskNumber;
        public string FieldName;
        public string NewValue;
    }

    static class Messages
    {
        internal static GetIssueUrlMessage ReadGetIssueUrlMessage(string message)
        {
            return JsonConvert.DeserializeObject<GetIssueUrlMessage>(message);
        }

        internal static GetIssueFieldValueMessage ReadGetIssueFieldValueMessage(string message)
        {
            return JsonConvert.DeserializeObject<GetIssueFieldValueMessage>(message);
        }

        internal static SetIssueFieldValueMessage ReadSetIssueFieldValueMessage(string message)
        {
            return JsonConvert.DeserializeObject<SetIssueFieldValueMessage>(message);
        }

        internal static string BuildRegisterPlugMessage(string name, string type)
        {
            JObject obj = new JObject(
                new JProperty("action", "register"),
                new JProperty("type", type),
                new JProperty("name", name));

            return obj.ToString();
        }

        internal static string BuildLoginMessage(string token)
        {
            JObject obj = new JObject(
                new JProperty("action", "login"),
                new JProperty("key", token));

            return obj.ToString();
        }

        internal static string BuildErrorResponse(string requestId, string message)
        {
            return new JObject(
                new JProperty("requestId", requestId),
                new JProperty("error", message)).ToString();
        }

        internal static string BuildWorkitemNotFoundResponse(
            string requestId, string projectId, string workitemId)
        {
            return BuildErrorResponse(requestId, string.Format(
                "Workitem {0} not found in project {1}.", workitemId, projectId));
        }

        internal static string BuildFieldNotFoundResponse(
            string requestId, string projectId, string workitemId, string fieldName)
        {
            return BuildErrorResponse(requestId, string.Format(
                "Field '{0}' not found in workitem {1}, project {2}.",
                fieldName,
                workitemId,
                projectId));
        }

        internal static string BuildSuccessResponse(string requestId)
        {
            return new JObject(new JProperty("requestId", requestId)).ToString();
        }

        internal static string BuildGetIssueUrlResponse(string requestId, string value)
        {
            return new JObject(
                new JProperty("requestId", requestId),
                new JProperty("value", value)).ToString();
        }

        internal static string BuildGetIssueFieldValueResponse(string requestId, string value)
        {
            return new JObject(
                new JProperty("requestId", requestId),
                new JProperty("value", value)).ToString();
        }

        internal static string GetIssueTrackerActionType(string message)
        {
            return ReadProperty(message, "action").ToLower();
        }

        internal static string GetRequestId(string message)
        {
            return ReadProperty(message, "requestId");
        }

        static string ReadProperty(string message, string name)
        {
            return JObject.Parse(message).Value<string>(name);
        }
    }
}