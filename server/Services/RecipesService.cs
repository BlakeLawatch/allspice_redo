




namespace allspice_redo.Services;

public class RecipesService
{

    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
        _repo = repo;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repo.CreateRecipe(recipeData);
        return recipe;
    }

    internal string DestroyRecipe(int recipeId, string userId)
    {
        Recipe recipe = GetRecipeById(recipeId);
        if (recipe.CreatorId != userId)
        {
            throw new Exception("Not your Recipe to delete");
        }
        _repo.DestroyRecipe(recipeId);
        return "Recipe has been deleted";
    }

    internal Recipe EditRecipe(int recipeId, Account userInfo, Recipe recipeData)
    {
        Recipe originalRecipe = GetRecipeById(recipeId);
        if (originalRecipe.CreatorId != userInfo.Id)
        {
            throw new Exception("Not your recipe to edit");
        }
        originalRecipe.Title = recipeData.Title ?? originalRecipe.Title;
        originalRecipe.Instructions = recipeData.Instructions ?? originalRecipe.Instructions;
        originalRecipe.Img = recipeData.Img ?? originalRecipe.Img;
        originalRecipe.Category = recipeData.Category ?? originalRecipe.Category;

        Recipe recipe = _repo.EditRecipe(originalRecipe);
        return recipe;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _repo.GetRecipeById(recipeId);
        if (recipe == null)
        {
            throw new Exception($"Invalid ID: {recipeId}");
        }
        return recipe;
    }

    internal List<Recipe> GetRecipes()
    {
        List<Recipe> recipes = _repo.GetRecipes();
        return recipes;
    }
}