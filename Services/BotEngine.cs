// BotEngine.cs

using System;
using System.Collections.Generic;

namespace BotAutomation
{
    public class BotEngine
    {
        private List<Rule> _detectionRules;

        public BotEngine()
        {
            _detectionRules = new List<Rule>();
        }

        public void AddRule(Rule rule)
        {
            _detectionRules.Add(rule);
        }

        public void Execute()
        {
            foreach (var rule in _detectionRules)
            {
                if (rule.IsTriggered())
                {
                    rule.ExecuteAction();
                }
            }
        }
    }

    public class Rule
    {
        private Func<bool> _condition;
        private Action _action;

        public Rule(Func<bool> condition, Action action)
        {
            _condition = condition;
            _action = action;
        }

        public bool IsTriggered()
        {
            return _condition();
        }

        public void ExecuteAction()
        {
            _action();
        }
    }
}