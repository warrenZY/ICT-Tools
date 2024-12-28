using QuestionParserHTML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionParserHTML.Services;

internal interface IHTMLParserService
{
    QuestionData GetQuestionData(string htmlString);
}
