using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IQuestionService
    {
        IEnumerable<questionType> GetQuestionTypeList();
        bool addNewQuestionType(questionType OquestionType);
    }
}
