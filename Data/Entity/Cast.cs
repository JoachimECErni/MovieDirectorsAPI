namespace MovieDirectorsAPI.Data.Entity
{
    public class Cast
    {
        public int Id { get; set; }
        public required int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        public required int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
