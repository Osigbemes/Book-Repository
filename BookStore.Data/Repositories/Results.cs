using System;
namespace BookStore.Data.Repositories
{
	public class Results
	{
        internal Results(bool succeeded, IEnumerable<string> messages)
        {
            Succeeded = succeeded;
            Messages = messages.ToArray();
        }

        internal Results(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        internal Results(bool succeeded, object result)
        {
            Succeeded = succeeded;
            Entity = result;
        }

        internal Results(bool succeeded, string message, object result)
        {
            Succeeded = succeeded;
            Message = message;
            Entity = result;
        }
        public object Entity { get; set; }
		public string Message { get; set; }
		public string[] Messages { get; set; }
		public bool Succeeded { get; set; }

		public static Results Success(string message)
		{
            return new Results(true, message);
		}
        public static Results Failure(string message)
        {
            return new Results(false, message);
        }
        public static Results Success(string message, object entity)
        {
            return new Results(true, entity);
        }
    }
}

