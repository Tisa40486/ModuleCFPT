namespace SameApi.Dto
{
    public class PostInput
    {
        public int? UserDaoId { get; set; }
        public string? Title { get; set; }
        public string? content { get; set; }

        public int? likes_count { get; set; } = 0;
        public int? comments_count { get; set; } = 0;

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
