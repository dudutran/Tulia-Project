namespace WebAPI.Models.DBModels
{
    public class Like
    {
        public Like(int SourceUserId, int LikedPostId)
        {
            this.SourceUserId = SourceUserId;
            this.LikedPostId = (int)LikedPostId;
        }
        public int Id { get; set; }
        public int SourceUserId { get; set; }
        public int LikedPostId { get; set; }
    }
}