using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicrosoftOrnekBackendUyg.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MicrosoftOrnekBackendUyg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }
        public class TodoItemDTO
        {

            public string Name { get; set; }
            public bool IsComplete { get; set; }
            public long ItemId { get; set; }
            public int tutar { get; set; }
            public int topkdv { get; set; }
            public int kdvsizfiyat { get; set; }
            public DateTime son_odeme { get; set; }
            public string icerik { get; set; }
            public bool odendi { get; set; }
        }
        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            return await _context.TodoItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            if (id != todoItemDTO.ItemId)
            {
                return BadRequest();
            }

            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Name = todoItemDTO.Name;
            todoItem.IsComplete = todoItemDTO.IsComplete;
            todoItem.tutar = todoItemDTO.tutar;
            todoItem.topkdv = todoItemDTO.topkdv;
            todoItem.kdvsizfiyat = todoItemDTO.kdvsizfiyat;
            todoItem.son_odeme = todoItemDTO.son_odeme;
            todoItem.icerik = todoItemDTO.icerik;
            todoItem.odendi = todoItemDTO.odendi;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        /* [HttpPost]
         public JsonResult Post(TodoItem dep)
         {
             string query = @"
                     insert into dbo.Fatura values 
                     ('" + dep.Id + @"')
                     ";
             DataTable table = new DataTable();
             string sqlDataSource = _configuration.GetConnectionString("TodoItemsController");
             SqlDataReader myReader;
             using (SqlConnection myCon = new SqlConnection(sqlDataSource))
             {
                 myCon.Open();
                 using (SqlCommand myCommand = new SqlCommand(query, myCon))
                 {
                     myReader = myCommand.ExecuteReader();
                     table.Load(myReader);

                     myReader.Close();
                     myCon.Close();
                 }
             }

             return new JsonResult("Added Successfully");
         }*/

        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> CreateTodoItem(TodoItemDTO todoItemDTO)
        {
            var todoItem = new TodoItem
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name,
                tutar = todoItemDTO.tutar,
                topkdv = todoItemDTO.topkdv,
                kdvsizfiyat = todoItemDTO.kdvsizfiyat,
                son_odeme = todoItemDTO.son_odeme,
                icerik = todoItemDTO.icerik,
                odendi = todoItemDTO.odendi
            };

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            /*return CreatedAtAction(
                nameof(GetTodoItem),
                new { id = todoItem.Id },
                ItemToDTO(todoItem));*/
            /*string query = @"
                    insert into dbo.Fatura values 
                    ('" + todoItemDTO.Id + @"')
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }*/

            return new JsonResult("Added Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(long id) =>
             _context.TodoItems.Any(e => e.ItemId == id);

        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
            new TodoItemDTO
            {
                ItemId = todoItem.ItemId,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete,
                tutar = todoItem.tutar,
                topkdv = todoItem.topkdv,
                kdvsizfiyat = todoItem.kdvsizfiyat,
                son_odeme = todoItem.son_odeme,
                icerik = todoItem.icerik,
                odendi = todoItem.odendi
            };
    }
}
