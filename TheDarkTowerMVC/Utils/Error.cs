namespace TheDarkTowerMVC.Utils
{
    public class Error
    {
        //User errors
        public readonly static String USERCONTROLLER_USER_SELECT = "ERROR: UserController; USER NOT RETURNED FROM USERSERVICE";
        public readonly static String USERSERVICE_USER_SELECT = "ERROR: UserService; USER NOT RETURNED FROM USERREPO";

        public readonly static String USERCONTROLLER_CREATE_USER = "ERROR: UserController; NULL RETURNED FROM USERSERVICE";
        public readonly static String USERSERVICE_CREATE_USER = "ERROR: UserService; NULL RETURNED FROM USERREPO";

       // public readonly static String USERCONTROLLER_RECEIVED_INBOX = "ERROR: UserController; NO RECEIVED EMAILS";


    }
}
