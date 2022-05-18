namespace TheDarkTowerMVC.Utils
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
