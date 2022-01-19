Application 1: X-CRM (Web Application)
Below is a Code Snippet of a web page in a CRM application.
Assume all functions specified below are all private.
X-CRM application has the following DLL Libraries (kbs.billit, kbs.utilities, billit.ui)

{
Void DisplayCustomerDetails()
{
CustomerName.Text = GetCustomerFirstName() + GetCustomerLastName();
CustomerAddress.Text = GetCustomerStreetAddress();
CustomerContactNumber.Text = GetCustomerContactNumber();
}
Void DisplayProducts()
{
ProductContactName.Text = GetCustomerFirstName() + GetCustomerLastName();
ProductServiceName.Text = GetProductName();
ProductServiceType.Text = GetProductType();
}
Void DisplayAmountOwing()
{
CustomerAmountOwing.Text = Convert.ToString(GetTotalDebitAmount() – GetTotalCreditAmount());
}
}


Application 2: X-API (web api)
X-API is a REST ASP.NET Web API.
X-API has the following DLL Libraries (kbs.billit, billit.utilities, dodo.api.controller)


Task:
1. In the X-API, we need to return Customer Details and the Customer Products information. Explain how you would achieve this and ensuring that there is a single source of truth for this functionality?
2. Refactor the Code Snippet above so that it reflects and supports your solution.

