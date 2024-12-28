using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionParserHTML.Models;

public class QuestionData
{
    public string QuestionContent = string.Empty;
    public List<string> QuestionOptionOrderList = new();
    public List<string> QuestionOptionContentList = new();

    public string StringValue()
    {
        string Value = $"{QuestionContent}\n";
        int Length = QuestionOptionContentList.Count;
        for (int index = 0; index < Length; index++)
        {
            if(QuestionOptionOrderList.Count == 0)
                Value = Value + $"{QuestionOptionContentList[index]}\n";
            else
                Value = Value + $"{QuestionOptionOrderList[index]} {QuestionOptionContentList[index]}\n";
        }
        return Value;
    }
}

public class QuestionDataList
{
    public QuestionData[]? QuestionDatas { get; set; }
}