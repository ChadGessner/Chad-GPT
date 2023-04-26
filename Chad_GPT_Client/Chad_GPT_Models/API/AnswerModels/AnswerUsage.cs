namespace Chad_GPT_Models.API.AnswerModels
{
    public class AnswerUsage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }
}