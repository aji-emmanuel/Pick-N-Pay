
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS base
WORKDIR /src
COPY *.sln .
# copy and restore all projects
COPY Week8PicknPay/*.csproj Week8PicknPay/
#COPY PickNPayTest/*.csproj PickNPayTest/
COPY pickNpayData/*.csproj pickNpayData/
#COPY AppModel/*.csproj AppModel/
#COPY AppLogic/*.csproj AppLogic/
RUN dotnet restore Week8PicknPay/*.csproj
#RUN dotnet restore PickNPayTest/*.csproj
# Copy everything else
COPY . .
#Testing
#FROM base AS testing
#WORKDIR /src/Week7SQLite
#RUN dotnet build
#WORKDIR /src/PickNPayTest
#WORKDIR /src/PickNPayTest
#RUN dotnet test

#Publishing
FROM base AS publish
WORKDIR /src/Week8PicknPay
RUN dotnet publish -c Release -o /src/publish

#Get the runtime into a folder called app
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
COPY --from=publish /src/pickNpayData/JsonFile/* JsonFile/
#ENTRYPOINT ["dotnet", "Week7SQLite.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Week8PicknPay.dll