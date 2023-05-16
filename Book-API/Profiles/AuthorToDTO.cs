using AutoMapper;

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
