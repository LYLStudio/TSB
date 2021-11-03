﻿namespace TSB.Services.CIF.Manager
{
    using System;
    using System.Dynamic;

    using Models;

    using TSB.Models;
    using TSB.Models.Messages;
    using TSB.Services.CIF.Manager.Email.Models;

    using StatusCode = Models.StatusCode;

    public partial class Manager : ManagerServiceBase
    {
        public CheckRs CheckRq(CheckRq rq)
        {
            var rs = new CheckRs();

            Preprocess(new AnythingDynamic()
            {
                Parameter = new { RQ = rq, RS = rs },
                Callback = o =>
                {
                    try
                    {
                        //TODO
                    }
                    catch (Exception ex)
                    {                       
                        throw;
                    }
                }
            });

            return rs;
        }
        
        //查詢
        //查詢EMAIL(含ＥＭＡＩＬ、驗證狀態、已申請電子對帳單類型)
        
        //異動
        //異動EMAIL
        //異動電子對帳單狀態(含綜合、基金)
        
        //驗證
        //檢查EMAIL唯一性
        //發送EMAIL驗證
        //驗證EMAIL

        //產檔
        //電子對帳單發送清單??(如以DB資料為準，可由DB直接輸出)
    }
}
