using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public class MatchResult
{
    public string Value { get; }
    public int Position { get; }

    public MatchResult(string value, int position)
    {
        Value = value;
        Position = position;
    }
}
public class RegexSearcher
{
    
    
    // Поиск цитат в кавычках (русские и английские кавычки)
    public List<MatchResult> FindQuotedSentences(string text)
    {
        var pattern = "[\"“”«»](.*?)[\"“”«»]";
        return FindMatches(text, pattern);
    }

    // Поиск номеров карт "Мир": начинаются с 2200–2204 и всего 16 цифр
    public List<MatchResult> FindMirCardNumbers(string text)
    {
        var pattern = @"\b(220[0-4]\d{12})\b";
        return FindMatches(text, pattern);
    }

    // Поиск дат в формате DD/MM/YYYY с проверкой високосных лет
    public List<MatchResult> FindValidDates(string text)
    {
        var pattern = @"\b(?:(?:31/(?:0?[13578]|1[02]))|(?:29|30)/(?:0?[13-9]|1[0-2]))/((?:19|20)\d{2})" +
                      @"|(?:29/0?2/((?:(?:19|20)(?:[02468][048]|[13579][26]))))" +
                      @"|(?:0?[1-9]|1\d|2[0-8])/(?:0?[1-9]|1[0-2])/((?:19|20)\d{2})\b";

        return FindMatches(text, pattern);
    }

    // Общий метод поиска
    private List<MatchResult> FindMatches(string text, string pattern)
    {
        var results = new List<MatchResult>();
        var matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            results.Add(new MatchResult(match.Value, match.Index));
        }

        return results;
    }
}
