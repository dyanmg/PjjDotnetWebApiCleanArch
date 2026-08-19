using Microsoft.AspNetCore.Mvc;
using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Service.ExternalClient;

namespace PjjDotnetWebApiCleanArch.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserTypiCodeController(ITypiCodeClient _typiCodeClient) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<UserTypiCodeDto>>> GetUsers()
    {
        var users = await _typiCodeClient.GetUsersAsync();
        return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserTypiCodeWithPostsDto?>> GetUserById(string id, bool includePosts = false)
    {
        if (includePosts)
        {
            var userWithPosts = await _typiCodeClient.GetUserWithPostsByIdAsync(id);

            if (userWithPosts == null)
            {
                return NotFound();
            }

            return Ok(userWithPosts);
        }

        var user = await _typiCodeClient.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(user);
    }
}