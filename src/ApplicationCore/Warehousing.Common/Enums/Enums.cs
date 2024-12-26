using System.ComponentModel.DataAnnotations;

namespace Warehousing.Common.Enums
{
    public enum PackingType
    {
        Shell = 1,
        Cartoon = 2,
        Box = 3,
        Breaking = 4
    }
    public enum OperationTypeStatus
    {
        EnterToMainWarehouse = 1,        //ورود به انبار اصلی +
        ExitFromMainWarehouse = 2,       //خروج از انبار اصلی -
        EnterToWastageWarehouse = 3,   //ورود به انبار ضایعات +
        ExitFromWastageWarehouse = 4,    //خروج از انبار اصلی -
        Sold = 5,                                //فروخته شده -
        Returned = 6,                             //مرجوع شده +   
        IncreasingBalance = 7,                //بالانس افزایشی +
        DecreasingBalance = 8,                  //بالانس کاهشی -
        TransferFromNewFiscalYear = 9//انتقالی از سال مالی جدید
    }
    public enum InvoiceType
    {
        [Display(Name = "فروخته شده")]
        Sold = 1,        
        [Display(Name = "مرجوع شده")]
        Returned = 2,    
    }
    public enum InvoiceStatus
    {
        [Display(Name = "بسته")]
        Close = 1,         
        [Display(Name = "فاکتور موقت - پیش فاکتور")]
        Open = 2,        
    }
    public enum FiscalYearStatus
    {
        [Display(Name = "نامشخص")]
        Undefined = 0,
        [Display(Name = "بسته")]
        Close = 1,
        [Display(Name = "باز")]
        Open = 2,
        [Display(Name = " بار ولی منقضی شده")]
        Expired = 3,
    }
}
