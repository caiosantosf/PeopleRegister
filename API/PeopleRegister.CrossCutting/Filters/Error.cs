using System.Net;

namespace PeopleRegister.CrossCutting.Filters;

public class Error
{
    public IEnumerable<string> Messages { get; set; }
    public int Status { get; set; }

    public Error(IEnumerable<string> msg)
    {
        Messages = msg;
    }
}

