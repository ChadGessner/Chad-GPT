namespace Chad_GPT_Models.API
{
}

namespace Chad_GPT_Models.API
{
    public class Root
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public List<Choice> choices { get; set; }
        public Usage usage { get; set; }
    }
}