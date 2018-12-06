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
    using System.Collections.Generic;
    public class SampleRepository
    {
        public SampleModel GetOnboardingData(Dictionary<string, string> dict)
        {
            SampleModel sm = new SampleModel();
            sm.str_AddListTxt_ChargeNumbers = dict[""];
            sm.str_AddListTxt_GLNumbers=dict[""];
            sm.str_AddListTxt_txtTimecardApprover=dict[""];
            sm.str_btn_AccountAssignmentCostCenter_AccountAssignment1=dict[""];
            sm.str_btn_ChargingMethod_exemptFlag=dict[""];
            sm.str_btn_ComputerAccess_computerAccess=dict[""];
            sm.str_Btn_ConfirmCW_Submit = dict[""];
            return sm;
        }


    }
}