using APIDemo2.Models.Entity;
using APIDemo2.Models.Entity.InputAccount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDemo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly SimpleDbContext _context;
        public DemoController(SimpleDbContext context)
        {
            _context = context;
        }

        [HttpGet("account-list")]
        public Count Index()
        {
            return new Count
            {
                items = _context.Accounts.ToList(),
                count = _context.Accounts.Count()
            };
        }

        [HttpGet("account-list-with-id/{id}")]
        public Account AccountListbutwithID(string id)
        {
            //if(id.IsNullOrEmpty())
            //{
            //    return new id;
            //}
            return _context.Accounts.FirstOrDefault(c => c.Id == id);
        }

        [HttpPost("add-account")]
        public async Task<Account> CreateAccount([FromForm] InputAccount input)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.Id = input.Id;
                account.LoginId = input.LoginId;
                account.Password = input.Password;
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                return account;
            }
            return null;
        }

        [HttpPut("update-account-with-id/{id}")]
        public async Task<Account> UpdateAccount(string id, [FromForm] InputAccount input)
        {
            var item = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if(ModelState.IsValid)
            {
                item.Id = input.Id;
                item.LoginId = input.LoginId;
                item.Password = input.Password;
                _context.Update(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        [HttpDelete("delete-account/{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            var item = await _context.Accounts.FirstOrDefaultAsync(c => c.Id == id.ToString());
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}