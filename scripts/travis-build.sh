#!/bin/bash
cd src/ModelsConverter/
sudo snap alias dotnet-sdk.dotnet dotnet
dotnet build --configuration Release
dotnet test
