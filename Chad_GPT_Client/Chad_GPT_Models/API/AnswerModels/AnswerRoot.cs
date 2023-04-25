namespace Chad_GPT_Models.API.AnswerModels
{
}

namespace Chad_GPT_Models.API.AnswerModels
{
    public class AnswerRoot
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public List<AnswerChoice> choices { get; set; }
        public AnswerUsage usage { get; set; }
    }
}