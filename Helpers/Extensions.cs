using Book_API.DTO;
using Book_API.Models;

namespace Book_API.Helpers
{
    static public class Extensions
    {
        static public CategoryDTO ToCategoryDTO(this Category category)
        {
            CategoryDTO CD = new CategoryDTO() { Id = category.Id, Name = category.Name };
            foreach (Book book in category.Books)
                CD.Books.Add(book.Title);
            return CD;
        }
        static public PurchasableBookDTO ToPurchasableBookDTO(this PurchasableBook book)
        {
            PurchasableBookDTO PBD = new PurchasableBookDTO()
            {
                Id = book.Id,
                Title = book.Title,
                AuthorName = book.Author.Name,
                Image = book.Image,
                Price = book.Price,
                NumberOfPages = book.NumberOfPages,
                Quantity = book.Quantity
            };
            foreach (Category category in book.Categories)
                PBD.Categories.Add(category.Name);
            return PBD;
        }
        static public RentableBookDTO ToRentableBookDTO(this RentableBook book)
        {
            RentableBookDTO RBD = new RentableBookDTO()
            {
                Id = book.Id,
                Title = book.Title,
                AuthorName = book.Author.Name,
                Image = book.Image,
                NumberOfPages = book.NumberOfPages,
                AvailableCopies = book.AvailableCopies,
                NumberOfCopies = book.NumberOfCopies,
            };
            foreach (Category category in book.Categories)
                RBD.Categories.Add(category.Name);
            return RBD;
        }


        // User 
        static public ApplicationUser ToApplicationUser(this RegisterUserDTO user)
        {
            ApplicationUser userModel = new()
            {
                Email = user.Email,
                UserName = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

            return userModel;
        }
    }
}
