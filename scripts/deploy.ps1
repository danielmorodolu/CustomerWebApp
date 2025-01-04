# deploy.ps1
# Set variables for deployment
$resourceGroup = "ThAmCowebapps_group"         
$profileServiceName = "ThAmCoProfileService"       
$productServiceName = "ThAmcoProduct-Service"       

# Deploy ProfileService
Write-Host "Deploying ProfileService..."
az webapp deploy --name $profileServiceName --resource-group $resourceGroup --src-path ./ProfileService

# Deploy ProductService
Write-Host "Deploying ProductService..."
az webapp deploy --name $productServiceName --resource-group $resourceGroup --src-path ./ProductService

Write-Host "Deployment Complete!"
