using Xunit;

namespace O9d.Json.Formatting.Tests
{
    public class SnakeCaseStringExtensionsTests
    {
        [Theory]
        [InlineData("url_value", "URLValue")]
        [InlineData("url", "URL")]
        [InlineData("id", "ID")]
        [InlineData("i", "I")]
        [InlineData("", "")]
        [InlineData("person", "Person")]
        [InlineData("i_phone", "iPhone")]
        [InlineData("i_phone", "IPhone")]
        [InlineData("i_phone", "I Phone")]
        [InlineData("i_phone", "I  Phone")]
        [InlineData("i_phone", " IPhone")]
        [InlineData("i_phone", " IPhone ")]
        [InlineData("is_cia", "IsCIA")]
        [InlineData("vm_q", "VmQ")]
        [InlineData("xml2_json", "Xml2Json")]
        [InlineData("sn_ak_ec_as_e", "SnAkEcAsE")]
        [InlineData("sn_a__k_ec_as_e", "SnA__kEcAsE")]
        [InlineData("sn_a__k_ec_as_e", "SnA__ kEcAsE")]
        [InlineData("already_snake_case_", "already_snake_case_ ")]
        [InlineData("is_json_property", "IsJSONProperty")]
        [InlineData("shouting_case", "SHOUTING_CASE")]
        [InlineData("9999-12-31_t23:59:59.9999999_z", "9999-12-31T23:59:59.9999999Z")]
        [InlineData("hi!!_this_is_text._time_to_test.", "Hi!! This is text. Time to test.")]
        public static void Can_convert_to_snake_case(string expected, string input)
        {
            Assert.Equal(input.ToSnakeCase(), expected);
        }
    }
}
