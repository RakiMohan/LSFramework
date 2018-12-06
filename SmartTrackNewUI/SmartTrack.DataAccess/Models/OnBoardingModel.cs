// --------------------------------------------------------------------------------------------------------------------
//<copyright file{get;set;}//"AcceptOfferModel" company{get;set;}//"DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Builds the Container for the Autofac IOC.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmartTrack.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class OnBoardingModel
    {
        public string strClientName { get; set; }// AcceptOffer_Data["P5"].ToString().Trim();
        public string strMainMenuLink { get; set; }// AcceptOffer_Data["P6"].ToString().Trim();
		public string strTestCaseId { get; set; }
		public string strUserID { get; set; }
        public string strSubMenuLink { get; set; }// AcceptOffer_Data["P7"].ToString().Trim();
		public string strAssetLink { get; set; }
		public string strAssetCategoryLink { get; set; }
		public string strCategoryName { get; set; }
		public string strCategoryDescription { get; set; }
		public string strAssertTypelink { get; set; }
		public string strAssertType { get; set; }
		public string strActionAssetLink { get; set; }
		public string strActionAssetName { get; set; }

		//Training
		public string strOnboardingTraining { get; set; }
		public string strTrainingname { get; set; }
		public string strTrainingDescription { get; set; }
		public string strPreSubmit { get; set; }
		public string strallCWs { get; set; }
		public string strPreStart { get; set; }
		public string strRecurring { get; set; }
		public string strRecurringFrequecy { get; set; }
		public string struploadDocumentTemplate { get; set; }

		//Onboarding Documents

		public string strOnboardingDocumentlink { get; set; }
		public string strDocument { get; set; }
		public string strDocumentType { get; set; }
		public string strExpiryDays { get; set; }
		public string strDocPreSubmit { get; set; }
		public string strDocPreStart { get; set; }
		public string strAdminOverirdeAllowed { get; set; }
		public string strDocumentUploadRequired { get; set; }
		public string struploaddocDocumentTemplate { get; set; }

		//onboarding Compliance

		public string strOnboardingCompliancelink { get; set; }
		public string strComplainceName { get; set; }
		public string strComplainceType { get; set; }
		public string strComplainceDescription { get; set; }
		public string strstepconfigurationname { get; set; }
		public string strstepconfigurationbymsp { get; set; }
		public string strpkgconfigurationname { get; set; }
		public string strpkgconfigurationindefinite { get; set; }
		public string strpkgconfigurationExpirydays { get; set; }
		public string strCompliancePreSubmit { get; set; }// AcceptOffer_Data["P8"].ToString().Trim();
		public string strCompliancePreStart { get; set; }// AcceptOffer_Data["P9"].ToString().Trim();
		public string strComplianceAdminOverirdeAllowed { get; set; }// AcceptOffer_Data["P10"].ToString().Trim();
		public string strComplianceAdminOverirdeReasons { get; set; }// AcceptOffer_Data["P11"].ToString().Trim();
		public string strCompliancetUploadRequired { get; set; }// AcceptOffer_Data["P12"].ToString().Trim();



        
        public string str_Link_ReqNumber { get; set; }// AcceptOffer_Data["P8"].ToString().Trim();
        public string str_Link_CandidatesWithOffers { get; set; }// AcceptOffer_Data["P9"].ToString().Trim();
        public string str_CandidateName { get; set; }// AcceptOffer_Data["P10"].ToString().Trim();
        public string str_ActionLink_AddTraining { get; set; }
        public string str_Select_AddTrainingPopup_Training_CmbTraining { get; set; }
        public string str_Select_UpdateStatusPopup_Status_appStatus { get; set; }
        public string str_Txt_UpdateStatusPopup_Commnets_TxtComments { get; set; }

        public string str_Link_Onboarding_Data { get; set; }
        public string str_ID_Select_AddAssetPopup_AssetCategory_CmbAssetCategory { get; set; }
        public string str_ID_Select_AddAssetPopup_AssetType_CmbAssetType { get; set; }
        public string str_ID_Select_AddAssetPopup_Asset_CmdAsset { get; set; }
        public string str_ID_Txt_AddAssetPopup_Comment_TxtAssetcomment { get; set; }

        public string str_ID_Select_AddCompliancePopup_Compliance_CmbCompliance { get; set; }

        public string str_ID_Select_AddDocumentPopup_Document_Cmbdocument { get; set; }
        public string str_ID_Txt_ExtendExpiryDaysPopup_ExtendExpirationDays_expiryDays { get; set; }
        public string str_Txt_Document_UploadFilePath { get; set; }
        public string str_ID_Txt_ResubmitDocPopup_Comments_txtResubmitComment { get; set; }


        public string str_Actionlist { get; set; }
        public string str_ID_select_Reasontopauseonboarding_Cmbpausereason { get; set; }
        public string str_ID_Text_Comment_Txtpausereasoncomment { get; set; }        
        public string str_select_Isthenrewhire_YES { get; set; }
        public string str_select_phonerequired { get; set; }
        public string str_select_PhoneExistsonNewHireDesk { get; set; }
        public string str_Text_ExistingPhoneNumber { get; set; }
        public string str_text_NameAssignedtoExistingPhone { get; set; }
        public string str_Select_SoftphoneRequired { get; set; }
        public string str_Select_PCrequired { get; set; }
        public string str_Text_PersontoModelPCafter { get; set; }


        
    }

}
