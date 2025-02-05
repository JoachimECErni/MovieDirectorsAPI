namespace MovieDirectorsAPI.Data.Entity
{
    public class ActorMovie
    {
        public int Id { get; set; }
        public required int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        public required int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
