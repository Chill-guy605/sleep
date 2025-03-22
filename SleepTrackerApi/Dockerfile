# Используем официальный образ .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SleepTrackerApi/SleepTrackerApi.csproj", "SleepTrackerApi/"]
RUN dotnet restore "SleepTrackerApi/SleepTrackerApi.csproj"
COPY . .
WORKDIR "/src/SleepTrackerApi"
RUN dotnet build "SleepTrackerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SleepTrackerApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SleepTrackerApi.dll"]
