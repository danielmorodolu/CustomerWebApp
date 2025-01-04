# Define variables
$resourceGroup = "ThAmCowebapps_group"
$profileServiceName = "ThAmCoProfileService"
$productServiceName = "ThAmcoProduct-Service"

# Ensure Azure CLI is logged in
Write-Host "Logging in to Azure..."
az login

# Create Resource Group (if it doesn't exist)
Write-Host "Creating Resource Group if it doesn't already exist..."
az group create --name $resourceGroup --location "UKSouth"

# Profile Service Deployment
Write-Host "Deploying Profile Service..."
az webapp up --name $profileServiceName `
             --resource-group $resourceGroup `
             --runtime "DOTNETCORE|9.0" `
             --location "UKSouth" `
             --src-path "./ProfileService"
Write-Host "Profile Service deployed successfully."

# Product Service Deployment
Write-Host "Deploying Product Service..."
az webapp up --name $productServiceName `
             --resource-group $resourceGroup `
             --runtime "DOTNETCORE|9.0" `
             --location "UKSouth" `
             --src-path "./ProductService"
Write-Host "Product Service deployed successfully."
