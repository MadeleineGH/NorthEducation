using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Education_Admins.Controllers
{
  [Route("[controller]")]
  public class CategoryController : Controller
  {
    private readonly IConfiguration _config;

    public CategoryController(IConfiguration config)
    {
      _config = config;
    }
  }
}