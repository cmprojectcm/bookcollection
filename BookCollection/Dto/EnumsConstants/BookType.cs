using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BookCollection.Dto.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BookType
    {
        [EnumMember(Value = "Mystery")]
        Mystery =1,
        [EnumMember(Value = "Fantasy")]
        Fantasy =2,
        [EnumMember(Value = "Horror")]
        Horror =3
    }
}
