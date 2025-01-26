using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ViewComponentLesson.Context;
using ViewComponentLesson.Entities;

namespace ViewComponentLesson.Pages;

public class IndexModel(AppDbContext context) : PageModel
{
    private readonly AppDbContext _context = context;
    public string Message { get; set; }
    public string Info { get; set; }
    public List<Product> Products { get; set; }

    [BindProperty]
    public Product Product { get; set; }
    public void OnGet()
    {
        Products = _context.Products.ToList();

    }
    public IActionResult OnPost(int id = 0)
    {
        Console.WriteLine($"Product ID: {Product.Id}");

        if (id == 0)
        {

            _context.Products.Add(Product);
            _context.SaveChanges();
            Message = $"{Product.Name} Added successfully";
        }
        else
        {
            _context.Products.Update(Product);
            _context.SaveChanges();
            Message = $"{Product.Name} Updated successfully";
        }
        Product = new Product();
        return RedirectToPage("Index");
    }



    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        _context.Products.Remove(product!);
        await _context.SaveChangesAsync();
        Message = $"{product?.Name} Deleted successfully";
        return RedirectToPage("Index");
    }

    public IActionResult OnPostUpdate(int id)
    {
        Product = _context.Products.FirstOrDefault(x => x.Id == id)!;
        Products = _context.Products.ToList();
        return Page();
    }

}