using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCalendar.Blazor.Models;

namespace BlazorCalendar.Blazor.Services
{
    public interface ICalendarEventsProvider 
    {

        Task<IEnumerable<CalendarEvent>> GetEventsInMonthAsync(int year, int month);

        Task AddEventAsync(CalendarEvent calendarEvent);
    }
}