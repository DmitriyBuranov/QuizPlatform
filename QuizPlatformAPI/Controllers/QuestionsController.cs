using Microsoft.AspNetCore.Mvc;
using QuizPlatform.Core.Abstractions.Repositories;
using QuizPlatform.Core.Domain.QuestionManagment;
using QuizPlatformAPI.Mappers;
using QuizPlatformAPI.Models;

namespace QuizPlatformAPI.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class QuestionsController : ControllerBase
{

    private readonly IRepository<Question> _repositoryQuestions;
     
    public QuestionsController(IRepository<Question> repositoryQuestions)
    {
        _repositoryQuestions = repositoryQuestions;
    }

    /// <summary>
    /// Gets List of Questions
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<QuestionRequestDto>> GetQuestionsAsync()
    {
        var entities = await _repositoryQuestions.GetAllAsync();

        var list = entities.Select(entity => new QuestionRequestDto(entity)).ToList();

        return Ok(list);
    }

    /// <summary>
    /// Gets Question By Id
    /// </summary>
    /// <param name="id">Question Id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionRequestDto>> GettQuestionAsync(Guid id)
    {
        var entity = await _repositoryQuestions.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        var model = new QuestionRequestDto(entity);

        return Ok(model);
    }

    /// <summary>
    /// Creates Question
    /// </summary>        
    /// <param name="request">Question Dto</param>
    /// <returns>Question Id</returns>
    [HttpPost]
    public async Task<ActionResult<Guid>> CreatetQuestionAsync(QuestionRequestDto request)
    {

        var entity = QuestionMapper.MapFromModel(request);

        await _repositoryQuestions.AddAsync(entity);

        return Ok(entity.Id);

    }

    /// <summary>
    /// Updates Question
    /// </summary>
    /// <param name="id">Question Id</param>
    /// <param name="request">Question Dto</param> 
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatetQuestionAsync(Guid id, QuestionRequestDto request)
    {
        var entity = await _repositoryQuestions.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        QuestionMapper.MapFromModel(request, entity);

        await _repositoryQuestions.UpdateAsync(entity);

        return Ok();
    }

    /// <summary>
    /// Deletes Question
    /// </summary>
    /// <param name="id">Question Id</param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> DeletetQuestion(Guid id)
    {
        var entity = await _repositoryQuestions.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        await _repositoryQuestions.DeleteAsync(entity);

        return Ok();
    }
}
