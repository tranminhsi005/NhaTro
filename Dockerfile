FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore NhaTro.Api/NhaTro.Api.csproj
RUN dotnet publish NhaTro.Api/NhaTro.Api.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:10000
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
EXPOSE 10000
ENTRYPOINT ["dotnet", "NhaTro.Api.dll"]