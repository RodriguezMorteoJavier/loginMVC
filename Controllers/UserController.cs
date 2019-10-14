using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_users.Models;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;

namespace MVC_users.Controllers
{
     [Authorize]
    public class UserController : Controller
    {
        private readonly appsContext _context;

        public UserController(appsContext context)
        {
            _context = context;
        }

  // [Authorize]
        // GET: Usuario
        public async Task <IActionResult> Index()
        {
//     var usrs = _context.Usuarios.ToList();
  // appsContext model = new appsContext();
 
// // Incluye datos de StudentDetails
 //var rols = _context.Roles.Include(x => x.Nombrerol).ToList();
// var usrs = (from p in _context.Usuarios
//                     select new Usuarios() {
//                          Id = p.Id,
//                          Nombre = p.Nombre,
//                          Rol =  p.Nombre}).ToList();
 
        // dynamic mymodel = new ExpandoObject();  
        // mymodel.Usuarios = GetUsuarios();  
        // mymodel.Roles = GetRoles();  
        // return View(mymodel);  
 
 
  return View( await _context.Usuarios.FromSql("select * from usuarios;").ToListAsync());
 // 
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .SingleOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

 

 
        // GET: Usuario/Create
        public IActionResult Create(Roles roles)
        {
          
         if(roles.Idroles == 0)
            {
                ModelState.AddModelError("","Selecciona un rol");
            }
            int Sel = roles.Idroles;
            ViewBag.SelectedValue = roles.Idroles;
            
            List<Roles> rol = new List<Models.Roles>();
            rol = (from Roles in _context.Roles
            select Roles).ToList();

            rol.Insert(0,new Roles{Idroles = 0, Nombrerol = "Selecciona "});
           ViewBag.ListofRoles = rol;
            return View();
        }

    
        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Userid,Nombre,Pass")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View(usuarios);
        }
  
        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios.SingleOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Userid,Nombre,Pass")] Usuarios usuarios)
        {
            if (id != usuarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesExists(usuarios.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .SingleOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios = await _context.Usuarios.SingleOrDefaultAsync(m => m.Id == id);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id ==id);
        }
    }
}
