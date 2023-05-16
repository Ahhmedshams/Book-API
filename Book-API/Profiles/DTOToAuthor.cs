using AutoMapper;
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
