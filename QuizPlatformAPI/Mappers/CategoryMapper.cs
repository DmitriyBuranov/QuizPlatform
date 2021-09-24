
using QuizPlatform.Core.Domain.QuestionManagment;
using QuizPlatformAPI.Models;

namespace QuizPlatformAPI.Mappers;
public static class CategoryMapper
{
    public static Category MapFromModel(CategoryRequestDto request, Category Category = null)
    {
        if (Category == null)
            Category = new Category();

        Category.Name = request.Name;
 
        return Category;
    }
}
