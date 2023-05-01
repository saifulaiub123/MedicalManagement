#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SS.Api/SS.Api.csproj", "SS.Api/"]
COPY ["SS.Infrastructure/SS.Infrastructure.csproj", "SS.Infrastructure/"]
COPY ["SS.Domain/SS.Domain.csproj", "SS.Domain/"]
COPY ["SS.Application/SS.Application.csproj", "SS.Application/"]
COPY ["Framework/Logistic.Framework.csproj", "Framework/"]
COPY ["Logistic.Service/Logistic.Service.csproj", "Logistic.Service/"]
RUN dotnet restore "SS.Api/SS.Api.csproj"
COPY . .
WORKDIR "/src/SS.Api"
RUN dotnet build "SS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SS.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SS.Api.dll"]