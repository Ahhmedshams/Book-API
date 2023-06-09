﻿namespace Book.Application.Common.Helpers
{
    static public class Extensions
    {
        static public CategoryDTO ToCategoryDTO(this Category category)
        {
            CategoryDTO CD = new CategoryDTO() { Id = category.Id, Name = category.Name };
            if (category.Books.Any())
            {
            foreach (Book.Domain.Entity.Book book in category.Books)
                CD.Books.Add(book.Title);
            }
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
            if(book.Categories.Count>0)
            {
                foreach (Category category in book.Categories)
                    PBD.Categories.Add(category.Name);
            }
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
            if (book.Categories.Count > 0)
            {
                foreach (Category category in book.Categories)
                    RBD.Categories.Add(category.Name);
            }
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
        //SubscriberDTO
        static public Subscriber ToSubscriber(this SubscriberDTO subscriber)
        {
            Subscriber sub = new()
            {
              StartDate = subscriber.StartDate,
              EndDate = subscriber.EndDate,
              UserId = subscriber.UserId,
              TypeId = subscriber.TypeId,
            };

            return sub;
        }

        static public SubscriberResponseDTO ToSubResponse (this Subscriber subscriber)
        {
            SubscriberResponseDTO sub = new()
            {
                UserId = subscriber.User.Id,
                FirstName = subscriber?.User.FirstName,
                LastName = subscriber?.User.LastName,
                Email = subscriber.User.Email,
                SubscriptionID = subscriber.Id,
                StartDate = subscriber.StartDate,
                EndDate = subscriber.EndDate,
                SubscribeType = subscriber.subscriptionType.Name

            };

            return sub;
        }

        public static ApplicationUserDTO ToApplicationUserDTO (this ApplicationUser applicationUser)
        {
            ApplicationUserDTO applicationUserDTO = new()
            {
                Id = applicationUser.Id,
                Firstname = applicationUser.FirstName,
                Lastname = applicationUser?.LastName,
                UserName = applicationUser.UserName,
                Email = applicationUser.Email,
                PhoneNumber = applicationUser.PhoneNumber,

            };
            return applicationUserDTO;
        }

        public static SubscriptionType ToASubscriptionType(this SubTypeDTO subTypeDTO)
        {
            SubscriptionType subscriptionType = new()
            {
                Name = subTypeDTO.Name,
                Price = subTypeDTO.Price,
                NumberOfBooks = subTypeDTO.NumberOfBooks,
                Description = subTypeDTO.Description,
                

            };
            return subscriptionType;
        }



    }
}
