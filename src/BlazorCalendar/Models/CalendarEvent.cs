using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorCalendar.Models
{

    public class CalendarEvent 
    {

        public CalendarEvent()
        {
            Color = Helpers.RandomColorHelper.GetRandomColorClass();
        }

        public string Subject {get; set;}

        public DateTime StartDate {get; set;}

        public DateTime EndDate {get; set;}

        public string Color {get; private set;}
    }
}