using System.ComponentModel.DataAnnotations;

namespace DistanceArticle.Configuration.Settings
{
    public class DatabaseSettings
    {
        [Required(AllowEmptyStrings = false)]
        public string ConnectionString { get; set; } = null!;
    }
}
