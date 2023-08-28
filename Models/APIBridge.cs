using System.Dynamic;
using System.Text;

namespace WorkFlow.Models
{
    public class APIBridge : IDisposable
    {

        #region public properties
        public bool isSuccess { get; set; }
        public object responseData { get; set; }
        #endregion

        #region constructor
        public APIBridge()
        {

        }
        #endregion

        #region internal methods


        internal static APIBridge POST(APIBridgeRequest reqObj)
        {
            List<APIMapping> endPoints = new List<APIMapping>
            {
                   #region Get APIS ENDPOINTS

                   new APIMapping("groupview", "groups/View", "GET"),
                   new APIMapping("grouplist", "groups/list", "GET"),
                   new APIMapping("geticon", "setup/icon", "GET"),
                   new APIMapping("getcompany", "setup/company", "GET"),
                   new APIMapping("getrole", "setup/role", "GET"),
                   new APIMapping("getapprovalmatrics", "setup/approvalmatrics", "GET"),
                   new APIMapping("getavailableworkflow", "WorkFlow/availablelist", "GET"),
                   new APIMapping("getworkflowdetail", "WorkFlow/workflowdetail", "GET"),
                   new APIMapping("getworkflowlist", "WorkFlow/workflowlist", "GET"),
                   new APIMapping("getauth", "auth", "GET"),
                   new APIMapping("getactiveworkflow", "WorkFlow/ActiveWorkFlow", "GET"),
                   new APIMapping("Getdocumenttype", "Setup/GetDocumentType", "get"),
                    #endregion

                   #region Get CRF APIS
                   new APIMapping("getcustomercode", "Setup/crf/GetCustomerCode", "POST"),
                   new APIMapping("getindustry", "Setup/crf/GetIndustry", "POST"),
                   new APIMapping("getproduct", "Setup/crf/GetProduct", "POST"),
                   new APIMapping("getstation", "Setup/crf/GetStation", "POST"),
                   new APIMapping("getsalesperson", "Setup/crf/GetSalesTeam", "POST"),
                   new APIMapping("getcollector", "Setup/crf/GetCollectorCode", "POST"),
                   new APIMapping("getparentcustomer", "Setup/crf/GetParentCustomer", "POST"),
                   new APIMapping("gettariff", "Setup/crf/GetExpCorpTariff", "POST"),
                   new APIMapping("getemployee", "Setup/crf/GetEmployeeInfo", "POST"),
                   new APIMapping("getroute", "Setup/crf/GetRoute", "POST"),
                   new APIMapping("getbusiness", "Setup/crf/GetBusinessType", "POST"),
                   new APIMapping("getbusinessfrequency", "Setup/crf/GetBusinessFrequency", "POST"),
                   new APIMapping("getsaleschannel", "Setup/crf/getSalesChannel", "POST"),
                   new APIMapping("getcreditterm", "Setup/crf/GetCreditTerms", "POST"),
                   new APIMapping("getbillingtype", "Setup/crf/GetBillingType", "POST"),
                   new APIMapping("gettarifftype", "Setup/crf/GetTariffType", "POST"),
                   new APIMapping("getrecoverytype", "Setup/crf/GetRecoveryType", "POST"),
                   new APIMapping("getrecoverystation", "Setup/crf/GetRecoveryStation", "POST"),
                   new APIMapping("getsalesdecision", "Setup/crf/SalesDecision", "POST"),
                   new APIMapping("getbillingcycle", "Setup/crf/BillingCycle", "POST"),
                   //new APIMapping("gettariffyear", "Setup/crf/TariffYear", "POST"),
                   new APIMapping("getterritorycode", "Setup/crf/GetTerritoryCode", "POST"),
                   new APIMapping("gettariffyear", "Setup/TariffYear", "GET"),
                   new APIMapping("getzone", "Setup/Zone", "GET"),
                   new APIMapping("getregion", "Setup/Region", "GET"),
                   new APIMapping("getarea", "Setup/Area", "GET"),
                   new APIMapping("getcreditdays", "Setup/CreditDays", "GET"),


                   new APIMapping("getcustomerregistration", "CustomerRegistration/Get", "GET"),
                   new APIMapping("savecustomerregistration", "CustomerRegistration/Save", "POST"),
                   new APIMapping("submitcustomerregistration", "CustomerRegistration/Submit", "POST"),
                   new APIMapping("getsla", "CustomerRegistration/GetSLADocument", "GET"),
                   new APIMapping("gettariffsector", "Setup/TariffSector", "GET"),
                   new APIMapping("gettariffcharges", "Setup/TariffCharges", "GET"),
                   new APIMapping("viewdocument", "CustomerRegistration/View", "GET"),
                   new APIMapping("getdocuments", "CustomerRegistration/GetDocuments", "GET"),
                   new APIMapping("uploaddocument", "CustomerRegistration/Upload", "POST"),
                   new APIMapping("deletesla", "CustomerRegistration/DeletSLA", "POST"),

                    

                    #endregion

                     #region Note APIS ENDPOINTS
                    new APIMapping("getinvoice", "Note/GetInvoiceInfo", "GET"),
                    new APIMapping("getnote", "Note/Get", "GET"),
                    new APIMapping("savenote", "Note/Save", "POST"),
                    new APIMapping("submitnote", "Note/Submit", "POST"),
                    new APIMapping("viewdocument", "Note/View", "GET"),
                    new APIMapping("getdocuments", "Note/GetDocuments", "GET"),
                    new APIMapping("uploaddocument", "Note/Upload", "POST"),
                    new APIMapping("getreason", "setup/Note/GetReasonCode", "GET"),
                    new APIMapping("getdistributiontype", "setup/Note/GetDistributionType", "GET"),
                    new APIMapping("getcustomerinfo", "setup/Note/GetCustomerInfo", "GET"),
                    new APIMapping("notetocls", "Note/NoteToCls", "POST"),
                    

                   
                    #endregion

                   #region User APIS ENDPOINTS
                   new APIMapping("getuserdetail", "User/Get", "GET"),
                   new APIMapping("adduser", "user/createuser", "POST"),
                   new APIMapping("updateuser", "user/updateuser", "POST"),
                  new APIMapping("getworkflowbyuser", "FormGroup/GETUserWorkFlow", "GET"),
                   #endregion

                   #region MyForm APIS ENDPOINTS
                   new APIMapping("getactiveforms", "FormGroup/ActiveForms", "GET"),
                   new APIMapping("getsentforms", "FormGroup/SentForms", "GET"),
                   new APIMapping("getcompletedforms", "FormGroup/CompletedForms", "GET"),
                    #endregion

                   #region Recipient APIS ENDPOINTS
                   new APIMapping("gethistory", "Recipient/GetHisotry", "GET"),
                   new APIMapping("getcrrecipient", "Recipient/GetCRRecipients", "GET"),
                   new APIMapping("getnoterecipient", "Recipient/GetNoteRecipients", "GET"),
                   new APIMapping("getowner", "Recipient/GetOwner", "GET"),
                   new APIMapping("changeapproval", "Recipient/GetFormForChangeApproval", "GET"),
                   new APIMapping("updateapproval", "Recipient/UpdateApproval", "POST"),
                   new APIMapping("getchangeapproval", "Recipient/GetChangeApprovalReceipt", "GET"),

                   
                   #endregion

                   #region POST APIS ENDPOINTS
                    //new APIMapping("setup-user-list", "groups/list", "POST"),
                    new APIMapping("addgroup", "groups/create", "POST"),
                    new APIMapping("updategroup", "groups/update", "POST"),
                    new APIMapping("updateworkflow", "workflow/updateworkflow", "POST"),
                    #endregion

                    #region CN Swap APIs
                    new APIMapping("getCNdetails","SwappingCN/FetchDetailByCN","GET"),
                    new APIMapping("getCNSwapDetails","SwappingCN/Get","GET"),
                    new APIMapping("getCNSwapRecipient","Recipient/GetSwapCNRecipients","GET"),
                    new APIMapping("cnSwapSave","SwappingCN/Save","POST"),
                    new APIMapping("cnSubmit","SwappingCN/Submit","POST"),
                    #endregion
            };

            //string baseUrl = "https://devconnect.tcscourier.com/gworkflow/api/";
            string baseUrl = EnvironmentConstants.BaseURL;
            //"http://localhost:5015/api/";

            bool success = false;
            ExpandoObject outData = null;

            try
            {
                if (reqObj != null && !string.IsNullOrEmpty(reqObj.actionName))
                {
                    var _endoint = endPoints.FirstOrDefault(x => x.selfName.ToLower() == reqObj.actionName.ToLower());

                    if (_endoint != null)
                    {

                        string url = $"{baseUrl}{_endoint.endPoints}";
                        HttpMethod apiMethod = HttpMethod.Post;
                        if (_endoint.type.Contains("POST"))
                        {
                            //apiMethod = HttpMethod.Post;
                            var httpClient = new HttpClient();


                            var bodyJson = System.Text.Json.JsonSerializer.Serialize(reqObj.data);
                            var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");
                            var response = httpClient.PostAsync(url, stringContent).Result;
                            try
                            {
                                using var reader = new StreamReader(response.Content.ReadAsStream());
                                var responseBody = reader.ReadToEnd();

                                if (!string.IsNullOrEmpty(responseBody))
                                {
                                    responseBody = responseBody.StartsWith("[") ? $"{{\"list\":{responseBody}}}" : responseBody;
                                    try
                                    {
                                        if (response.IsSuccessStatusCode)
                                        {
                                            success = true;
                                            outData = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(responseBody);
                                        }
                                        else
                                        {
                                            success = false;
                                            outData = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(responseBody);
                                        }

                                    }
                                    catch (Exception ex)
                                    {

                                        return new APIBridge
                                        {
                                            isSuccess = success,
                                            responseData = outData
                                        };
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                //return new APIBridge
                                //{
                                //    isSuccess = false,
                                //    responseData = outData
                                //};

                                throw ex;
                            }
                        }
                        else
                        {
                            apiMethod = HttpMethod.Get;

                            if (!string.IsNullOrEmpty(reqObj.param))
                            {
                                url = url + '?' + reqObj.param;
                            }

                            var httpClient = new HttpClient();
                            var request = new HttpRequestMessage(apiMethod, url);
                            var response = httpClient.Send(request);
                            using var reader = new StreamReader(response.Content.ReadAsStream());
                            var responseBody = reader.ReadToEnd();
                            if (!string.IsNullOrEmpty(responseBody))
                            {
                                responseBody = responseBody.StartsWith("[") ? $"{{\"list\":{responseBody}}}" : responseBody;

                                try
                                {
                                    if (response.IsSuccessStatusCode)
                                    {
                                        success = true;
                                        outData = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(responseBody);

                                    }
                                    else
                                    {
                                        success = false;
                                        outData = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(responseBody);

                                    }

                                }
                                catch (Exception ex) { throw ex; }
                            }
                        }

                    }
                    else
                    {
                        success = false;
                        string jsonDept = @"{'code': '404', 'DeserializeObject': 'Not Found. Invalid endpoint'}";
                        outData = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(jsonDept);
                        //outData = (dynamic)new { code = 404, message = "Not Found. Invalid endpoint" };
                    }
                }

            }
            catch (Exception ex)
            {
                return new APIBridge
                {
                    isSuccess = false,
                    responseData = $"{ex.Message}. {ex.InnerException.InnerException.Message}"
                };
            }

            return new APIBridge
            {
                isSuccess = success,
                responseData = outData
            };
        }

        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            // no implementation
        }
        #endregion
    }
}