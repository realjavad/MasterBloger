using System.ComponentModel.DataAnnotations;

namespace MB.Application.Contracts.ArticleCategory
{
    public class CreateArtcleCategory
    {
        [Required]
        public string Title { get; set; }
    }
}
