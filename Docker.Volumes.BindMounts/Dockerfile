FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app/bin
WORKDIR /app
COPY . .
RUN dotnet restore ./Docker.Volumes.BindMounts.csproj
RUN dotnet build -c Release --no-restore -o bin ./Docker.Volumes.BindMounts.csproj
WORKDIR bin
ENTRYPOINT ["dotnet", "Docker.Volumes.BindMounts.dll"]