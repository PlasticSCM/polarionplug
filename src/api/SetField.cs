using System;
using System.Linq;
using System.Threading.Tasks;

using PolarionPlug.ProjectApi;
using PolarionPlug.TrackerApi;
using User = PolarionPlug.TrackerApi.User;

namespace PolarionPlug.Api
{
    static class SetField
    {
        internal static bool NeedsUpdateOperation(string fieldKey)
        {
            return fieldKey != "status" && fieldKey != "assignee" && fieldKey != "category";
        }

        internal async static Task Value(
            WorkItem workItem,
            string fieldKey,
            string newValue,
            ProjectWebService projectService,
            TrackerWebService trackerService)
        {
            switch (fieldKey)
            {
                case "assignee":
                    await SetAssignee(workItem, newValue, projectService, trackerService);
                    return;
                case "category":
                    await SetCategory(workItem, newValue, trackerService);
                    return;
                case "dueDate":
                    DateTime dueDate = DateTime.Parse(newValue);
                    workItem.dueDate = dueDate;
                    workItem.dueDateSpecified = true;
                    return;
                case "description":
                    if (workItem.description == null)
                        workItem.description = new TrackerApi.Text();
                    workItem.description.content = newValue;
                    return;
                case "initialEstimate":
                    workItem.initialEstimate = newValue;
                    return;
                case "remainingEstimate":
                    workItem.remainingEstimate = newValue;
                    return;
                case "status":
                    await SetStatus(workItem, newValue, trackerService);
                    return;
                case "timeSpent":
                    workItem.timeSpent = newValue;
                    return;
                case "title":
                    workItem.title = newValue;
                    return;

                case "author":
                case "date":
                case "location":
                case "priority":
                case "project":
                case "uri":
                    throw new Exception(string.Format("The '{0}' field can't be edited.", fieldKey));

                default:
                    Custom customField = Find.Custom(workItem, fieldKey);
                    if (customField != null && customField.value != null)
                        customField.value = newValue;
                    return;
            }
        }

        async static Task SetCategory(
            WorkItem workItem, string newValue, TrackerWebService trackerService)
        {
            Category category = await Find.CategoryInProject(
                workItem.project.id, newValue, trackerService);

            if (category == null || category.unresolvable)
                throw new Exception(string.Format("Category '{0}' not found", newValue));

            await trackerService.addCategoryAsync(
                new addCategoryRequest(workItem.uri, category.id));
        }

        async static Task SetAssignee(
            WorkItem workItem,
            string newValue,
            ProjectWebService projectService,
            TrackerWebService trackerService)
        {
            User assignee = await Find.User(newValue, projectService);
            if (assignee == null || assignee.unresolvable)
                throw new Exception(string.Format("User '{0}' not found", newValue));

            await trackerService.addAssigneeAsync(
                new addAssigneeRequest(workItem.uri, assignee.id));
        }

        async static Task SetStatus(
            WorkItem workItem, string newValue, TrackerWebService trackerService)
        {
            WorkflowAction[] workflowActions = (await trackerService.getAvailableActionsAsync(
                new getAvailableActionsRequest(workItem.uri))).getAvailableActionsReturn;

            if (workflowActions == null)
            {
                throw new Exception(string.Format(
                    "Unable to set status '{0}' from '{1}' in '{2}'",
                    newValue, 
                    workItem.status.id,
                    workItem.id));
            }

            WorkflowAction targetAction = workflowActions.FirstOrDefault(
                action => action.targetStatus.id == newValue);
            if (targetAction == null)
            {
                throw new Exception(string.Format(
                    "No workflow action found to set status '{0}' from '{1}' in '{2}'",
                    newValue,
                    workItem.status.id,
                    workItem.id));
            };

            await trackerService.performWorkflowActionAsync(
                new performWorkflowActionRequest(workItem.uri, targetAction.actionId));
        }
    }
}
