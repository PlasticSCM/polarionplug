using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading.Tasks;

using log4net;

using PolarionPlug.SessionApi;
using PolarionPlug.ProjectApi;
using PolarionPlug.TrackerApi;
using PolarionPlug.Api;

namespace PolarionPlug
{
    class PolarionClient
    {
        internal class FieldValue
        {
            internal FieldOperationResult Result;
            internal string Value;
        }

        internal enum FieldOperationResult
        {
            Success,
            WorkitemNotFound,
            FieldNotFound
        }

        internal static PolarionClient Build(Config config)
        {
            PolarionClient client = new PolarionClient(config);
            Uri servicesUri = new Uri(GetBaseUri(config.Url), "ws/services");

            IEndpointBehavior behavior = new SessionBehavior();
            client.mProjectService = BuildProjectServiceClient(servicesUri, behavior);
            client.mSessionService = BuildSessionServiceClient(servicesUri, behavior);
            client.mTrackerService = BuildTrackerServiceClient(servicesUri, behavior);

            return client;
        }

        PolarionClient(Config config)
        {
            mConfig = config;
        }

        internal async Task<string> GetWorkItemUrl(string projectId, string workitemId)
        {
            await EnsureIsLoggedIn();
            WorkItem workItem = await GetWorkItem(projectId, workitemId);

            if (workItem == null || workItem.unresolvable)
                return null;

            string urlPath = string.Format("#/project/{0}/workitem?id={1}", projectId, workitemId);
            return new Uri(GetBaseUri(mConfig.Url), urlPath).AbsoluteUri;
        }

        internal async Task<FieldValue> GetWorkItemFieldValue(
            string projectId, string workitemId, string fieldName)
        {
            await EnsureIsLoggedIn();
            WorkItem workItem = await GetWorkItem(projectId, workitemId);

            if (workItem == null || workItem.unresolvable)
                return new FieldValue { Result = FieldOperationResult.WorkitemNotFound };

            string value = GetField.Value(workItem, fieldName);
            if (value == null)
                return new FieldValue { Result = FieldOperationResult.FieldNotFound };

            return new FieldValue
            {
                Result = FieldOperationResult.Success,
                Value = value
            };
        }

        internal async Task<FieldOperationResult> TryUpdateFieldAsync(
            string projectId, string workitemId, string fieldKey, string newValue)
        {
            await EnsureIsLoggedIn();

            WorkItem workItem = await GetWorkItem(projectId, workitemId);

            if (workItem == null || workItem.unresolvable)
                return FieldOperationResult.WorkitemNotFound;

            if (!Find.ExistingField(workItem, fieldKey))
                return FieldOperationResult.FieldNotFound;

            await SetField.Value(
                workItem, fieldKey, newValue, mProjectService, mTrackerService);

            if (SetField.NeedsUpdateOperation(fieldKey))
            {
                await mTrackerService.updateWorkItemAsync(
                    new updateWorkItemRequest(workItem));
            }
            return FieldOperationResult.Success;
        }

        async Task EnsureIsLoggedIn()
        {
            hasSubjectResponse hasSubjectResponse = await mSessionService.hasSubjectAsync(
                new hasSubjectRequest());

            if (hasSubjectResponse.hasSubjectReturn)
                return;

            await mSessionService.logInAsync(new logInRequest(mConfig.User, mConfig.Password));
        }

        async Task<WorkItem> GetWorkItem(string projectId, string workitemId)
        {
            getProjectResponse projectResponse = await mProjectService.getProjectAsync(
                new getProjectRequest(projectId));

            if (projectResponse.getProjectReturn.unresolvable)
                return null;

            string projectPrefix = projectResponse.getProjectReturn.trackerPrefix + "-";
            if (!workitemId.StartsWith(projectPrefix))
                workitemId = projectPrefix + workitemId;

            getWorkItemByIdResponse getWorkItemByIdResponse = await mTrackerService.getWorkItemByIdAsync(
                new getWorkItemByIdRequest(projectId, workitemId));
            return getWorkItemByIdResponse.getWorkItemByIdReturn;
        }

        static Uri GetBaseUri(string uriString)
        {
            const string SLASH = "/";
            if (!uriString.EndsWith(SLASH))
                uriString = uriString + SLASH;
            return new Uri(uriString);
        }

        static ProjectWebService BuildProjectServiceClient(
            Uri servicesUri, IEndpointBehavior behavior)
        {
            ProjectWebServiceClient result = new ProjectWebServiceClient(
                new BasicHttpBinding(),
                new EndpointAddress(servicesUri.AbsoluteUri));
            result.Endpoint.EndpointBehaviors.Add(behavior);
            return result;
        }

        static SessionWebService BuildSessionServiceClient(
            Uri servicesUri, IEndpointBehavior behavior)
        {
            SessionWebServiceClient result = new SessionWebServiceClient(
                new BasicHttpBinding(),
                new EndpointAddress(servicesUri.AbsoluteUri));
            result.Endpoint.EndpointBehaviors.Add(behavior);
            return result;
        }

        static TrackerWebService BuildTrackerServiceClient(
            Uri servicesUri, IEndpointBehavior behavior)
        {
            TrackerWebServiceClient result = new TrackerWebServiceClient(
                new BasicHttpBinding(),
                new EndpointAddress(servicesUri.AbsoluteUri));
            result.Endpoint.EndpointBehaviors.Add(behavior);
            return result;
        }

        Config mConfig;
        SessionWebService mSessionService;
        ProjectWebService mProjectService;
        TrackerWebService mTrackerService;

        static readonly ILog mLog = LogManager.GetLogger("PolarionClient");
    }
}