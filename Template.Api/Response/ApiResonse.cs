using AutoWrapper;

namespace Template.Api.Response; 

public class ApiResonse {
    [AutoWrapperPropertyMap(Prop.Result)] public object Data { get; set; }

    [AutoWrapperPropertyMap(Prop.StatusCode)]
    public int Status { get; set; }

    [AutoWrapperPropertyMap(Prop.Message)] public string StatusText { get; set; }
}