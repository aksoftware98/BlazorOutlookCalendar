using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorCalendar.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Newtonsoft.Json;

namespace BlazorCalendar.Services
{
    public class MicrosoftCalendarEventsProvider : ICalendarEventsProvider
    {

        // Get Access token 
        private readonly IAccessTokenProvider _accessTokenProvider;
        private readonly HttpClient _httpClient;

        private const string BASE_URL = "https://graph.microsoft.com/v1.0/me/events";

        public MicrosoftCalendarEventsProvider(IAccessTokenProvider accessTokenProvider, HttpClient httpClient)
        {
            _accessTokenProvider = accessTokenProvider;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CalendarEvent>> GetEventsInMonthAsync(int year, int month)
        {
            // 1- Get Token 
            var accessToken = await GetAccessTokenAsync();
            if(accessToken == null)
                return null;

            // 2- Set the access token in the authorization header 
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", accessToken);

            // 3-  Send the request 
            var response = await _httpClient.GetAsync(ConstructGraphUrl(year, month));

            if(!response.IsSuccessStatusCode)
            {
                return null;
            }

            // 4- Read the content 
            var contentAsString = await response.Content.ReadAsStringAsync(); 

            var microsoftEvents = JsonConvert.DeserializeObject<GraphEventsResponse>(contentAsString);

            // Convert the Microsoft Event object into CalendarEvent object
            var events = new List<CalendarEvent>();
            foreach (var item in microsoftEvents.Value)
            {
                events.Add(new CalendarEvent
                {
                    Subject = item.Subject,
                    StartDate = item.Start.ConvertToLocalDateTime(),
                    EndDate = item.End.ConvertToLocalDateTime()
                });
            }

            return events;
        }

        public async Task AddEventAsync(CalendarEvent calendarEvent)
        {
             // 1- Get Token 
            var accessToken = await GetAccessTokenAsync();
            if(accessToken == null)
            {
                Console.WriteLine("Access Token is not available");
                return;
            }

            // 2- Set the access token in the authorization header 
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", accessToken);

            // 3- Initialize the content of the post request 
            string eventAsJson = JsonConvert.SerializeObject(new MicrosoftGraphEvent
            {
                Subject = calendarEvent.Subject,
                Start = new DateTimeTimeZone 
                {
                    DateTime = calendarEvent.StartDate.ToString(),
                    TimeZone = TimeZoneInfo.Local.Id
                },
                End = new DateTimeTimeZone 
                {
                    DateTime = calendarEvent.EndDate.ToString(),
                    TimeZone = TimeZoneInfo.Local.Id,
                }
            });

            var content = new StringContent(eventAsJson);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"); 

            // Send the request
            var response = await _httpClient.PostAsync(BASE_URL, content);

            if(response.IsSuccessStatusCode)
                Console.WriteLine("Event has been added successfully!");
            else
                Console.WriteLine(response.StatusCode);
        }

        private async Task<string> GetAccessTokenAsync()
        {
            var tokenRequest = await _accessTokenProvider.RequestAccessToken(new AccessTokenRequestOptions
            {
                Scopes = new[] { "https://graph.microsoft.com/Calendars.ReadWrite" }
            });

            // Try to fetch the token 
            if(tokenRequest.TryGetToken(out var token))
            {
                if(token != null)
                {
                    return token.Value;
                }
            }

            return null; 
        }

        private string ConstructGraphUrl(int year, int month)
        {
            return $"{BASE_URL}?$filter=start/datetime ge '{year}-{month}-01T00:00' and end/dateTime le '{year}-{month}-31T00:00'&$select=subject,start,end";
        }
    }
}