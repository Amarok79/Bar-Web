FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/Bar.Web/Bar.Web.csproj", "src/Bar.Web/"]
RUN dotnet restore "src/Bar.Web/Bar.Web.csproj"
COPY . .
WORKDIR "/src/src/Bar.Web"
RUN dotnet build "Bar.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bar.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bar.Web.dll"]
