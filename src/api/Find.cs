using System.Linq;
using System.Threading.Tasks;

using PolarionPlug.ProjectApi;
using PolarionPlug.TrackerApi;
using User = PolarionPlug.TrackerApi.User;

namespace PolarionPlug.Api
{
    static class Find
    {
        internal static bool ExistingField(WorkItem workItem, string fieldKey)
        {
            switch (fieldKey)
            {
                case "assignee":
                case "author":
                case "category":
                case "date":
                case "dueDate":
                case "description":
                case "initialEstimate":
                case "location":
                case "priority":
                case "project":
                case "remainingEstimate":
                case "status":
                case "timeSpent":
                case "title":
                case "uri":
                    return true;

                default:
                    return Custom(workItem, fieldKey) != null;
            }
        }

        internal async static Task<User> User(string userId, ProjectWebService projectService)
        {
            ProjectApi.User user = (await projectService.getUserAsync(
                new getUserRequest(userId))).getUserReturn;
            if (user == null)
                return null;

            return new User
            {
                id = user.id,
                name = user.name,
                email = user.email,
                uri = user.uri,
                unresolvable = user.unresolvable,
                unresolvableSpecified = user.unresolvableSpecified
            };
        }

        internal async static Task<Category> CategoryInProject(
            string projectId, string categoryId, TrackerWebService trackerService)
        {
            getCategoriesResponse response = await trackerService.getCategoriesAsync(
                new getCategoriesRequest(projectId));
            if (response == null || response.getCategoriesReturn == null)
                return null;
            return response.getCategoriesReturn.FirstOrDefault(category => category.id == categoryId);
        }

        internal static Custom Custom(WorkItem workItem, string fieldKey)
        {
            if (workItem.customFields == null)
                return null;

            foreach (Custom customField in workItem.customFields)
            {
                if (customField.key == fieldKey)
                    return customField;
            }
            return null;
        }
    }
}
