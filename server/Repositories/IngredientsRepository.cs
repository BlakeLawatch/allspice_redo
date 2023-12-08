
namespace allspice_redo.Services;

public class IngredientsRepository
{

    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    private Ingredient IngredientBuilder(Ingredient ingredient, Profile profile)
    {
        ingredient.Creator = profile;
        return ingredient;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO 
        ingredients(name, quantity, recipeId, creatorId)
        VALUES (@Name, @Quantity, @RecipeId, @CreatorId);
        

        SELECT *
        FROM ingredients
        JOIN accounts ON accounts.id = ingredients.creatorId
        WHERE ingredients.id = LAST_INSERT_ID();";

        Ingredient ingredient = _db.Query<Ingredient, Profile, Ingredient>(sql, IngredientBuilder, ingredientData).FirstOrDefault();
        return ingredient;
    }

}