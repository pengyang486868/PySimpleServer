namespace PiyiServer.Server.DataModel
{
    public class ResultModel
    {
        public object Result { get; set; }
        public bool IsSuccess { get; set; }

        public ResultModel(object obj)
        {
            IsSuccess = false;
            Result = obj;
            if (obj != null)
            {
                IsSuccess = true;
            }
        }
    }
}
