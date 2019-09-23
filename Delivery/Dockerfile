FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Delivery/Delivery.csproj Delivery/
RUN dotnet restore Delivery/Delivery.csproj
COPY . .
WORKDIR /src/Delivery
RUN dotnet build Delivery.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Delivery.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Delivery.dll"]