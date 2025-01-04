# deploy.ps1
# Set variables for deployment
$resourceGroup = "YourResourceGroup"         # Replace with your Azure resource group name
$profileServiceName = "ProfileService"       # Replace with your ProfileService Web App name
$productServiceName = "ProductService"       # Replace with your ProductService Web App name

# Deploy ProfileService
Write-Host "Deploying ProfileService..."
az webapp deploy --name $profileServiceName --resource-group $resourceGroup --src-path ./ProfileService

# Deploy ProductService
Write-Host "Deploying ProductService..."
az webapp deploy --name $productServiceName --resource-group $resourceGroup --src-path ./ProductService

Write-Host "Deployment Complete!"
