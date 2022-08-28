namespace ProductApi.ApiException
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {

        }
        public NotFoundException(string message) : base(String.Format("Not found Id {0}", message)){ }

    }
}
