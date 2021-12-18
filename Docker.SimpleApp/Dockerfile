FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /simple-app
COPY . .
RUN dotnet restore ./Docker.SimpleApp.csproj
WORKDIR release
WORKDIR /simple-app
RUN dotnet build --no-restore -c Release -o release Docker.SimpleApp.csproj
WORKDIR release
CMD dotnet Docker.SimpleApp.dll

