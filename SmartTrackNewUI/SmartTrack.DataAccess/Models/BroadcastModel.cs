// --------------------------------------------------------------------------------------------------------------------
//<copyright file{get;set;} //"BroadcastModel.cs" company{get;set;} //"DCR Workforce Inc">
//   Copyright (c) DCR Workforce Inc. All rights reserved.
//   This code and information should not be copied and used outside of DCR Workforce Inc.
// </copyright>
// <summary>
//   Builds the Container for the Autofac IOC.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmartTrack.DataAccess.Models
{
    public class BroadcastModel
    {
        public string strClientName { get; set; } // Broadcast_Data["P5"].ToString().Trim();
        public string strMainMenuLink { get; set; } // Broadcast_Data["P6"].ToString().Trim();
        public string strSubMenuLink { get; set; } // Broadcast_Data["P7"].ToString().Trim();
        public string str_Link_ReqNumber { get; set; } // Broadcast_Data["P8"].ToString().Trim();
        public string str_Link_Broadcast { get; set; } // Broadcast_Data["P9"].ToString().Trim();
        public string str_Button_BroadcastToSupplier { get; set; } // Broadcast_Data["P10"].ToString().Trim();
        public string str_Txt_PayRates_Min { get; set; } // Broadcast_Data["P11"].ToString().Trim();
        public string str_Txt_PayRates_Max { get; set; } // Broadcast_Data["P12"].ToString().Trim();
        public string str_Txt_MarkUp { get; set; } // Broadcast_Data["P13"].ToString().Trim();
        public string str_CheckBox_RateLevel { get; set; } // Broadcast_Data["P13"].ToString().Trim();
  //      public string str_Button_SupplierSelection { get; set; } // Broadcast_Data["P14"].ToString().Trim();
        public string str_Txt_BillRate_Min { get; set; } // Broadcast_Data["P14"].ToString().Trim();
        public string str_Txt_BillRate_Max { get; set; } // Broadcast_Data["P15"].ToString().Trim();
        public string str_Button_SupplierSelection { get; set; } // Broadcast_Data["P16"].ToString().Trim();
        public string str_Select_DistributionList { get; set; } // Broadcast_Data["P17"].ToString().Trim();
        public string str_Select_Tier { get; set; } // Broadcast_Data["P17"].ToString().Trim();
        public string str_Select_GeographicalLocation { get; set; } // Broadcast_Data["P18"].ToString().Trim();
        public string str_CheckBox_Suppliers { get; set; } // Broadcast_Data["P19"].ToString().Trim();
        public string str_Btn_Broadcast_Action { get; set; } // Broadcast_Data["P20"].ToString().Trim();
        public string str_Btn_Broadcast_Action_Confirm { get; set; } // Broadcast_Data["P21"].ToString().Trim();
        public string str_Btn_Broadcast_Req_Action_Confirm { get; set; } // Broadcast_Data["P22"].ToString().Trim();
        public string str_Link_AddComment { get; set; } // Broadcast_Data["P23"].ToString().Trim();
        public string str_Radio_DisplayComment { get; set; } // Broadcast_Data["P24"].ToString().Trim();
        public string str_TxtArea_Comment { get; set; } // Broadcast_Data["P25"].ToString().Trim();
        public string str_Btn_Submit { get; set; } // Broadcast_Data["P26"].ToString().Trim();
        public string str_Btn_Comment_confirm_Yes { get; set; } // Broadcast_Data["P28"].ToString().Trim();
        public string str_Btn_Comment_confirm_Ok { get; set; } // Broadcast_Data["P29"].ToString().Trim();
        public string str_Chnage_Status { get; set; } // Broadcast_Data["P30"].ToString().Trim();
        public string str_Select_ChangeStatus { get; set; } // Broadcast_Data["P31"].ToString().Trim();
        public string str_ChangestatusButton_Submit { get; set; } // Broadcast_Data["P32"].ToString().Trim();
        public string str_Link_Cancel { get; set; } // Broadcast_Data["P33"].ToString().Trim();
        public string str_Select_CancelReason { get; set; } // Broadcast_Data["P34"].ToString().Trim();
        public string str_Button_Cancel { get; set; } // Broadcast_Data["P35"].ToString().Trim();
        public string str_Button_confirmOk { get; set; } // Broadcast_Data["P36"].ToString().Trim();
        public string str_Link_Edit { get; set; } // Broadcast_Data["P37"].ToString().Trim();
        public string strbtnReviewSubmit_Edit { get; set; } // Broadcast_Data["P38"].ToString().Trim();
        public string str_txt_BillRatesUSD_ddlBillratesHigh { get; set; }

    }
}