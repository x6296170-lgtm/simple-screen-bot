namespace SimpleScreenBot.Models;

public class DetectionRule
{
    public string RuleName { get; set; }
    public string Condition { get; set; }
    public ActionCommand Action { get; set; }
}

public class ActionCommand
{
    public string CommandName { get; set; }
    public string Parameters { get; set; }
}