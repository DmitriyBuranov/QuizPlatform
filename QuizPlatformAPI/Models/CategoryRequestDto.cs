
using QuizPlatform.Core.Domain;
using QuizPlatform.Core.Domain.QuestionManagment;

namespace QuizPlatformAPI.Models;
public class CategoryRequestDto 
{
    public string Name{ get; set; }


    public CategoryRequestDto()
    {

    }

    public CategoryRequestDto(Category Category)
    {
        Name = Category.Name;
    }
}
 