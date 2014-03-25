using System;
using System.Globalization;
using System.Linq;
using NUnit.Framework;
using Service.Controllers;
using Service.Model;

namespace Service.Tests
{
    [TestFixture]
    public class QuestionServiceTest
    {
        private readonly QuestionController _controller;
        public QuestionServiceTest()
        {
            BootStrapper.Initialize();
            _controller = new QuestionController();
        }

        [Test]
        public void AddQuestion()
        {
            _controller.PostQuestion(new Question
                {
                    DisplayText = "What is the sum of 9 * 6?",
                    QuestionId = 15,
                    Category = new QuestionCategory
                        {
                            DisplayText = "EnglishDictionary"
                        }
                });

            var question = _controller.GetQuestion(15);

            Assert.NotNull(question);
            Assert.AreEqual("EnglishDictionary", question.Category.DisplayText);

            _controller.DeleteQuestion(question);
        }

        [Test]
        public void GetAllQuestions()
        {
            var questions = _controller.GetAllQuestions();
            Assert.NotNull(questions);
            Console.WriteLine(questions.Count().ToString(CultureInfo.InvariantCulture));
        }
       
    }
}
