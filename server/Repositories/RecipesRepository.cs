





namespace allspice_redo.Repositories;

public class RecipesRepository
{

    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO 
        recipes (title, instructions, img, category, creatorId)
        VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);



        SELECT *
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = LAST_INSERT_ID()
        ;";

        Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }, recipeData).FirstOrDefault();
        return recipe;
    }

    internal void DestroyRecipe(int recipeId)
    {
        string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";

        _db.Execute(sql, new { recipeId });
    }

    internal Recipe EditRecipe(Recipe originalRecipe)
    {
        string sql = @"
        UPDATE recipes
        SET
        instructions = @Instructions,
        title = @Title,
        img = @Img,
        category = @Category
        WHERE id = @Id;


        SELECT *
        FROM recipes
        JOIN accounts ON accounts.id = recipes.creatorId
        WHERE recipes.id = @Id
        
        ;";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }, originalRecipe).FirstOrDefault();
        return recipe;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        string sql = @"
        SELECT *
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = @RecipeId
        ;";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }, new { recipeId }).FirstOrDefault();
        return recipe;
    }

    internal List<Recipe> GetRecipes()
    {
        string sql = @"
        
        SELECT *
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        
        ;";

        List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }).ToList();
        return recipes;
    }
}