FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DesafioIBGE/DesafioIBGE.csproj", "DesafioIBGE/"]
RUN dotnet restore "DesafioIBGE/DesafioIBGE.csproj"
COPY . .
WORKDIR "/src/DesafioIBGE"
RUN dotnet build "DesafioIBGE.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioIBGE.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioIBGE.dll"]
