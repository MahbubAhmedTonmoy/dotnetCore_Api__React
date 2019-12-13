namespace API.Domain
{
    public class UserFollowing
    {
        // 2 type observer and tergate 
        // observer follow -> tergate

        public string ObserverId { get; set; }
        public virtual AppUser Observer { get; set; } //navigation property --lazy loading
        public string TergetId { get; set; }
        public virtual AppUser tergate { get; set; }

    }
}