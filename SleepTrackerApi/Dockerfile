# Используем официальный образ .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Используем официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Копируем проектный файл
COPY ./SleepTrackerApi/SleepTrackerApi.csproj ./SleepTrackerApi/

# Восстанавливаем зависимости
RUN dotnet restore "SleepTrackerApi/SleepTrackerApi.csproj"

# Копируем остальные файлы проекта
COPY . .

# Устанавливаем рабочую директорию для сборки
WORKDIR "/src/SleepTrackerApi"

# Строим проект
RUN dotnet build "SleepTrackerApi.csproj" -c Release -o /app/build

# Этап публикации
FROM build AS publish
RUN dotnet publish "SleepTrackerApi.csproj" -c Release -o /app/publish

# Финальный образ на основе ASP.NET
FROM base AS final
WORKDIR /app

# Копируем скомпилированные файлы из этапа публикации
COPY --from=publish /app/publish .

# Указываем точку входа в приложение
ENTRYPOINT ["dotnet", "SleepTrackerApi.dll"]

