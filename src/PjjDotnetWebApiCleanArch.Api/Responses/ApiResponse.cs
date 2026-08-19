using System.Text.Json.Serialization;

namespace PjjDotnetWebApiCleanArch.Api.Responses;

public record ApiResponse<T>(int StatusCode,
    string Message,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    T? Data);