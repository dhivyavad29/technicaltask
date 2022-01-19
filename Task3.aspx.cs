Task: You are to review the code below. Without knowing the business requirement, comment on how the below code could be improved from your point of view.
// EnableSession property is required since we are accessing HttpContext.Current.Session otherwise it will be null
[System.Web.Services.WebMethod(EnableSession = true)]
public static string GetLeads(string simNo, string email)
{
try
{
//TODO : Instead of passing mutiple arguments we can create an Model object and use that as a parameter to repository method
var deliverySalesLeads = deliverySalesLeadsRepository.GetDeliverySalesLeads(null, null, email, null, null, simNo);

deliverySalesLeads.RemoveAll(x => x.DelStatus == DeliveryStatus.CustomerCreated); // Don't return sales leads with CustomerCreated status
deliverySalesLeads.RemoveAll(y => y.DelStatus == DeliveryStatus.RTS); // Don't return sales leads with RTS status
DeliverySalesLead = deliverySalesLeads.FirstOrDefault();

DeliverySalesLead =  deliverySalesLeads.RemoveAll(x => x.DelStatus == (DeliveryStatus.CustomerCreated || DeliveryStatus.RTS)).FirstOrDefault(); 
if (DeliverySalesLead != null)
{
if (string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(DeliverySalesLead.CustEmail))
{
return "Enter Email Address";
}
// promo code applies during signups
GenericPromoDetails promoDetails = ApplyPromoCode(DeliverySalesLead);

//string planAndPromoCode = string.Empty;

StringBuilder planAndPromoCode = new StringBuilder();

if (promoDetails != null)
{
HttpContext.Current.Session["DeliverySalesLead_PromoCodePercentage"] = promoDetails.DiscountAmount;
HttpContext.Current.Session["DeliverySalesLead_PromoCode"] = promoDetails.PromoCode;
// The "|" is added to split the promo details.
//planAndPromoCode = "|" + promoDetails.PlanIds + "|" + promoDetails.TransactionText;

                        planAndPromoCode = (!string.IsNullOrEmpty(promoDetails.PlanIds)) ? planAndPromoCode.Append("|").Append(promoDetails.PlanIds) : string.Empty;
                        planAndPromoCode = (!string.IsNullOrEmpty(promoDetails.TransactionText)) ? planAndPromoCode.Append("|").Append(promoDetails.TransactionText) : string.Empty;

}
var addonList = GetAddonList(DeliverySalesLead.SelectedAddons);
return DeliverySalesLead.SelectedPlanCode + addonList + planAndPromoCode;
Internal Use
Internal Use
}
else
{
HttpContext.Current.Session["DeliverySalesLead_PromoCodePercentage"] = null;
HttpContext.Current.Session["DeliverySalesLead_PromoCode"] = null;
}
return null;
}
catch (Exception)
{
throw;
}
}
