FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WeightConversion/WeightConversion.csproj", "WeightConversion/"]
RUN dotnet restore "WeightConversion/WeightConversion.csproj"
COPY . .
WORKDIR "/src/WeightConversion"
RUN dotnet build "WeightConversion.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeightConversion.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeightConversion.dll"]
