Write-Host "Limpiando carpeta de publicación..."
Remove-Item -Recurse -Force ./publish

Write-Host "Compilando POSv2 para Windows..."
dotnet publish -c Release -r win-x64 --self-contained -o ./publish/win-x64
Write-Host "Comprimiendo ejecutable de Windows..."
Compress-Archive -Path ./publish/win-x64/* -DestinationPath ./publish/win-x64.zip

Write-Host "Compilando POSv2 para macOS..."
dotnet publish -c Release -r osx-x64 --self-contained -o ./publish/osx-x64
Write-Host "Comprimiendo ejecutable de macOS..."
Compress-Archive -Path ./publish/osx-x64/* -DestinationPath ./publish/osx-x64.zip

Write-Host "Compilando POSv2 para Linux..."
dotnet publish -c Release -r linux-x64 --self-contained -o ./publish/linux-x64
Write-Host "Comprimiendo ejecutable de Linux..."
Compress-Archive -Path ./publish/linux-x64/* -DestinationPath ./publish/linux-x64.zip

Write-Host "Compilando POSv2 para Android..."
dotnet publish -c Release -f net8.0-android -o ./publish/android
Write-Host "Comprimiendo APK de Android..."
Compress-Archive -Path ./publish/android/* -DestinationPath ./publish/android.zip

Write-Host "Compilando POSv2 para iOS..."
dotnet publish -c Release -f net8.0-ios -o ./publish/ios
Write-Host "Comprimiendo ejecutable de iOS..."
Compress-Archive -Path ./publish/ios/* -DestinationPath ./publish/ios.zip

Write-Host "¡Todos los ejecutables y paquetes .zip están en la carpeta ./publish!"