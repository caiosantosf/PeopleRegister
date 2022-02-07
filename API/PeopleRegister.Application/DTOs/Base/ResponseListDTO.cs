namespace PeopleRegister.Application.DTOs;

public class ResponseListDTO<TDTO> : BaseGetDTO
{
    public IEnumerable<TDTO> Data { get; set; }
}
