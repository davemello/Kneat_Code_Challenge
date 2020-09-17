using System;


namespace SeleniumProject.CustomException
{
    public class AutomationException: Exception
    {

        public AutomationException(string msg): base(msg)
        {

        }
    }
}
