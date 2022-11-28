using System.Text.Json;
using LeadManagement.Domain.Core.Events;

namespace LeadManagement.Application.EventSourcedNormalizers.Lead
{
    public static class LeadHistory
    {
        private static IList<LeadHistoryData>? HistoryData { get; set; }

        public static IList<LeadHistoryData> ToJavaScriptLeadHistory(IEnumerable<StoredEvent> storedEvents)
        {
            HistoryData = new List<LeadHistoryData>();
            LeadHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<LeadHistoryData>();
            var last = new LeadHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new LeadHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    ContactFirstName = string.IsNullOrWhiteSpace(change.ContactFirstName) || change.ContactFirstName == last.ContactFirstName
                        ? ""
                        : change.ContactFirstName,
                    ContactFullName = string.IsNullOrWhiteSpace(change.ContactFullName) || change.ContactFullName == last.ContactFullName
                        ? ""
                        : change.ContactFullName,
                    ContactPhoneNumber = string.IsNullOrWhiteSpace(change.ContactPhoneNumber) || change.ContactPhoneNumber == last.ContactPhoneNumber
                        ? ""
                        : change.ContactPhoneNumber,
                    ContactEmail = string.IsNullOrWhiteSpace(change.ContactEmail) || change.ContactEmail == last.ContactEmail
                        ? ""
                        : change.ContactEmail,
                    Suburb = string.IsNullOrWhiteSpace(change.Suburb) || change.Suburb == last.Suburb
                        ? ""
                        : change.Suburb,
                    Category = string.IsNullOrWhiteSpace(change.Category) || change.Category == last.Category
                        ? ""
                        : change.Category,
                    JobId = change.JobId.HasValue is false || change.JobId == last.JobId
                        ? null
                        : change.JobId,
                    Description = string.IsNullOrWhiteSpace(change.Description) || change.Description == last.Description
                        ? ""
                        : change.Description,
                    Price = change.Price.HasValue is false || change.Price == last.Price
                        ? null
                        : change.Price,
                    Status = change.Status.HasValue is false || change.Status == last.Status
                        ? null
                        : change.Status,
                    Action = string.IsNullOrWhiteSpace(change.Action)
                        ? ""
                        : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }

            return list;
        }

        private static void LeadHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonSerializer.Deserialize<LeadHistoryData>(e.Data);
                historyData!.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "LeadRegisteredEvent":
                        historyData.Action = "Registered";
                        historyData.Who = "Unrecognized";
                        break;

                    case "LeadRemovedEvent":
                        historyData.Action = "Removed";
                        historyData.Who = "Unrecognized";
                        break;

                    default:
                        historyData.Action = "Unrecognized";
                        historyData.Who = "Unrecognized";
                        break;
                }

                HistoryData!.Add(historyData);
            }
        }
    }
}