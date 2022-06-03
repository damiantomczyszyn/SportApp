using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportApp.Entities;
using SportApp.Models;

namespace SportApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly SportAppDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(SportAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Users
       // [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = _context
                .users
                .Include(r=> r.Address)
                .Include(r=>r.Training)
                .ToList();
            var userdtos = _mapper.Map<List<UserDto>>(users);

            return _context.users != null ? //jeśli nie jet puste to zwróć widok do którego wysyłasz listę 
                        View(userdtos) :
                        Problem("Entity set 'SportAppDbContext.users'  is null.");
        }

        // GET: Users/Details/5
        //[HttpGet("{id}")]//Popsuło 
        public async Task<IActionResult> Details([FromRoute]int? id)
        {
            
            if (id == null || _context.users == null)
            {
                return NotFound();
            }
            
            var user = await _context
                .users
                .Include(r => r.Address)
                .Include(r => r.Training)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto= _mapper.Map<UserDto>(user);
            return View(userDto);
        }

        // GET: Users/Create
        public IActionResult Create()//powinien dawać new userDTO i wszystko w nim zebrać a potem zmapować na inne modele
        {

            return View(new CreateUserDto());
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,LastName,Email,City,PostalCode,Street,Country")] CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }

            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UpdateUserDto>(user);
            return View(userDto);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Age,LastName,Email,City,PostalCode,Street,Country")] UpdateUserDto dto)//bindujemy te wartości na wartości modelu
        {
            var user = _context.users.FirstOrDefault(user => user.Id == id);
            if (user is null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    if (user.Address is null)
                        user.Address = new Address() { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street, Country = dto.Country };
                    else 
                    {
                        user.Address.City = dto.City;
                        user.Address.PostalCode = dto.PostalCode;
                        user.Address.Street = dto.Street;
                        user.Address.Country = dto.Country;
                    }
                    user.Age = dto.Age;
                    user.LastName= dto.LastName;
                    user.Email = dto.Email;
                    user.Name = dto.Name;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }

            var user = await _context.users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.users == null)
            {
                return Problem("Entity set 'SportAppDbContext.users'  is null.");
            }
            var user = await _context.users.FindAsync(id);
            if (user != null)
            {
                _context.users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
