
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /sapp
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY *.sln .
#COPY ["Week8PicknPay/Week8PicknPay.csproj", "Week8PicknPay/"]
COPY Week8PicknPay/*.csproj Week8PicknPay/
COPY AppLogic/*.csproj AppLogic/
COPY pickNpayData/*.csproj pickNpayData/
COPY Models/*.csproj Models/
RUN dotnet restore Week8PicknPay/*.csproj
COPY . .
WORKDIR /src/Week8PicknPay
RUN dotnet build 
FROM build AS publish
WORKDIR /src/Week8PicknPay
RUN dotnet publish -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish src/Week8PicknPay/JsonFile/Category.json json/
COPY --from=publish src/Week8PicknPay/JsonFile/Products.json json/
#COPY --from=publish src/Week8PicknPay/JsonFile/ProductImages.json json/
#ENTRYPOINT ["dotnet", "Week8PicknPay.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Week8PicknPay.dll
    
    
  
  

