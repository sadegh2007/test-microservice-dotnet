FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TestMicro.Gatewa/TestMicro.Gatewa.csproj", "src/TestMicro.Gatewa/"]
RUN dotnet restore "src/TestMicro.Gatewa/TestMicro.Gatewa.csproj"
COPY . .
WORKDIR "/src/src/TestMicro.Gatewa"
RUN dotnet build "TestMicro.Gatewa.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TestMicro.Gatewa.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestMicro.Gatewa.dll"]
