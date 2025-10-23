#!/bin/bash

echo "Limpiando carpeta de publicación..."
rm -rf ./publish

echo "Compilando POSv2 para Windows..."
dotnet publish -c Release -r win-x64 --self-contained -o ./publish/win-x64
echo "Comprimiendo ejecutable de Windows..."
cd ./publish/win-x64
zip -r ../win-x64.zip ./*
cd ../../

echo "Compilando POSv2 para macOS..."
dotnet publish -c Release -r osx-x64 --self-contained -o ./publish/osx-x64
echo "Comprimiendo ejecutable de macOS..."
cd ./publish/osx-x64
zip -r ../osx-x64.zip ./*
cd ../../

echo "Compilando POSv2 para Linux..."
dotnet publish -c Release -r linux-x64 --self-contained -o ./publish/linux-x64
echo "Comprimiendo ejecutable de Linux..."
cd ./publish/linux-x64
zip -r ../linux-x64.zip ./*
cd ../../

echo "Compilando POSv2 para Android..."
dotnet publish -c Release -f net8.0-android -o ./publish/android
echo "Comprimiendo APK de Android..."
cd ./publish/android
zip -r ../android.zip ./*
cd ../../

echo "Compilando POSv2 para iOS..."
dotnet publish -c Release -f net8.0-ios -o ./publish/ios
echo "Comprimiendo ejecutable de iOS..."
cd ./publish/ios
zip -r ../ios.zip ./*
cd ../../

echo "¡Todos los ejecutables y paquetes .zip están en la carpeta ./publish!"