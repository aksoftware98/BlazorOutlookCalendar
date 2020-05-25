using System; 

namespace BlazorCalendar.Models
{
    public class GraphEventsResponse
    {
        public MicrosoftGraphEvent[] Value { get; set; }
    }

    public class MicrosoftGraphEvent 
    {
        public string Subject {get; set;}
        public DateTimeTimeZone Start {get; set;}
        public DateTimeTimeZone End {get; set;}
    }

    public class DateTimeTimeZone 
    {
        public string DateTime {get; set;}
        public string TimeZone {get; set;}

        public DateTime ConvertToLocalDateTime()
        {
            var dateTime = System.DateTime.Parse(DateTime);

            TimeZoneInfo timeZone = null; 
            if(TimeZone == "UTC")
                timeZone = TimeZoneInfo.Utc; 
            else
                timeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZone);

            return new DateTimeOffset(dateTime, timeZone.BaseUtcOffset).LocalDateTime;
        }
    }
}