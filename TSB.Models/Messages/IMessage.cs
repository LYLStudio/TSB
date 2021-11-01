namespace TSB.Models.Messages
{
    public interface IMessage<THeader, TPayload>
    {
        THeader Header { get; set; }
        TPayload Payload { get; set; }
    }
}
