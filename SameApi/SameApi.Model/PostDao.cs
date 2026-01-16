using SameApi.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace SameApi.Model
{
    [Table("SameApi_Post")]
    public class PostDao : IModelDao
    {
        public int Id { get; set; }
        public int? UserDaoId { get; set; }
        public UserDao? UserDao { get; set; }
        public string? Title { get; set; }
        public string? content { get; set; }

        public int? likes_count { get; set; }
        public int? comments_count { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }


    }
}
