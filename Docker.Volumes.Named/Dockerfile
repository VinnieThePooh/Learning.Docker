FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /named-volumes-app
COPY . .
RUN dotnet restore ./Docker.Volumes.Named.csproj
WORKDIR release
WORKDIR /named-volumes-app
RUN dotnet build --no-restore -c Release -o release Docker.Volumes.Named.csproj
WORKDIR release
CMD dotnet Docker.Volumes.Named.dll

