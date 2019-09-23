FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Order/Order.csproj Order/
RUN dotnet restore Order/Order.csproj
COPY . .
WORKDIR /src/Order
RUN dotnet build Order.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Order.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Order.dll"]