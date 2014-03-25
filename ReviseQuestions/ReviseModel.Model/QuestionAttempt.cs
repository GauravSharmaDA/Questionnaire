using System;
using System.Collections.Generic;

namespace Service.Model
{
    public class QuestionAttempt
    {
        public int QuestionAttemptId { get; set; }
        public Question Question { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public bool WasAnswerCorrect { get; set; }
        public List<Answer> ChosenAnswers { get; set; }
        public List<Answer> ExpectedAnswers { get; set; } 
    }
}