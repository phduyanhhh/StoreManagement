FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/StoreManagement.Web.Mvc/StoreManagement.Web.Mvc.csproj", "src/StoreManagement.Web.Mvc/"]
COPY ["src/StoreManagement.Web.Core/StoreManagement.Web.Core.csproj", "src/StoreManagement.Web.Core/"]
COPY ["src/StoreManagement.Application/StoreManagement.Application.csproj", "src/StoreManagement.Application/"]
COPY ["src/StoreManagement.Core/StoreManagement.Core.csproj", "src/StoreManagement.Core/"]
COPY ["src/StoreManagement.EntityFrameworkCore/StoreManagement.EntityFrameworkCore.csproj", "src/StoreManagement.EntityFrameworkCore/"]
WORKDIR "/src/src/StoreManagement.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/StoreManagement.Web.Mvc", "src/StoreManagement.Web.Mvc"]
COPY ["src/StoreManagement.Web.Core", "src/StoreManagement.Web.Core"]
COPY ["src/StoreManagement.Application", "src/StoreManagement.Application"]
COPY ["src/StoreManagement.Core", "src/StoreManagement.Core"]
COPY ["src/StoreManagement.EntityFrameworkCore", "src/StoreManagement.EntityFrameworkCore"]
WORKDIR "/src/src/StoreManagement.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "StoreManagement.Web.Mvc.dll"]
