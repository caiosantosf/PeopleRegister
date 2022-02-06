namespace PeopleRegister.Application.DTOs;

public class ResponseListDTO : BaseGetDTO
{
    public IEnumerable<object> Data { get; set; }
}
