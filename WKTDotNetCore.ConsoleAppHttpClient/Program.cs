// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

//string jsonstr = await File.ReadAllTextAsync("data.json");
string jsonstr = await File.ReadAllTextAsync("DreamDictionary.json");
//var model = JsonConvert.DeserializeObject<MainDto>(jsonstr);
var model = JsonConvert.DeserializeObject<MainDrDTO>(jsonstr);

Console.WriteLine(jsonstr);
//foreach (var question in model.questions)
//{
//    Console.WriteLine(question.questionNo);
//}
foreach (var blogHeader in model.BlogHeader)
{
    Console.WriteLine(blogHeader.BlogId);
}
//JSON to C# ??? package
//C# to JSON

Console.ReadLine();

static string ToNumber(string num)
{
    num = num.Replace("၃", "3");
    num = num.Replace("၃", "3");
    num = num.Replace("၃", "3");
    num = num.Replace("၃", "3");
    return num;
}

public class MainDto
{
    public Question[] questions { get; set; }
    public Answer[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Question
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answer
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}



public class MainDrDTO
{
    public Blogheader[] BlogHeader { get; set; }
    public Blogdetail[] BlogDetail { get; set; }
}

public class Blogheader
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
}

public class Blogdetail
{
    public int BlogDetailId { get; set; }
    public int BlogId { get; set; }
    public string BlogContent { get; set; }
}
