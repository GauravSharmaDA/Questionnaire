using System;
using System.Collections.Generic;

namespace Service.Model
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string DisplayText { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public QuestionCategory Category { get; set; }
        public List<Answer> Answers { get; set; } 
        public List<Chapter> Chapters { get; set; }
        public List<TestPack> TestPacks { get; set; } 
    }
}
