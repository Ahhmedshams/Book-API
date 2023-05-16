using AutoMapper;
using Book_API.DTO;
using Book_API.Models;

namespace Book_API.Profiles
{
    public class AuthorToDTO: Profile
    {
        public AuthorToDTO()
        {

            CreateMap<Author, AuthorDTO>();
        }
    }
}
