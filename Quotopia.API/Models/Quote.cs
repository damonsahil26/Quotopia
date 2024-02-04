using System.ComponentModel.DataAnnotations.Schema;

namespace Quotopia.API.Models
{
    public class Quote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Quotation { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
    }
}
