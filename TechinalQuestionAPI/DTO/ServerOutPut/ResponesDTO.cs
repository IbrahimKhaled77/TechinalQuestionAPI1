namespace TechinalQuestionAPI.DTO.ServerOutPut
{
    public class ResponesDTO<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Item { get; set; }
        public List<T> Items { get; set; }
    }
}
