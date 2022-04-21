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

        public readonly static String USERCONTROLLER_ADD_FRIEND_1 = "ERROR: UserController; AddFriend; NULL ERROR FROM INPUT";
        public readonly static String USERCONTROLLER_ADD_FRIEND_2 = "ERROR: UserController; AddFriend; NULL ERROR FROM USERSERVICE";

        public readonly static String GAMEMASTERCONTROLLER_ADD_CARD_INPUT = "ERROR: GameMasterController; CreateCard; NULL ERROR FROM INPUT";
        public readonly static String GAMEMASTERCONTROLLER_ADD_CARD_SERVICE = "ERROR: GameMasterController; CreateCard; NULL ERROR FROM SERVICE";
    }
}
