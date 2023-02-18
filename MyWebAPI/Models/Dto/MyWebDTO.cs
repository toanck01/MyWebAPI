using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Models.Dto
{
    public class MyWebDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
