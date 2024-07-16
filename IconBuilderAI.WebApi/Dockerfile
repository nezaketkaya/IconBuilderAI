#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IconBuilderAI.WebApi/IconBuilderAI.WebApi.csproj", "IconBuilderAI.WebApi/"]
RUN dotnet restore "IconBuilderAI.WebApi/IconBuilderAI.WebApi.csproj"
COPY . .
WORKDIR "/src/IconBuilderAI.WebApi"
RUN dotnet build "IconBuilderAI.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "IconBuilderAI.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IconBuilderAI.WebApi.dll"]