# Define variables
$resourceGroup = "ThAmCowebapps_group"
$location = "UKSouth"
$profileServiceName = "ThAmCoProfileService"
$productServiceName = "ThAmcoProduct-Service"

# Create the resource group if it doesn't exist
Write-Host "Creating Resource Group if it doesn't already exist..."
az group create --name $resourceGroup --location $location

# Deploy Profile Service
Write-Host "Deploying Profile Service..."
az webapp up --name $profileServiceName --resource-group $resourceGroup --runtime "DOTNETCORE|9.0" --location $location
Write-Host "Profile Service deployed successfully."

# Deploy Product Service
Write-Host "Deploying Product Service..."
cd ../ProductService
az webapp up --name $productServiceName --resource-group $resourceGroup --runtime "DOTNETCORE|9.0" --location $location
Write-Host "Product Service deployed successfully."
