namespace Book_API.DTO
{
    public class SubscriberResponseDTO
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public byte[] ProfilePicture { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int SubscriptionID { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string SubscribeType { get; set; } 
    }
}
