// --------------------------------------------------------------------------------------------------------------------
//<copyright file="ApproveModel.cs" company="DCR Workforce Inc">
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

    public class ApproveModel
    {
        public string strClientName {get;set;}// Approve_Data["P5"].ToString().Trim();
        public string strMainMenuLink {get;set;}// Approve_Data["P6"].ToString().Trim();
        public string strSubMenuLink {get;set;}// Approve_Data["P7"].ToString().Trim();
        public string str_Link_ReqNumber {get;set;}// Approve_Data["P8"].ToString().Trim();
        public string str_Link_Approve {get;set;}// Approve_Data["P9"].ToString().Trim();
        public string str_Txt_ApproveComment {get;set;}// Approve_Data["P10"].ToString().Trim();
        public string str_Btn_Approve_Action {get;set;}// Approve_Data["P11"].ToString().Trim();
        public string str_Btn_Approve_Confirm_Action {get;set;}// Approve_Data["P12"].ToString().Trim();
        public string str_Btn_Approve_Confirm_OK_Action {get;set;}// Approve_Data["P13"].ToString().Trim();
        public string str_Txt_RejectComment { get; set; }
        public string str_ID_RejectPopup_Select_ReasonToReject_RejectReason { get; set; }
    }
}
