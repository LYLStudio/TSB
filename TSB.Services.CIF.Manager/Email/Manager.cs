namespace TSB.Services.CIF.Manager
{
    using System;
    using System.Dynamic;
    using System.Linq;

    using TSB.Models;
    using TSB.Models.Messages;
    using TSB.Services.CIF.Manager.Email.Models;
    using TSB.Services.CIF.Manager.Models;

    public partial class Manager : ManagerServiceBase
    {
        #region 功能項目
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
        #endregion

        public QueryContactInfoRs QueryContactInfoRq(QueryContactInfoRq rq)
        {
            var rs = new QueryContactInfoRs()
            {
                Header = new ResponseHeader()
                {
                    MsgID = rq.Header.MsgID,
                    Message = string.Empty,
                    ProcessIP = "127.0.0.2",
                    StatusCode = string.Empty
                },
                Payload = new ExpandoObject()
            };

            Preprocess(new AnythingDynamic()
            {
                Parameter = new { RQ = rq, RS = rs },
                Callback = o =>
                {
                    try
                    {
                        using (var db = new CIF.Manager.Models.CIFv2Entities())
                        {
                            #region Create test data
                            //var d1 = new Models.CustMain()
                            //{
                            //    CustID = Guid.NewGuid().ToString(),
                            //    CustPermID = "A234567890",
                            //    CustStatus = "OK"

                            //};
                            //d1.CustMail = new Models.CustMail()
                            //{
                            //    CustID = d1.CustID,
                            //    Mail = "A234567890@tsb.com.tw",
                            //    IsVerified = true
                            //};
                            //d1.CustCellphone = new Models.CustCellphone()
                            //{
                            //    CustID = d1.CustID,
                            //    Cellphone = "0900123456",
                            //    IsVerified = false
                            //};

                            //db.CustMains.Add(d1);
                            //db.SaveChanges();
                            #endregion

                            var uid = $"{o.RQ.Header.AuthData.UserID}";
                            var cust = db.CustMains.FirstOrDefault(model => model.CustPermID.Equals(uid));

                            if (Enum.TryParse<ContactInfoKind>($"{o.RQ.Payload.Type}", out var kind))
                            {
                                if (kind.HasFlag(ContactInfoKind.EMAIL))
                                {
                                    o.RS.Payload.Email = new ExpandoObject();
                                    o.RS.Payload.Email.Value = cust?.CustMail?.Mail;
                                    o.RS.Payload.Email.Verified = cust?.CustMail?.IsVerified;
                                }

                                if (kind.HasFlag(ContactInfoKind.CELLPHONE))
                                {
                                    o.RS.Payload.Cellphone = new ExpandoObject();
                                    o.RS.Payload.Cellphone.Value = cust?.CustCellphone?.Cellphone;
                                    o.RS.Payload.Cellphone.Verified = cust?.CustCellphone?.IsVerified;
                                }
                            }

                            o.RS.Header.StatusCode = Email.Models.StatusCode.SUCCESS;
                            o.RS.Header.Message = "OK";
                            o.RS.Header.ResponseTime = DateTime.Now;
                            o.RS.Header.IsOK = true;
                        }
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
                    {
                        o.RS.Header.StatusCode = Email.Models.StatusCode.ERROR_DB;
                        o.RS.Header.Message = string.IsNullOrWhiteSpace(o.RS.Header.Message) ? $"{ex.Message}" : string.Join("|", $"{o.RS.Header.Message}", $"{ex.Message}");
                        o.RS.Header.ResponseTime = DateTime.Now;
                        throw;
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                    {
                        o.RS.Header.StatusCode = Email.Models.StatusCode.ERROR_DB;
                        o.RS.Header.Message = string.IsNullOrWhiteSpace(o.RS.Header.Message) ? $"{ex.Message}" : string.Join("|", $"{o.RS.Header.Message}", $"{ex.Message}");
                        o.RS.Header.ResponseTime = DateTime.Now;
                        throw;
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                    {
                        o.RS.Header.StatusCode = Email.Models.StatusCode.ERROR_DB;
                        o.RS.Header.Message = string.IsNullOrWhiteSpace(o.RS.Header.Message) ? $"{ex.Message}" : string.Join("|", $"{o.RS.Header.Message}", $"{ex.Message}");
                        o.RS.Header.ResponseTime = DateTime.Now;
                        throw;
                    }
                    catch (Exception ex)
                    {
                        o.RS.Header.StatusCode = Email.Models.StatusCode.ERROR_GENERIC;
                        o.RS.Header.Message = string.IsNullOrWhiteSpace(o.RS.Header.Message) ? $"{ex.Message}" : string.Join("|", $"{o.RS.Header.Message}", $"{ex.Message}");
                        o.RS.Header.ResponseTime = DateTime.Now;
                        throw;
                    }
                }
            });

            return rs;

        }
    }
}
