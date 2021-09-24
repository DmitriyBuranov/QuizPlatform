
using QuizPlatform.Core.Domain;
using QuizPlatform.Core.Domain.QuestionManagment;

namespace QuizPlatformAPI.Models;
public class CategoryResponseDto : BaseEntity 
{
    public string Name{ get; set; }


    public CategoryResponseDto()
    {

    }

    public CategoryResponseDto(Category Category)
    {
        Id = Category.Id;
        Name = Category.Name;
    }
}
 