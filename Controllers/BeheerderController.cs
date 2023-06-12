using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;

[Authorize(Roles = "Beheerder")]
public class BeheerderController : Controller
{
    //

}