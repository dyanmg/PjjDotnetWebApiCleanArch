using Microsoft.AspNetCore.Mvc;
using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Application.Services;

namespace PjjDotnetWebApiCleanArch.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KategoriController(KategoriService _kategoriService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllkategori()
    {
        return Ok(_kategoriService.GetAllKategori());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var kategori = _kategoriService.GetKategoriById(id);
        return kategori == null ? NotFound() : Ok(kategori);
    }

    [HttpPost]
    public IActionResult CreateKategori(KategoriDto kategoriDto)
    {
        return Ok(_kategoriService.TambahKategori(kategoriDto));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateKategori(Guid id, KategoriDto kategoriDto)
    {
        var kategori = _kategoriService.UpdateKategori(id, kategoriDto);
        return kategori == null ? NotFound() : Ok(kategori);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteKategori(Guid id)
    {
        try
        {
            _kategoriService.DeleteKategori(id);
            return Ok("Hapus kategori berhasil");
        }
        catch
        {
            return NotFound();
        }
    }
}
