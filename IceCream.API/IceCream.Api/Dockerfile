#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
#EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IceCream.Api/IceCream.Api.csproj", "IceCream.Api/"]
COPY ["IceCream.Application/IceCream.Application.csproj", "IceCream.Application/"]
COPY ["IceCream.Domain/IceCream.Domain.csproj", "IceCream.Domain/"]
COPY ["IceCream.Infrastructure/IceCream.Infrastructure.csproj", "IceCream.Infrastructure/"]
COPY ["IceCream.Utilities/IceCream.Utilities.csproj", "IceCream.Utilities/"]
RUN dotnet restore "IceCream.Api/IceCream.Api.csproj"
COPY . .
WORKDIR "/src/IceCream.Api"
RUN dotnet build "IceCream.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IceCream.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IceCream.Api.dll"]
