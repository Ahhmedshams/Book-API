//public abstract class BaseController<T> : Controller where T : class   you have to do 
//{
//    private readonly IRepository<T> _repository;

//    protected BaseController(IRepository<T> repository)
//    {
//        _repository = repository;
//    }

//    public virtual async Task<IActionResult> Index()
//    {
//        var entities = await _repository.GetAllAsync();
//        return View(entities);
//    }

//    public virtual async Task<IActionResult> Details(int id)
//    {
//        var entity = await _repository.GetByIdAsync(id);
//        if (entity == null)
//        {
//            return NotFound();
//        }

//        return View(entity);
//    }

//    public virtual IActionResult Create()
//    {
//        return View();
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public virtual async Task<IActionResult> Create(T entity)
//    {
//        if (ModelState.IsValid)
//        {
//            await _repository.CreateAsync(entity);
//            return RedirectToAction(nameof(Index));
//        }
//        return View(entity);
//    }

//    public virtual async Task<IActionResult> Edit(int id)
//    {
//        var entity = await _repository.GetByIdAsync(id);
//        if (entity == null)
//        {
//            return NotFound();
//        }
//        return View(entity);
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public virtual async Task<IActionResult> Edit(int id, T entity)
//    {
//        if (id != entity.Id)
//        {
//            return NotFound();
//        }

//        if (ModelState.IsValid)
//        {
//            try
//            {
//                await _repository.UpdateAsync(entity);
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!await _repository.EntityExistsAsync(entity.Id))
//                {
//                    return NotFound();
//                }
//                throw;
//            }
//            return RedirectToAction(nameof(Index));
//        }
//        return View(entity);
//    }

//    public virtual async Task<IActionResult> Delete(int id)
//    {
//        var entity = await _repository.GetByIdAsync(id);
//        if (entity == null)
//        {
//            return NotFound();
//        }

//        return View(entity);
//    }

//    [HttpPost, ActionName("Delete")]
//    [ValidateAntiForgeryToken]
//    public virtual async Task<IActionResult> DeleteConfirmed(int id)
//    {
//        await _repository.DeleteAsync(id);
//        return RedirectToAction(nameof(Index));
//    }
//}
