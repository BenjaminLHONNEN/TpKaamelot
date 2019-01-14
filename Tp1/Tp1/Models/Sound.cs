using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tp1.Models
{
    [Table("SoundTable")]
    public class Sound
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }

        [JsonProperty("episode")]
        public string Episode { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }


        [JsonProperty("characterfile")]
        public string Image { get; set; }
    }
}