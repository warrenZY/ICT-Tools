using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using QuestionParserHTML.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuestionParserHTML.Services;

public class HTMLParserService : IHTMLParserService
{
    
    public QuestionData GetQuestionData(string htmlString)
    {
        QuestionData questionData = new();
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(htmlString);
        
        if (htmlDoc.DocumentNode.SelectSingleNode("//div [@class='right-main']") == null)
            return questionData;
        //htmlDoc.DocumentNode.SelectSingleNode("//div [@data-v-c083a7f4] [@class]")
        HtmlNode questionNode = htmlDoc.DocumentNode.
            SelectSingleNode("//div [@class='right-main']");
        //HtmlNode questionContentNode = questionNode.
        //    SelectSingleNode(".//div [@data-v-1f6a3e43] [@data-v-c083a7f4] [@class='subtitle']");
        
        HtmlNode questionContentNode = questionNode.
            SelectSingleNode(".//div [@data-v-1f6a3e43] [@class='subtitle']");
        HtmlNodeCollection questionOptionNodeCollection = questionNode.
            SelectNodes(".//div [@data-v-4d8bc5d6] [@class='option-list-item']");

        questionData.QuestionContent = questionContentNode.InnerText;
        /*
       if (questionContentNode.SelectSingleNode(
                "//div [@data-v-2e2876ce] [@class='content']") != null)
            {
                questionData.QuestionContent = questionContentNode.SelectSingleNode(
                    "//div [@data-v-2e2876ce] [@class='content']").InnerText;
            }else if(questionContentNode.SelectSingleNode(
                "//div [@data-v-2e2876ce] [@class='editor-content']") != null)
            {
                questionData.QuestionContent = questionContentNode.SelectSingleNode(
                "//div [@data-v-2e2876ce] [@class='editor-content']").InnerText;
            }

        */



        string questionOptionOrder = string.Empty;
        string questionOptionContent = string.Empty;
        foreach (var question in questionOptionNodeCollection)
        {
            if(question.SelectSingleNode(
                ".//div [@data-v-4d8bc5d6] [@class='option-order-str']") !=null)
            {
                questionOptionOrder = question.SelectSingleNode(
                    ".//div [@data-v-4d8bc5d6] [@class='option-order-str']").InnerText;
                questionData.QuestionOptionOrderList.Add(questionOptionOrder);
            }
            /*
            if (question.SelectSingleNode(
                ".//div [@data-v-2e2876ce] [@class='content']") != null)
            {
                questionOptionContent = question.SelectSingleNode(
                ".//div [@data-v-2e2876ce] [@class='content']").InnerText;
            }
            else if (question.SelectSingleNode(
                ".//div [@data-v-2e2876ce] [@class='editor-content']") != null)
            {
                questionOptionContent = question.SelectSingleNode(
                ".//div [@data-v-2e2876ce] [@class='editor-content']").InnerText;
            }
            */
            if (question.SelectSingleNode(
                ".//div [@data-v-2e2876ce]") != null)
            {
                questionOptionContent = question.SelectSingleNode(
                ".//div [@data-v-2e2876ce]").InnerText;
            }
            
            questionData.QuestionOptionContentList.Add(questionOptionContent);
        }

        return questionData;
    }
}
