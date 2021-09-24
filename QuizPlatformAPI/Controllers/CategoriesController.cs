using Microsoft.AspNetCore.Mvc;
using QuizPlatform.Core.Abstractions.Repositories;
using QuizPlatform.Core.Domain.QuestionManagment;
using QuizPlatformAPI.Mappers;
using QuizPlatformAPI.Models;

namespace QuizPlatformAPI.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class CategoriesController : ControllerBase
{

    private readonly IRepository<Category> _repositoryCaregories;
     
    public CategoriesController(IRepository<Category> repositoryCaregories)
    {
        _repositoryCaregories = repositoryCaregories;
    }

    /// <summary>
    /// Gets List of Caregories
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<CategoryRequestDto>> GetCaregoriesAsync()
    {
        var entities = await _repositoryCaregories.GetAllAsync();

        var list = entities.Select(entity => new CategoryResponseDto(entity)).ToList();

        return Ok(list);
    }

    /// <summary>
    /// Gets Category By Id
    /// </summary>
    /// <param name="id">Category Id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryRequestDto>> GettCategoryAsync(Guid id)
    {
        var entity = await _repositoryCaregories.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        var model = new CategoryRequestDto(entity);

        return Ok(model);
    }

    /// <summary>
    /// Creates Category
    /// </summary>        
    /// <param name="request">Category Dto</param>
    /// <returns>Category Id</returns>
    [HttpPost]
    public async Task<ActionResult<Guid>> CreatetCategoryAsync(CategoryRequestDto request)
    {

        var entity = CategoryMapper.MapFromModel(request);

        await _repositoryCaregories.AddAsync(entity);

        return Ok(entity.Id);

    }

    /// <summary>
    /// Updates Category
    /// </summary>
    /// <param name="id">Category Id</param>
    /// <param name="request">Category Dto</param> 
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatetCategoryAsync(Guid id, CategoryRequestDto request)
    {
        var entity = await _repositoryCaregories.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        CategoryMapper.MapFromModel(request, entity);

        await _repositoryCaregories.UpdateAsync(entity);

        return Ok();
    }

    /// <summary>
    /// Deletes Category
    /// </summary>
    /// <param name="id">Category Id</param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> DeletetCategory(Guid id)
    {
        var entity = await _repositoryCaregories.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        await _repositoryCaregories.DeleteAsync(entity);

        return Ok();
    }
}
