using System;
using System.Text.Json;
using Xunit;

namespace O9d.Json.Formatting.Tests
{
    public class JsonSnakeCaseNamingPolicyTests
    {
        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy()
        };

        [Fact]
        public void Can_serialize()
        {
            var person = new Person("Name!", new DateTime(2000, 11, 20, 23, 55, 44, DateTimeKind.Utc), new[] { "food", "sport" });
            
            string json = JsonSerializer.Serialize(person, SerializerOptions);

            Assert.Equal(@"{""name"":""Name!"",""birth_date"":""2000-11-20T23:55:44Z"",""likes"":[""food"",""sport""]}", json);
        }

        [Fact]
        public void Can_deserialize()
        {
            string json = @"{
                ""name"": ""Name!"",
                ""birth_date"": ""2000-11-20T23:55:44Z"",
                ""likes"": [""food"", ""sport""]
            }";

            Person? person = JsonSerializer.Deserialize<Person>(json, SerializerOptions);
            Assert.NotNull(person);
            Assert.Equal("Name!", person!.Name);
            Assert.Equal(DateTime.Parse("2000-11-20T23:55:44Z"), person.BirthDate);
            Assert.Equal(new[] { "food", "sport" }, person.Likes);
        }

    }

    internal record Person(string? Name, DateTime? BirthDate, string[]? Likes);
}
