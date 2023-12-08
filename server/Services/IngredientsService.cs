

namespace allspice_redo.Services;

public class IngredientsService
{

    private readonly IngredientsRepository _repo;


    public IngredientsService(IngredientsRepository repo)
    {
        _repo = repo;

    }

    internal Ingredient CreateIngredient(Ingredient ingredientData, string userId)
    {
        Ingredient ingredient = _repo.CreateIngredient(ingredientData);
        if (ingredientData.CreatorId != userId)
        {
            throw new Exception("This is not your recipe to modify");
        }
        return ingredient;
    }
}