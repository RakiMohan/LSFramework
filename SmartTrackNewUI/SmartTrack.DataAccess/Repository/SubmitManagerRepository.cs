using SmartTrack.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrack.DataAccess.Repository
{
    public class SubmitManagerRepository
    {
        public SubmitToManagerModel GetSubmitToManagerData(DataRow SubmitToManager_Data)
        {
            SubmitToManagerModel submitToManagerModel = new SubmitToManagerModel();
            submitToManagerModel.strClientName = SubmitToManager_Data["P3"].ToString().Trim();
            submitToManagerModel.strMainMenuLink = SubmitToManager_Data["P4"].ToString().Trim();
            submitToManagerModel.strSubMenuLink = SubmitToManager_Data["P5"].ToString().Trim();
            submitToManagerModel.str_Link_ReqNumber = SubmitToManager_Data["P6"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_ViewCandidates = SubmitToManager_Data["P7"].ToString().Trim();
            submitToManagerModel.str_CandidateName = SubmitToManager_Data["P8"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_SubmitToManager = SubmitToManager_Data["P9"].ToString().Trim();
            //submitToManagerModel.str_Txt_FinalBillRate = SubmitToManager_Data["P10"].ToString().Trim();
            //submitToManagerModel.str_Txt_FinalOTRate = SubmitToManager_Data["P11"].ToString().Trim();
            submitToManagerModel.str_Btn_SumitToManager_Action = SubmitToManager_Data["P10"].ToString().Trim();
            submitToManagerModel.str_Btn_SumitToManager_Action_Confirm = SubmitToManager_Data["P11"].ToString().Trim();
            submitToManagerModel.str_Btn_SumitToManager_Action_Confirm_OK = SubmitToManager_Data["P12"].ToString().Trim();

            // Add to Do Not Submit List
            submitToManagerModel.str_Link_ActionList_AddtoDoNotSubmitList = SubmitToManager_Data["P9"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_RecallfromDoNotSubmitList = SubmitToManager_Data["P9"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_Feedback = SubmitToManager_Data["P9"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_Shortlist = SubmitToManager_Data["P9"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_UnShortlist = SubmitToManager_Data["P9"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_RequestResubmission = SubmitToManager_Data["P9"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_InitiateOnboarding = SubmitToManager_Data["P9"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_SubmittedManagerDetail = SubmitToManager_Data["P9"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_SubmittoAdditionalManagers = SubmitToManager_Data["P9"].ToString().Trim();
            submitToManagerModel.str_Link_ActionList_Reject = SubmitToManager_Data["P9"].ToString().Trim();

            submitToManagerModel.str_Select_Reason_ReasonId = SubmitToManager_Data["P10"].ToString().Trim();

            submitToManagerModel.str_text_Comments_txtComments = SubmitToManager_Data["P11"].ToString().Trim();
            submitToManagerModel.str_text_Justification_txtComments = SubmitToManager_Data["P11"].ToString().Trim();
            submitToManagerModel.str_select_ConfigurationRule_onboardConfigID = SubmitToManager_Data["P11"].ToString().Trim();
            submitToManagerModel.str_typeahead_SubmittoAdditionalManagers_txtManager = SubmitToManager_Data["P11"].ToString().Trim();
            submitToManagerModel.str_Select_RejectReason_ReasonId = SubmitToManager_Data["P11"].ToString().Trim();
            submitToManagerModel.str_Txt_Comment_txtComments = SubmitToManager_Data["P11"].ToString().Trim();

            submitToManagerModel.str_button_AddtoDoNotSubmitList = SubmitToManager_Data["P12"].ToString().Trim();
            submitToManagerModel.str_button_RecallfromDoNotSubmitList = SubmitToManager_Data["P12"].ToString().Trim();
            submitToManagerModel.str_button_SendFeedback = SubmitToManager_Data["P12"].ToString().Trim();
            submitToManagerModel.str_button_Shortlist = SubmitToManager_Data["P12"].ToString().Trim();
            submitToManagerModel.str_button_UnShortlist = SubmitToManager_Data["P12"].ToString().Trim();
            submitToManagerModel.str_button_RequestResubmission = SubmitToManager_Data["P12"].ToString().Trim();
            submitToManagerModel.str_button_InitiateOnboarding = SubmitToManager_Data["P12"].ToString().Trim();
            submitToManagerModel.str_button_SubmittedManagerDetail_Cancel = SubmitToManager_Data["P12"].ToString().Trim();
            submitToManagerModel.str_button_SubmittoManager = SubmitToManager_Data["P12"].ToString().Trim();
            submitToManagerModel.str_button_Reject = SubmitToManager_Data["P12"].ToString().Trim();

            submitToManagerModel.str_Txt_CandidateName = SubmitToManager_Data["P8"].ToString().Trim();


            return submitToManagerModel;
        }


    }
}

