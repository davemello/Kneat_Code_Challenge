using System;


namespace SeleniumProject.CustomException
{
    public class NoSuitableDriverFoundException: Exception
    {
        public NoSuitableDriverFoundException(string errorMsg):base(errorMsg)
        {

        }
    }
}
