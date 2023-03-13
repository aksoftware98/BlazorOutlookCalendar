using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using BlazorCalendar.Blazor;
using BlazorCalendar.Blazor.Models;

namespace BlazorCalendar.Blazor.Pages
{
    public partial class Index
    {
		private CalendarDay selectedDay = new CalendarDay
		{
			Date = DateTime.Now
		};
		
	}
}