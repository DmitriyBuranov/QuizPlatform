using Microsoft.AspNetCore.Mvc;
using QuizPlatform.Core.Abstractions.Repositories;
using QuizPlatform.Core.Domain.QuestionManagment;
using QuizPlatformAPI.Mappers;
using QuizPlatformAPI.Models;

namespace QuizPlatformAPI.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class QuestionTypesController : ControllerBase
{

    private readonly IRepository<QuestionType> _repositoryQuestionTypes;
     
    public QuestionTypesController(IRepository<QuestionType> repositoryQuestionTypes)
    {
        _repositoryQuestionTypes = repositoryQuestionTypes;
    }

    /// <summary>
    /// Gets List of QuestionTypes
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<QuestionTypeRequestDto>> GetQuestionTypesAsync()
    {
        var entities = await _repositoryQuestionTypes.GetAllAsync();

        var list = entities.Select(entity => new QuestionTypeResponseDto(entity)).ToList();

        return Ok(list);
    }

    /// <summary>
    /// Gets QuestionType By Id
    /// </summary>
    /// <param name="id">QuestionType Id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionTypeRequestDto>> GettQuestionTypeAsync(Guid id)
    {
        var entity = await _repositoryQuestionTypes.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        var model = new QuestionTypeRequestDto(entity);

        return Ok(model);
    }

    /// <summary>
    /// Creates QuestionType
    /// </summary>        
    /// <param name="request">QuestionType Dto</param>
    /// <returns>QuestionType Id</returns>
    [HttpPost]
    public async Task<ActionResult<Guid>> CreatetQuestionTypeAsync(QuestionTypeRequestDto request)
    {

        var entity = QuestionTypeMapper.MapFromModel(request);

        await _repositoryQuestionTypes.AddAsync(entity);

        return Ok(entity.Id);

    }

    /// <summary>
    /// Updates QuestionType
    /// </summary>
    /// <param name="id">QuestionType Id</param>
    /// <param name="request">QuestionType Dto</param> 
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatetQuestionTypeAsync(Guid id, QuestionTypeRequestDto request)
    {
        var entity = await _repositoryQuestionTypes.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        QuestionTypeMapper.MapFromModel(request, entity);

        await _repositoryQuestionTypes.UpdateAsync(entity);

        return Ok();
    }

    /// <summary>
    /// Deletes QuestionType
    /// </summary>
    /// <param name="id">QuestionType Id</param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> DeletetQuestionType(Guid id)
    {
        var entity = await _repositoryQuestionTypes.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        await _repositoryQuestionTypes.DeleteAsync(entity);

        return Ok();
    }
}
