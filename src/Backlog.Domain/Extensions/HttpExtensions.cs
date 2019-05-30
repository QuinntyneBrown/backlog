﻿using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;
using System.Linq;

namespace Backlog.Domain.Extensions
{

    public class HttpResponseBody<T>
    {
        public bool IsValid { get; set; }
        public T Value { get; set; }
        public IEnumerable<ValidationFailure> ValidationResults { get; set; }
    }

    public static class HttpRequestExtensions
    {
        public static async Task<string> ReadAsStringAsync(this HttpRequest request)
        {
            using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8))
                return await reader.ReadToEndAsync();
        }

        public static async Task<HttpResponseBody<T>> GetBodyAsync<T>(this HttpRequest request, IValidator<T> validator)
        {
            var body = new HttpResponseBody<T>();

            var bodyString = await request.ReadAsStringAsync();

            body.Value = JsonConvert.DeserializeObject<T>(bodyString);

            var context = new ValidationContext(body.Value);

            var result = validator.Validate(context);

            if (result.Errors.Any(f => f != null))
                body.IsValid = false;


            var results = new List<ValidationResult>();

            body.ValidationResults = result.Errors;

            return body;
        }
    }


}
