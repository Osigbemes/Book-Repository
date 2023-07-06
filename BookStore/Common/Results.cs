using System;
namespace BookStore.Common
{
	public class Result
	{
        internal Result(bool succeeded, IEnumerable<string> messages)
        {
            Succeeded = succeeded;
            Messages = messages.ToArray();
        }

        internal Result(bool succeeded,string message, int count,IEnumerable<object> entity)
        {
            Succeeded = succeeded;
            Message = message;
            Entity = entity;
            Count = count;
        }

        internal Result(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        internal Result(bool succeeded, object result)
        {
            Succeeded = succeeded;
            Entity = result;
        }

        internal Result(bool succeeded, string message, object result)
        {
            Succeeded = succeeded;
            Message = message;
            Entity = result;
        }
        public object Entity { get; set; }
        public int Count { get; set; }
        public string Message { get; set; }
		public string[] Messages { get; set; }
		public bool Succeeded { get; set; }

		public static Result Success(string message)
		{
            return new Result(true, message);
		}
        public static Result Success(object entity)
        {
            return new Result(true, entity);
        }
        public static Result Failure(string message)
        {
            return new Result(false, message);
        }
        public static Result Success(string message, object entity)
        {
            return new Result(true, entity);
        }
        public static Result Success(string message, int count, IEnumerable<object> entity)
        {
            return new Result(true, message, count, entity);
        }
    }
}

