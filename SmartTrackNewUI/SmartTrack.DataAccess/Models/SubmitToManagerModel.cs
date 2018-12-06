using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrack.DataAccess.Models
{
    public class SubmitToManagerModel
    {
        public string strClientName { get; set; }// SubmitToManager_Data["P5"].Topublic string ().Trim();
        public string strMainMenuLink { get; set; }// SubmitToManager_Data["P6"].Topublic string ().Trim();
        public string strSubMenuLink { get; set; }// SubmitToManager_Data["P7"].Topublic string ().Trim();
        public string str_Link_ReqNumber { get; set; }// SubmitToManager_Data["P8"].Topublic string ().Trim();
        public string str_Link_ActionList_ViewCandidates { get; set; }// SubmitToManager_Data["P9"].Topublic string ().Trim();
        public string str_CandidateName { get; set; }// SubmitToManager_Data["P10"].Topublic string ().Trim();
        public string str_Link_ActionList_SubmitToManager { get; set; }// SubmitToManager_Data["P11"].Topublic string ().Trim();
        //public string  str_Txt_FinalBillRate {get;set;}// SubmitToManager_Data["P12"].Topublic string ().Trim();
        //public string  str_Txt_FinalOTRate {get;set;}// SubmitToManager_Data["P13"].Topublic string ().Trim();
        public string str_Btn_SumitToManager_Action { get; set; }// SubmitToManager_Data["P14"].Topublic string ().Trim();
        public string str_Btn_SumitToManager_Action_Confirm { get; set; }// SubmitToManager_Data["P15"].Topublic string ().Trim();
        public string str_Btn_SumitToManager_Action_Confirm_OK { get; set; }// SubmitToManager_Data["P16"].Topublic string ().Trim();
        // Add to Do Not Submit List
        public string str_Link_ActionList_AddtoDoNotSubmitList { get; set; }// SubmitToManager_Data["P9"].Topublic string ().Trim();
        public string str_Select_Reason_ReasonId { get; set; }// SubmitToManager_Data["P10"].Topublic string ().Trim();
        public string str_text_Comments_txtComments { get; set; }// SubmitToManager_Data["P11"].Topublic string ().Trim();
        public string str_text_Justification_txtComments { get; set; }
        public string str_button_AddtoDoNotSubmitList { get; set; }// SubmitToManager_Data["P12"].Topublic string ().Trim();
        public string str_button_RecallfromDoNotSubmitList { get; set; }// SubmitToManager_Data["P12"].Topublic string ().Trim();

        public string str_Link_ActionList_RecallfromDoNotSubmitList { get; set; }
        public string str_Link_ActionList_Feedback { get; set; }
        public string str_button_SendFeedback { get; set; }
        public string str_Link_ActionList_Shortlist { get; set; }
        public string str_button_Shortlist { get; set; }
        public string str_Link_ActionList_UnShortlist { get; set; }
        public string str_button_UnShortlist { get; set; }
        public string str_Link_ActionList_RequestResubmission { get; set; }
        public string str_button_RequestResubmission { get; set; }
        public string str_Link_ActionList_InitiateOnboarding { get; set; }
        public string str_select_ConfigurationRule_onboardConfigID { get; set; }
        public string str_button_InitiateOnboarding { get; set; }
        public string str_Link_ActionList_SubmittedManagerDetail { get; set; }
        public string str_button_SubmittedManagerDetail_Cancel { get; set; }
        public string str_Link_ActionList_SubmittoAdditionalManagers { get; set; }
        public string str_typeahead_SubmittoAdditionalManagers_txtManager { get; set; }
        public string str_button_SubmittoManager { get; set; }
        public string str_Link_ActionList_Reject { get; set; }
        public string str_Select_RejectReason_ReasonId { get; set; }
        public string str_Txt_Comment_txtComments { get; set; }
        public string str_button_Reject { get; set; }


        public string str_Txt_CandidateName { get; set; }
    }
}
