using Microsoft.AspNetCore.Mvc;
using PeopleRegister.Application.DTOs;
using PeopleRegister.Application.Interfaces;

namespace PeopleRegister.Presentation.Controllers;

[Route("api/people")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonApplicationService PersonApplicationService;

    public PersonController(IPersonApplicationService personApplicationService)
    {
        PersonApplicationService = personApplicationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonDTO>>> GetManyPaginated(
        [FromQuery] int Page = 1, [FromQuery] int PageItems = 20, [FromQuery] string Search = "")
    {
        return Ok(new ResponseListDTO { 
            Page = Page, 
            PageItems = PageItems, 
            Data = await PersonApplicationService.GetManyPaginated(Page, PageItems, Search) 
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDTO>> GetById(Guid id)
    {
        return Ok(await PersonApplicationService.GetById(id));
    }

    [HttpPost]
    public async Task<ActionResult<PersonDTO>> Add([FromBody] AddPersonDTO addPersonDTO)
    {
        var Id = await PersonApplicationService.Add(addPersonDTO);
        var AddedPersonUri = new Uri($"{Request.Path}{Id}");
        return Created(AddedPersonUri, null);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] PersonDTO personDTO)
    {
        await PersonApplicationService.Update(personDTO);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(Guid id)
    {
        await PersonApplicationService.Remove(id);
        return NoContent();
    }
}

