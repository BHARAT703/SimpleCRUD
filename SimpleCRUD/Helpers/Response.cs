namespace SimpleCRUD.Helpers
{
    public class Response
    {
        /// <summary>
        /// constructor to set data
        /// </summary>
        /// <param name="status">can be true or false</param>
        /// <param name="data">can be a single or multiple objects.</param>
        public Response(bool status, object data)
        {
            IsSuccess = status;
            ResponseData = data;
        }

        bool IsSuccess = false;
        object ResponseData;       
    }
}
