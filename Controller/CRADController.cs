//using Book_API.DTO;
//using Book_API.Interfaces;
//using Book_API.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Book_API.Controller
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CRADController<T> : ControllerBase where T : class
//    {
//        private readonly ICRUD<T> repository;
//        protected CRADController(ICRUD<T> _repository)
//        {
//            this.repository = _repository;
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<T>>> GetAll()
//        {
//            List<T> Data = await repository.GetAllAsync();
//            if (Data.Count == 0) return NotFound();
//            List<T> DataDTOs = new();
//            foreach (var item in Data)
//                DataDTOs.Add(item.ToPurchasableBookDTO());
//            return Ok(DataDTOs);
//        }

//        [HttpGet("{id:int}")]
//        public async Task<ActionResult<PurchasableBookDTO>> GetBookById(int id)
//        {
//            PurchasableBook book = await purchasableService.GetByIdAsync(id);
//            if (book == null) return NotFound();
//            return Ok(book.ToPurchasableBookDTO());
//        }

//        [HttpDelete("{id:int}")]
//        public async Task<ActionResult<PurchasableBook>> DeleteBookById(int id)
//        {
//            PurchasableBook book = await purchasableService.DeleteAsync(id);
//            if (book == null) return NotFound();
//            return Ok(book);
//        }

//        [HttpPost]
//        public async Task<ActionResult<PurchasableBookDTO>> AddBook(PurchasableBook book)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);
//            PurchasableBook addedBook = await purchasableService.AddAsync(book);
//            return Ok(addedBook.ToPurchasableBookDTO());
//        }

//        [HttpPut("{id:int}")]
//        public async Task<ActionResult<PurchasableBookDTO>> EditBook(int id, PurchasableBook book)
//        {
//            PurchasableBook editedBook = await purchasableService.EditAsync(id, book);
//            if (editedBook == null) return NotFound();
//            return Ok(editedBook.ToPurchasableBookDTO());
//        }
//    }
//}
