using System;
using System.Dynamic;

namespace TSB.Models.Messages
{
    public class ResponseBase : IResponse<ResponseHeader, ExpandoObject>
    {
        public ResponseHeader Header { get; set; }
        public ExpandoObject Payload { get; set; }
    }

    public class ResponseHeader : IResponseHeader
    {
        public bool IsOK { get; set; }
        public string MsgID { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string ProcessIP { get; set; }
        public DateTime? ResponseTime { get; set; }
    }

    /// <summary>
    /// Response訊息介面
    /// </summary>
    /// <typeparam name="THeader">泛型檔頭</typeparam>
    /// <typeparam name="TPayload">泛型資料物件</typeparam>
    public interface IResponse<THeader, TPayload> : IMessage<THeader, TPayload>
        where THeader : IResponseHeader
    {
    }

    /// <summary>
    /// Response訊息檔頭介面
    /// </summary>
    public interface IResponseHeader
    {
        /// <summary>
        /// 回應狀態
        /// </summary>
        bool IsOK { get; set; }

        /// <summary>
        /// 源自請求之訊息ID
        /// </summary>
        string MsgID { get; set; }

        /// <summary>
        /// 狀態代碼
        /// </summary>
        string StatusCode { get; set; }

        /// <summary>
        /// 狀態訊息
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// 處理伺服器IP
        /// </summary>
        string ProcessIP { get; set; }

        /// <summary>
        /// 回應時間
        /// </summary>
        DateTime? ResponseTime { get; set; }
    }
}
