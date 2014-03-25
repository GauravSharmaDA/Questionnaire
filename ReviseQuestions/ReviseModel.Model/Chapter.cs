using System.Collections.Generic;

namespace Service.Model
{
    public class Chapter
    {
        public int ChapterId { get; set; }
        public string Name { get; set; }

        public List<Question> Questions { get; set; }
 
    }
}