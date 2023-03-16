using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;


namespace Backlog.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/productbacklogitems")]
public class ProductBacklogItemsController
{

    public ProductBacklogItemsController()
    {

    }


}
