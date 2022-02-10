namespace PeopleRegister.Application.DTOs;

public class ResponseListDTO<TDTO>
{
    public IEnumerable<TDTO> Data { get; set; }
    public int Page { get; set; }
    public int PageItems { get; set; }
    public int TotalItems { get; set; }
}
