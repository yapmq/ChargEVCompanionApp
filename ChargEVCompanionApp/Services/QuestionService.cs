using ChargEVCompanionApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChargEVCompanionApp.Services
{
    public class QuestionService
    {
        public static async Task<IEnumerable<Questions>> GetQuestion()
        {
            //await Init();

            var questions = await App.MobileService.GetTable<Questions>().ToListAsync();

            return questions;
        }

        public static async Task AddQuestion(string question, string answer)
        {
            var Question = new Questions
            {
                Question = question,
                Answer = answer,
            };

            await App.MobileService.GetTable<Questions>().InsertAsync(Question);

        }
    }
}
