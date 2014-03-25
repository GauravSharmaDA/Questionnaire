using System;
using System.Collections.Generic;

namespace Service.Model
{
    public class TestPackAttempt
    {
        public int TestPackAttemptId { get; set; }
        public TestPack TestPack { get; set; }
        public User AttemptedBy { get; set; }
        public DateTime AttemptedAt { get; set; }
        public TimeSpan TotalTimeSpent { get; set; }
        public List<QuestionAttempt> QuestionAttempts { get; set; }
    }
}