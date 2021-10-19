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

    private readonly IQuestionRepository<Question> _specializedRepositoryQuestions;

    public QuestionsController(IRepository<Question> repositoryQuestions, IQuestionRepository<Question> specializedRepositoryQuestions)
    {
        _repositoryQuestions = repositoryQuestions;
        _specializedRepositoryQuestions = specializedRepositoryQuestions;
    }

    /// <summary>
    /// Gets List of Questions
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<QuestionRequestDto>> GetAllQuestionsAsync()
    {
        var entities = await _repositoryQuestions.GetAllAsync();

        var list = entities.Select(entity => new QuestionResponseDto(entity)).ToList();

        return Ok(list);
    }

    /// <summary>
    /// Gets amount of Questions in Category
    /// </summary>
    /// <param name="categoryGuid">Category Guid</param>
    /// <param name="num">Amount of questions</param> 
    /// <returns></returns>
    [HttpGet("/AmountInCategory")]
    public async Task<ActionResult<QuestionRequestDto>> GetAmountQuestionsInCategoryAsync(int num, Guid categoryGuid)
    {
        var entities = await _specializedRepositoryQuestions.GetAmountInCategoryAsync(num, categoryGuid);

        if (entities == null)
            return NotFound();

        var list = entities.Select(entity => new QuestionResponseDto(entity)).ToList();

        return Ok(list);
    }

    /// <summary>
    /// Gets Question By Id
    /// </summary>
    /// <param name="id">Question Id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionRequestDto>> GetQuestionAsync(Guid id)
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
        if (request.WithTimer && request.TimerInSeconds == 0)
            return BadRequest();

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
