namespace API.Dtos
{
    public class OperationResult
    {
        public string Error { set; get; }
        public bool IsSuccess { set; get; }
        public object Data { set; get; }

        public OperationResult()
        {

        }

        public OperationResult(string error)
        {
            this.Error = error;
        }

        public OperationResult(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }

        public OperationResult(bool isSuccess, string error)
        {
            this.Error = error;
            this.IsSuccess = isSuccess;
        }

        public OperationResult(bool isSuccess, object data)
        {
            this.IsSuccess = isSuccess;
            this.Data = data;
        }

        public OperationResult(bool isSuccess, string error, object data)
        {
            this.Error = error;
            this.IsSuccess = isSuccess;
            this.Data = data;
        }
    }
}