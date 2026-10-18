using CurriculumGenerator.Api.Models;
using CurriculumGenerator.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumGenerator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurriculumController : ControllerBase
{
    private readonly CurriculumGeneratorService _service;

    public CurriculumController(CurriculumGeneratorService service)
    {
        _service = service;
    }

    [HttpPost("generate")]
    public IActionResult Generate([FromBody] Curriculum1 curriculum)
    {
        var zipFile = _service.GenerateCv(curriculum);
        return File(zipFile.Content, zipFile.ContentType, zipFile.NomeConEstensione);
    }

    [HttpPost("from-xml")]
    public IActionResult FromXml(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Nessun file XML fornito.");

        using var stream = new MemoryStream();
        file.CopyTo(stream);
        var cv = _service.LeggiValoriDaFileXml(stream.ToArray());

        if (cv == null)
            return BadRequest("Il file XML non è in un formato valido.");

        return Ok(cv);
    }
}