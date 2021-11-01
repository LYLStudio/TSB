using System;
using System.Dynamic;

namespace TSB.Models.Messages
{
    public class RequestBase : IRequest<RequestHeader, ExpandoObject>
    {
        public RequestHeader Header { get; set; }
        public ExpandoObject Payload { get; set; }
    }

    public class RequestHeader : IRequestHeader
    {
        public string BatchID { get; set; }
        public string MsgID { get; set; }
        public string Action { get; set; }
        public string FrnName { get; set; }
        public string UserID { get; set; }
        public string ClientIP { get; set; }
        public string ServerIP { get; set; }
        public DateTime? RequestTime { get; set; }
    }

    /// <summary>
    /// 請求訊息介面
    /// </summary>
    /// <typeparam name="THeader">泛型檔頭</typeparam>
    /// <typeparam name="TPayload">泛型資料物件</typeparam>
    public interface IRequest<THeader, TPayload> : IMessage<THeader, TPayload>
     where THeader : IRequestHeader
    {
    }

    /// <summary>
    /// 請求訊息檔頭介面
    /// </summary>
    public interface IRequestHeader
    {
        /// <summary>
        /// 前中台串聯追蹤ID
        /// </summary>
        string BatchID { get; set; }

        /// <summary>
        /// 訊息ID
        /// </summary>
        string MsgID { get; set; }

        /// <summary>
        /// 功能或行為名稱
        /// </summary>
        string Action { get; set; }

        /// <summary>
        /// 來源系統代號
        /// </summary>
        string FrnName { get; set; }

        /// <summary>
        /// 使用者ID
        /// </summary>
        string UserID { get; set; }

        /// <summary>
        /// 使用者IP
        /// </summary>
        string ClientIP { get; set; }

        /// <summary>
        /// 接收使用者請求之伺服器IP
        /// </summary>
        string ServerIP { get; set; }

        /// <summary>
        /// 請求時間
        /// </summary>
        DateTime? RequestTime { get; set; }
    }
}
