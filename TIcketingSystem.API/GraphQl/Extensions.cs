using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.API.GraphQl.Mutations;
using TicketingSystem.API.GraphQl.Queries;
using TicketingSystem.API.GraphQl.Types;

namespace TicketingSystem.API.GraphQl
{
    public static class Extensions
    {
        //public static Inputs ToInputs(this JToken obj)
        //{
        //    var variables = obj?.GetValue() as Dictionary<string, object>
        //                    ?? new Dictionary<string, object>();
        //    return new Inputs(variables);
        //}

        public static IServiceCollection AddGraph(this IServiceCollection services)
        {
            services.AddScoped<IServiceProvider>(_ => new FuncServiceProvider(_.GetRequiredService));
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            //services.AddScoped<IDocumentWriter, DocumentWriter>();
            services.AddScoped<EventType>();
            services.AddScoped<TicketType>();
            services.AddScoped<UserType>();
            services.AddScoped<EventInput>();
            services.AddScoped<TicketInput>();
            services.AddScoped<UserInput>();
            services.AddScoped<Mutation>();
            services.AddScoped<UserKindEnumType>();
            services.AddScoped<AgeRestrictionEnumType>();
            services.AddScoped<Query>();
            services.AddScoped<ISchema, GraphSchema>();
            services.AddGraphQL(o => { o.EnableMetrics = true; })
                .AddSystemTextJson(d => { }, s => { })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddWebSockets() // Add required services for web socket support
                .AddDataLoader(); // Add required services for DataLoader support;
            return services;
        }
    }

    public static class StringExtensions
    {
        /// <summary>
        /// Converts a JSON-formatted string into a dictionary.
        /// </summary>
        /// <param name="json">A JSON-formatted string.</param>
        /// <returns>Inputs.</returns>
        public static Inputs ToInputs(this string json)
        {
            var dictionary = json?.ToDictionary();
            return dictionary.ToInputs();
        }

        /// <summary>
        /// Converts a JSON object into a dictionary.
        /// </summary>
        /// <remarks>
        /// Used by GraphQL.Transports.AspNetCore.NewtonsoftJson project in server repo.
        /// </remarks>
        public static Inputs ToInputs(this JObject obj)
        {
            var variables = obj?.GetValue() as Dictionary<string, object>;
            return variables.ToInputs();
        }

        /// <summary>
        /// Converts a JSON-formatted string into a dictionary.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Returns a <c>null</c> if the object cannot be converted into a dictionary.</returns>
        public static Dictionary<string, object> ToDictionary(this string json)
        {
            var values = JsonConvert.DeserializeObject(json,
                new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateParseHandling = DateParseHandling.None
                });
            return GetValue(values) as Dictionary<string, object>;
        }

        /// <summary>
        /// Gets the value contained in a JObject, JValue, JProperty or JArray.
        /// </summary>
        /// <param name="value">The object containing the value to extract.</param>
        /// <remarks>If the value is a recognized type, it is returned unaltered.</remarks>
        public static object GetValue(this object value)
        {
            if (value is JObject objectValue)
            {
                var output = new Dictionary<string, object>();
                foreach (var kvp in objectValue)
                {
                    output.Add(kvp.Key, GetValue(kvp.Value));
                }
                return output;
            }

            if (value is JProperty propertyValue)
            {
                return new Dictionary<string, object>
                {
                    { propertyValue.Name, GetValue(propertyValue.Value) }
                };
            }

            if (value is JArray arrayValue)
            {
                return arrayValue.Children().Aggregate(new List<object>(), (list, token) =>
                {
                    list.Add(GetValue(token));
                    return list;
                });
            }

            if (value is JValue rawValue)
            {
                var val = rawValue.Value;
                if (val is long l)
                {
                    if (l >= int.MinValue && l <= int.MaxValue)
                    {
                        return (int)l;
                    }
                }
                return val;
            }

            return value;
        }
    }
}
