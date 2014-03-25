using System;
using System.Collections.Generic;

namespace Service.Model
{
    public class TestPack
    {
        public int TestPackId { get; set; }
        public string TestPackName { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Question> Questions { get; set; }
    }
}