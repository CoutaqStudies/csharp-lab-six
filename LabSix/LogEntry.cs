//written by Coutaq
using System;

namespace LabOne
{
    public class LogEntry
    {
        private string Time { get; set; }
        private string Subject { get; set; }
        public enum Action { ADD, DELETE, UPDATE }
        private Action ActionDone { get; set; }
        public LogEntry(string time, string subject, Action actionDone)
        {
            this.Time = time;
            this.Subject = subject;
            this.ActionDone = actionDone;
        }
        public LogEntry(string subject, Action actionDone)
        {
            this.Time = DateTime.Now.ToString(@"h\:mm\:ss");
            this.Subject = subject;
            this.ActionDone = actionDone;
        }
        public String getTime()
        {
            return Time;
        }
        public String getSubject()
        {
            return Subject;
        }
        public String getActionInString()
        {
            if(ActionDone == Action.ADD)
            {
                return "Added";
            }
            else if(ActionDone == Action.DELETE)
            {
                return "Deleted";
            }
            else
            {
                return "Updated";
            }
        }

        public LogEntry()
        {
        }
        public string logFormatted()
        {
            String output =  ($"{Time} - {getActionInString()} entry \"{Subject}\"");
            return output;
        }
    }
}