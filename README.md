# Application Integration Dotnet C# Cloud Functions Sample
This sample shows how C# code can be easily integrated into Application Integration workflows using Google Cloud Functions.

## Deployment
```sh
gcloud run deploy appint-dotnet-function \
  --source . \
  --base-image dotnet8 --allow-unauthenticated \
  --project $PROJECT_ID --region $REGION
```