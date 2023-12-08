using System.Security.Cryptography.X509Certificates;

namespace allspice_redo.Controllers;

[ApiController]
[Route("api/[controller]")]

public class IngredientsController : ControllerBase
{
    private readonly IngredientsService _ingredientsService;
    private readonly Auth0Provider _auth;

    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth)
    {
        _ingredientsService = ingredientsService;
        _auth = auth;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            userInfo.Id = ingredientData.CreatorId;
            Ingredient ingredient = _ingredientsService.CreateIngredient(ingredientData, userInfo.Id);
            return Ok(ingredient);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }

    }
}