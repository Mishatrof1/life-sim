using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core;

namespace Settings.NpcCommunication
{
    [Serializable]
    public class CommunicationChoiceSettings
    {
        public string Text;
        public List<ReplaceText> ReplaceGenderText;
        
        public virtual string GetActualText(Npc npc)
        {
            var text = Text;
            var regex = new Regex(@"({\w+})");
            foreach (Match match in regex.Matches(text))
            {
                var id = match.Value.Replace("{", "").Replace("}", "");
                var replace = ReplaceGenderText.Where(x => x.Id == id)
                    .FirstOrDefault(x => x.Value == npc.Gender.ToString());
                if (replace != null)
                {
                    text = text.Replace(match.Value, replace.Text);
                }
            }
            return text;
        }
    }
    
    [Serializable]
    public class ReplaceText
    {
        public string Id;
        public string Value;
        public string Text;
    }
}