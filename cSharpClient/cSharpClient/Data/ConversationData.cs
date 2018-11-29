using System;

namespace cSharpClient.Data
{
    public class ConversationData
    {
        public string LoggedInUserMsg { get; set; }
        public string ContactMsg { get; set; }
        public DateTime Date { get; set; }

        public ConversationData()
        {

        }

        public ConversationData(string userMsg, string contactMsg, DateTime date)
        {
            LoggedInUserMsg = userMsg;
            ContactMsg = contactMsg;
            Date = date;
        }
    }
}
