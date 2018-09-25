using System.Linq;

using PolarionPlug.TrackerApi;

namespace PolarionPlug.Api
{
    static class GetField
    {
        internal static string Value(WorkItem workItem, string fieldKey)
        {
            switch (fieldKey)
            {
                case "assignee":
                    if (workItem.assignee == null)
                        return string.Empty;
                    return string.Join(
                        LIST_SEPARATOR, workItem.assignee.Select(user => user.id));
                case "author":
                    return workItem.author.id;
                case "category":
                    if (workItem.categories == null)
                        return string.Empty;
                    return string.Join(
                        LIST_SEPARATOR, workItem.categories.Select(category => category.id));
                case "date":
                    return workItem.createdSpecified ? workItem.created.ToString("o") : string.Empty;
                case "dueDate":
                    return workItem.dueDateSpecified ? workItem.dueDate.ToString("o") : string.Empty;
                case "description":
                    return workItem.description.content;
                case "initialEstimate":
                    return workItem.initialEstimate;
                case "location":
                    return workItem.location;
                case "priority":
                    return workItem.priority != null ? workItem.priority.id : string.Empty;
                case "project":
                    return workItem.project.id;
                case "remainingEstimate":
                    return workItem.remainingEstimate;
                case "status":
                    return workItem.status.id;
                case "timeSpent":
                    return workItem.timeSpent;
                case "title":
                    return workItem.title;
                case "uri":
                    return workItem.uri;

                default:
                    Custom customField = Find.Custom(workItem, fieldKey);
                    if (customField == null || customField.value == null)
                        return null;
                    return customField.value.ToString();
            }
        }

        const string LIST_SEPARATOR = ", ";
    }
}
