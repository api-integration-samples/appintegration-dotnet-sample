# Application Integration Dotnet C# Cloud Functions Sample
This sample shows how C# code can be easily integrated into Application Integration workflows using Google Cloud Functions.

## Deployment
```sh
gcloud run deploy appint-dotnet-function \
  --source . \
  --base-image dotnet8 --allow-unauthenticated \
  --project $PROJECT_ID --region $REGION
```

## Sample order
```js
{
  "OrderId": "123232",
  "TrackingId": "",
  "Description": "Order 123432",
  "CustomerId": "12321",
  "DateTime": "2024-10-11",
  "TotalValue": 100.00,
  "ItemCount": 5,
  "Items": [
    {
      "ItemId": "2321321",
      "Description": "Item description...",
      "Quantity": 1,
      "Price": 20,
      "DepartmentId": "342",
      "CategoryId": "222",
      "TaxRate": "16%"
    },
    {
      "ItemId": "2321321",
      "Description": "Item description...",
      "Quantity": 1,
      "Price": 20,
      "DepartmentId": "342",
      "CategoryId": "222",
      "TaxRate": "16%"
    },
    {
      "ItemId": "2321321",
      "Description": "Item description...",
      "Quantity": 1,
      "Price": 20,
      "DepartmentId": "342",
      "CategoryId": "222",
      "TaxRate": "16%"
    },
    {
      "ItemId": "2321321",
      "Description": "Item description...",
      "Quantity": 1,
      "Price": 20,
      "DepartmentId": "342",
      "CategoryId": "222",
      "TaxRate": "16%"
    },
    {
      "ItemId": "2321321",
      "Description": "Item description...",
      "Quantity": 1,
      "Price": 20,
      "DepartmentId": "342",
      "CategoryId": "222",
      "TaxRate": "16%"
    }
  ]
}
```