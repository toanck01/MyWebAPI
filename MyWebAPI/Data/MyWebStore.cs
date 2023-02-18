using MyWebAPI.Models.Dto;

namespace MyWebAPI.Data
{
    public static class MyWebStore
    {
        public static List<MyWebDTO> MyWebList = new List<MyWebDTO>
        {
            new MyWebDTO{Id=1, Name="Pool View"},
            new MyWebDTO{Id=2, Name="Beach View"}
        };
    }
}
