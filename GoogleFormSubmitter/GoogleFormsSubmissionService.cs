using System;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleFormSubmitter
{
    public class GoogleFormsSubmissionService
    {
        private readonly string baseUrl;
        private readonly Dictionary<string, string> fields;
        private readonly Dictionary<string, string[]> checkboxes;
        private readonly HttpClient client;

        public GoogleFormsSubmissionService(string formUrl)
        {
            if (string.IsNullOrEmpty(formUrl))
                throw new ArgumentNullException(nameof(formUrl));

            baseUrl = formUrl;
            fields = new Dictionary<string, string>();
            checkboxes = new Dictionary<string, string[]>();
            client = new HttpClient();
        }

        /// <summary>
        /// Set multiple fields with individual values. Fields with empty values will be ignored.
        /// </summary>
        public void SetFieldValues(Dictionary<string, string> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            if (data.Keys.Any(value => string.IsNullOrWhiteSpace(value)))
                throw new ArgumentNullException(nameof(data), "Empty keys are invalid.");

            var fieldsWithData = data.Where(kvp => !string.IsNullOrWhiteSpace(kvp.Value));
            foreach (var kvp in fieldsWithData)
                fields[kvp.Key] = kvp.Value;
        }

        /// <summary>
        /// Set one or more values for a single checkbox field.  Values must match the text on the form Checkboxes.
        /// Empty values will be ignored.
        /// </summary>
        public void SetCheckboxValues(string key, params string[] values)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            var valuesWithData = values.Where(value => !string.IsNullOrWhiteSpace(value)).ToArray();
            checkboxes[key] = valuesWithData;
        }

        /// <summary>
        /// Submits the previously set data asynchronously and returns the response.
        /// </summary>
        public async Task<HttpResponseMessage> SubmitAsync()
        {
            if (!fields.Any() && !checkboxes.Any())
                throw new InvalidOperationException("No data has been set to submit.");

            var content = new FormUrlEncodedContent(fields);
            var url = baseUrl;
            if (checkboxes.Any())
            {
                var queryParams = string.Join("&", checkboxes.Keys.SelectMany(key => checkboxes[key].Select(value => $"{key}={value.Replace(' ', '+')}")));
                url += $"?{queryParams}";
            }

            var response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Google form data was submitted sucessfully.");
            }
            else
            {
                var fieldText = string.Join(Environment.NewLine, fields.Keys.Select(key => $"{key}={string.Join(",", fields[key])}"));
                Console.WriteLine($"Failed to submit Google form.\n{response.StatusCode}: {response.ReasonPhrase}\n{url}\n{fieldText}");
            }

            return response;
        }
    }
}
