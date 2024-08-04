using System;

namespace Module32.MVCStart.Models.Db
{
    /// <summary>
    ///  Модель поста в блоге
    /// </summary>
    public class UserPost
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
    }
}
