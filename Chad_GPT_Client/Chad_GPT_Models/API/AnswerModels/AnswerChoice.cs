﻿namespace Chad_GPT_Models.API.AnswerModels
{
    public class AnswerChoice
    {
        public string text { get; set; }
        public int index { get; set; }
        public object logprobs { get; set; }
        public string finish_reason { get; set; }
    }
}
