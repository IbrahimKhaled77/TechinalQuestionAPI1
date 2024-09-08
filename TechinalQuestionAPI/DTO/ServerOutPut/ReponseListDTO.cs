namespace TechinalQuestionAPI.DTO.ServerOutPut
{
    public class ReponseListDTO<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<T> Items { get; set; }
    }
}
