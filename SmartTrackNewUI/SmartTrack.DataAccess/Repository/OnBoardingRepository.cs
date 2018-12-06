// --------------------------------------------------------------------------------------------------------------------
//<copyright file="CreateRequirementRepository.cs" company="DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Builds the Container for the Autofac IOC.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmartTrack.DataAccess.Repository
{
    using SmartTrack.DataAccess.Models;
    using System.Data;

	public class OnboardingRepository
	{
		public OnBoardingModel GetOnBoardingModel(DataRow Onboarding_Data)
		{
			OnBoardingModel OnboardingModel = new OnBoardingModel();
			OnboardingModel.strTestCaseId = Onboarding_Data["TestCaseID"].ToString().Trim();
			OnboardingModel.strUserID = Onboarding_Data["P1"].ToString().Trim();
			OnboardingModel.strClientName = Onboarding_Data["P3"].ToString().Trim();
			OnboardingModel.strMainMenuLink = Onboarding_Data["P4"].ToString().Trim();
			OnboardingModel.strSubMenuLink = Onboarding_Data["P5"].ToString().Trim();
			OnboardingModel.strAssetLink = Onboarding_Data["P9"].ToString().Trim();
			OnboardingModel.strAssetCategoryLink = Onboarding_Data["P10"].ToString().Trim();
			OnboardingModel.strCategoryName= Onboarding_Data["P11"].ToString().Trim();
			OnboardingModel.strCategoryDescription = Onboarding_Data["P12"].ToString().Trim();
			OnboardingModel.strAssertTypelink = Onboarding_Data["P13"].ToString().Trim();
			OnboardingModel.strAssertType = Onboarding_Data["P14"].ToString().Trim();
			OnboardingModel.strActionAssetLink = Onboarding_Data["P15"].ToString().Trim();
			OnboardingModel.strActionAssetName = Onboarding_Data["P16"].ToString().Trim();

			//training
			OnboardingModel.strOnboardingTraining = Onboarding_Data["P17"].ToString().Trim();
			OnboardingModel.strTrainingname = Onboarding_Data["P18"].ToString().Trim();
			OnboardingModel.strTrainingDescription = Onboarding_Data["P19"].ToString().Trim();
			OnboardingModel.strPreSubmit = Onboarding_Data["P20"].ToString().Trim();
			OnboardingModel.strallCWs = Onboarding_Data["P21"].ToString().Trim();
			OnboardingModel.strPreStart = Onboarding_Data["P22"].ToString().Trim();
			OnboardingModel.strRecurring = Onboarding_Data["P23"].ToString().Trim();
			OnboardingModel.strRecurringFrequecy = Onboarding_Data["P24"].ToString().Trim();
			OnboardingModel.struploadDocumentTemplate = Onboarding_Data["P25"].ToString().Trim();

			//documents
			OnboardingModel.strOnboardingDocumentlink = Onboarding_Data["P26"].ToString().Trim();
			OnboardingModel.strDocument = Onboarding_Data["P27"].ToString().Trim();
			OnboardingModel.strDocumentType = Onboarding_Data["P28"].ToString().Trim();
			OnboardingModel.strExpiryDays = Onboarding_Data["P29"].ToString().Trim();
			OnboardingModel.strDocPreSubmit = Onboarding_Data["P30"].ToString().Trim();
			OnboardingModel.strDocPreStart = Onboarding_Data["P31"].ToString().Trim();
			OnboardingModel.strAdminOverirdeAllowed = Onboarding_Data["P32"].ToString().Trim();
			OnboardingModel.strDocumentUploadRequired = Onboarding_Data["P33"].ToString().Trim();
			OnboardingModel.struploaddocDocumentTemplate = Onboarding_Data["P34"].ToString().Trim();

			//Compliance

			OnboardingModel.strOnboardingCompliancelink = Onboarding_Data["P35"].ToString().Trim();
			OnboardingModel.strComplainceName = Onboarding_Data["P36"].ToString().Trim();
			OnboardingModel.strComplainceType = Onboarding_Data["P37"].ToString().Trim();
			OnboardingModel.strComplainceDescription = Onboarding_Data["P38"].ToString().Trim();
			OnboardingModel.strstepconfigurationname = Onboarding_Data["P39"].ToString().Trim();
			OnboardingModel.strstepconfigurationbymsp = Onboarding_Data["P40"].ToString().Trim();
			OnboardingModel.strpkgconfigurationname = Onboarding_Data["P41"].ToString().Trim();
			OnboardingModel.strpkgconfigurationindefinite= Onboarding_Data["P42"].ToString().Trim();
			OnboardingModel.strpkgconfigurationExpirydays = Onboarding_Data["P43"].ToString().Trim();
			OnboardingModel.strComplianceAdminOverirdeAllowed = Onboarding_Data["P44"].ToString().Trim();
			OnboardingModel.strComplianceAdminOverirdeReasons = Onboarding_Data["P45"].ToString().Trim();
			OnboardingModel.strCompliancePreSubmit = Onboarding_Data["P46"].ToString().Trim();
			OnboardingModel.strCompliancePreStart = Onboarding_Data["P47"].ToString().Trim();
			
			OnboardingModel.strCompliancetUploadRequired = Onboarding_Data["P48"].ToString().Trim();


            OnboardingModel.str_Link_ReqNumber = Onboarding_Data["P6"].ToString().Trim();
            OnboardingModel.str_CandidateName = Onboarding_Data["P8"].ToString().Trim();

            OnboardingModel.str_ID_Select_AddAssetPopup_AssetCategory_CmbAssetCategory = Onboarding_Data["P10"].ToString().Trim();
            OnboardingModel.str_ID_Select_AddAssetPopup_AssetType_CmbAssetType = Onboarding_Data["P11"].ToString().Trim();
            OnboardingModel.str_ID_Select_AddAssetPopup_Asset_CmdAsset = Onboarding_Data["P12"].ToString().Trim();
            OnboardingModel.str_ID_Txt_AddAssetPopup_Comment_TxtAssetcomment = Onboarding_Data["P13"].ToString().Trim();

            OnboardingModel.str_ID_Select_AddDocumentPopup_Document_Cmbdocument = Onboarding_Data["P20"].ToString().Trim();
            OnboardingModel.str_ID_Txt_ExtendExpiryDaysPopup_ExtendExpirationDays_expiryDays = Onboarding_Data["P21"].ToString().Trim();
            OnboardingModel.str_Txt_Document_UploadFilePath = Onboarding_Data["P22"].ToString().Trim();
            OnboardingModel.str_ID_Txt_ResubmitDocPopup_Comments_txtResubmitComment = Onboarding_Data["P23"].ToString().Trim();

            OnboardingModel.str_ID_Select_AddCompliancePopup_Compliance_CmbCompliance = Onboarding_Data["P25"].ToString().Trim();

            OnboardingModel.str_ActionLink_AddTraining = Onboarding_Data["P31"].ToString().Trim();
            OnboardingModel.str_Select_AddTrainingPopup_Training_CmbTraining = Onboarding_Data["P32"].ToString().Trim();
            OnboardingModel.str_Select_UpdateStatusPopup_Status_appStatus = Onboarding_Data["P33"].ToString().Trim();
            OnboardingModel.str_Txt_UpdateStatusPopup_Commnets_TxtComments = Onboarding_Data["P34"].ToString().Trim();

			//OnboardingModel.str_Txt_ReqNumber = OnBoardingModel["P6"].ToString().Trim();
			//OnboardingModel.str_Link_View_Candidates = OnBoardingModel["P7"].ToString().Trim();
			//OnboardingModel.str_Txt_CandidateName = OnBoardingModel["P8"].ToString().Trim();
			//OnboardingModel.str_Link_ConfirmInterview = OnBoardingModel["P9"].ToString().Trim();
            OnboardingModel.str_Actionlist = Onboarding_Data["P7"].ToString().Trim();

            OnboardingModel.str_ID_Txt_AddAssetPopup_Comment_TxtAssetcomment = Onboarding_Data["P13"].ToString().Trim();

            OnboardingModel.str_select_phonerequired = Onboarding_Data["P13"].ToString().Trim();
            OnboardingModel.str_select_PhoneExistsonNewHireDesk = Onboarding_Data["P14"].ToString().Trim();

            OnboardingModel.str_Text_ExistingPhoneNumber = Onboarding_Data["P15"].ToString().Trim();

            OnboardingModel.str_text_NameAssignedtoExistingPhone = Onboarding_Data["P16"].ToString().Trim();
            OnboardingModel.str_Select_SoftphoneRequired = Onboarding_Data["P17"].ToString().Trim();
            OnboardingModel.str_Select_PCrequired = Onboarding_Data["P18"].ToString().Trim();

			return OnboardingModel;
		}

		
	}
}