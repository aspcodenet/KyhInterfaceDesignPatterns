namespace KyhInterfaceDesignPatterns;


interface IMessageSender
{
    void SendMessage(string message);
}

class SmsMessageSender : IMessageSender
{
    public void SendMessage(string message)
    {
        throw new NotImplementedException();
    }
}

class EmailMessageSender : IMessageSender
{
    public void SendMessage(string message)
    {
        throw new NotImplementedException();
    }
}

public class Demo3
{
    public void Run()
    {
        //ABSTRAKTION !!
        IMessageSender messageSender = new EmailMessageSender();
        //..
        //..
        //if(sdadasadsa>)
        messageSender.SendMessage("Hej hej");
    }
}