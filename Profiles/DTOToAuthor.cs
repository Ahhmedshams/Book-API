using AutoMapper;
using Book_API.DTO;
using Book_API.Models;

namespace Book_API.Profiles
{
    public class DTOToAuthor: Profile
    {
        public DTOToAuthor()
        {

            CreateMap<AuthorDTO, Author>();
        }
    }
}
